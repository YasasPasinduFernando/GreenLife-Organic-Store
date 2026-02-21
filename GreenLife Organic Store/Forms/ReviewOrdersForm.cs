using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using System.Drawing;
using System.IO;

namespace GreenLife_Organic_Store.Forms
{
    public partial class ReviewOrdersForm : Form
    {
        private readonly User _currentCustomer;
        private Dictionary<int, OrderReview> _reviewsByOrder = new();
        private List<Order> _deliveredOrders = new();
        private int? _selectedOrderId;

        public ReviewOrdersForm(User currentCustomer)
        {
            _currentCustomer = currentCustomer;
            InitializeComponent();
            ApplyIcons();
        }

        private void ReviewOrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void ApplyIcons()
        {
            try
            {
                var iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "favicon.ico");
                if (File.Exists(iconPath))
                {
                    Icon = new Icon(iconPath);
                }
            }
            catch
            {
            }
        }

        private void LoadOrders()
        {
            _deliveredOrders = OrderRepository.GetOrdersByCustomerId(_currentCustomer.ID)
                .Where(o => o.Status == OrderStatus.Delivered)
                .ToList();

            _reviewsByOrder = ReviewRepository.GetReviewsByCustomer(_currentCustomer.ID);

            dgvOrders.Rows.Clear();
            foreach (var order in _deliveredOrders)
            {
                _reviewsByOrder.TryGetValue(order.ID, out var review);
                dgvOrders.Rows.Add(
                    order.ID,
                    order.OrderNumber,
                    order.OrderDate.ToString("yyyy-MM-dd"),
                    order.GetFormattedTotal(),
                    review?.Rating.ToString() ?? string.Empty,
                    review?.Comment ?? string.Empty,
                    review != null ? review.UpdatedDate.ToString("yyyy-MM-dd") : string.Empty
                );
            }

            if (dgvOrders.Rows.Count > 0)
            {
                dgvOrders.ClearSelection();
                dgvOrders.Rows[0].Selected = true;
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                _selectedOrderId = null;
                return;
            }

            var row = dgvOrders.SelectedRows[0];
            if (row.Cells["colOrderId"].Value == null)
            {
                _selectedOrderId = null;
                return;
            }

            _selectedOrderId = Convert.ToInt32(row.Cells["colOrderId"].Value);
            if (_selectedOrderId.HasValue && _reviewsByOrder.TryGetValue(_selectedOrderId.Value, out var review))
            {
                numRating.Value = Math.Max(1, Math.Min(5, review.Rating));
                txtComment.Text = review.Comment;
                lblReviewStatus.Text = "Reviewed";
            }
            else
            {
                numRating.Value = 5;
                txtComment.Text = string.Empty;
                lblReviewStatus.Text = "Not reviewed";
            }

            LoadOrderItemsImages(_selectedOrderId.Value);
        }

        private void LoadOrderItemsImages(int orderId)
        {
            flpItems.Controls.Clear();

            var order = _deliveredOrders.FirstOrDefault(o => o.ID == orderId);
            if (order == null)
            {
                return;
            }

            foreach (var item in order.Items)
            {
                var product = ProductRepository.GetProductById(item.ProductID);
                var panel = new Panel
                {
                    Width = 110,
                    Height = 120,
                    Margin = new Padding(6),
                    BackColor = Color.White
                };

                var pic = new PictureBox
                {
                    Width = 70,
                    Height = 70,
                    Location = new Point(20, 6),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle
                };

                if (product != null && !string.IsNullOrWhiteSpace(product.ImagePath))
                {
                    try
                    {
                        var fullPath = ImageStore.GetFullPath(product.ImagePath);
                        if (File.Exists(fullPath))
                        {
                            pic.ImageLocation = fullPath;
                        }
                    }
                    catch
                    {
                    }
                }

                var lbl = new Label
                {
                    Text = item.ProductName,
                    Location = new Point(6, 82),
                    Size = new Size(98, 32),
                    AutoEllipsis = true,
                    Font = new Font("Segoe UI", 7F),
                    TextAlign = ContentAlignment.TopCenter
                };

                panel.Controls.Add(pic);
                panel.Controls.Add(lbl);
                flpItems.Controls.Add(panel);
            }
        }

        private void btnSaveReview_Click(object sender, EventArgs e)
        {
            if (!_selectedOrderId.HasValue)
            {
                MessageBox.Show("Please select an order to review.", "Select Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rating = (int)numRating.Value;
            if (rating < 1 || rating > 5)
            {
                MessageBox.Show("Rating must be between 1 and 5.", "Invalid Rating", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var review = new OrderReview
            {
                OrderID = _selectedOrderId.Value,
                CustomerID = _currentCustomer.ID,
                Rating = rating,
                Comment = txtComment.Text.Trim()
            };

            try
            {
                ReviewRepository.SaveReview(review);
                MessageBox.Show("Review saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save review: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblComment_Click(object sender, EventArgs e)
        {

        }

        private void lblRating_Click(object sender, EventArgs e)
        {

        }
    }
}
