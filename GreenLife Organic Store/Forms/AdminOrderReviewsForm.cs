using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using System.Drawing;
using System.IO;

namespace GreenLife_Organic_Store.Forms
{
    public partial class AdminOrderReviewsForm : Form
    {
        public AdminOrderReviewsForm()
        {
            InitializeComponent();
            ApplyIcons();
        }

        private void AdminOrderReviewsForm_Load(object sender, EventArgs e)
        {
            LoadReviews();
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
                // Ignore icon load errors.
            }

            // Button icons are handled by FontAwesome.Sharp in the designer.
        }

        private void LoadReviews()
        {
            try
            {
                dgvReviews.Rows.Clear();
                var reviews = ReviewRepository.GetAllReviewSummaries();
                foreach (var review in reviews)
                {
                    dgvReviews.Rows.Add(
                        review.ReviewId,
                        review.OrderId,
                        review.OrderNumber,
                        review.CustomerName,
                        review.Rating,
                        review.Comment,
                        review.UpdatedDate.ToString("yyyy-MM-dd")
                    );
                }

                if (dgvReviews.Rows.Count > 0)
                {
                    dgvReviews.ClearSelection();
                    dgvReviews.Rows[0].Selected = true;
                    LoadSelectedOrderItems();
                }
                else
                {
                    flpItems.Controls.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reviews: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReviews();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvReviews_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedOrderItems();
        }

        private void LoadSelectedOrderItems()
        {
            if (dgvReviews.SelectedRows.Count == 0)
            {
                flpItems.Controls.Clear();
                return;
            }

            var row = dgvReviews.SelectedRows[0];
            if (row.Cells["colOrderId"].Value == null)
            {
                flpItems.Controls.Clear();
                return;
            }

            int orderId = Convert.ToInt32(row.Cells["colOrderId"].Value);
            LoadOrderItemsImages(orderId);
        }

        private void LoadOrderItemsImages(int orderId)
        {
            flpItems.Controls.Clear();

            var order = OrderRepository.GetOrderById(orderId);
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
                        // Ignore image load errors.
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
    }
}
