using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;

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
        }

        private void ReviewOrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
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
    }
}
