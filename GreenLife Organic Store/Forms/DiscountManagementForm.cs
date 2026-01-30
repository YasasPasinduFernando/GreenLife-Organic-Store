using GreenLife_Organic_Store.Database;
using GreenLife_Organic_Store.Models;
using GreenLife_Organic_Store.Utilities;
using FontAwesome.Sharp;
using System.IO;

namespace GreenLife_Organic_Store.Forms
{
    public partial class DiscountManagementForm : Form
    {
        private List<Discount> _allDiscounts = new();
        private List<Product> _allProducts = new();
        private DataGridView _dgvDiscounts = null!;

        public DiscountManagementForm()
        {
            this.Text = "Manage Discounts";
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Load += DiscountManagementForm_Load;
        }

        private void DiscountManagementForm_Load(object? sender, EventArgs e)
        {
            InitializeUI();
            LoadData();
        }

        private void InitializeUI()
        {
            // Header
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(46, 204, 113),
                Padding = new Padding(15)
            };

            Label lblHeader = new Label
            {
                Text = "Discount Management",
                Location = new Point(15, 12),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            pnlHeader.Controls.Add(lblHeader);

            // Toolbar
            Panel pnlToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            IconButton btnAdd = new IconButton
            {
                Text = "Add New Discount",
                Location = new Point(10, 10),
                Size = new Size(160, 35),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Plus,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click += (s, e) => AddDiscount();
            pnlToolbar.Controls.Add(btnAdd);

            IconButton btnRefresh = new IconButton
            {
                Text = "Refresh",
                Location = new Point(180, 10),
                Size = new Size(110, 35),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Sync,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (s, e) => LoadData();
            pnlToolbar.Controls.Add(btnRefresh);

            // keep toolbar added later for order

            // DataGridView
            _dgvDiscounts = new DataGridView
            {
                Name = "dgvDiscounts",
                Dock = DockStyle.Top,
                Height = 400,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(52, 73, 94),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Padding = new Padding(5)
                },
                ColumnHeadersHeight = 40,
                RowTemplate = new DataGridViewRow { Height = 30 },
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(250, 250, 250) }
            };
            var imgCol = new DataGridViewImageColumn
            {
                Name = "Image",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 60
            };
            _dgvDiscounts.Columns.Add(imgCol);
            _dgvDiscounts.Columns.Add("ID", "ID");
            _dgvDiscounts.Columns.Add("DiscountName", "Discount Name");
            _dgvDiscounts.Columns.Add("ProductName", "Product");
            _dgvDiscounts.Columns.Add("Percent", "Discount %");
            _dgvDiscounts.Columns.Add("StartDate", "Start Date");
            _dgvDiscounts.Columns.Add("EndDate", "End Date");
            _dgvDiscounts.Columns.Add("Status", "Status");
            _dgvDiscounts.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) EditSelectedDiscount(); };
            // keep grid added later for order

            // Action Buttons
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10)
            };

            IconButton btnEdit = new IconButton
            {
                Text = "Edit Discount",
                Location = new Point(10, 10),
                Size = new Size(140, 35),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Edit,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += (s, e) => EditSelectedDiscount();
            pnlActions.Controls.Add(btnEdit);

            IconButton btnDelete = new IconButton
            {
                Text = "Delete Discount",
                Location = new Point(160, 10),
                Size = new Size(140, 35),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                IconChar = IconChar.TrashAlt,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += (s, e) => DeleteSelectedDiscount();
            pnlActions.Controls.Add(btnDelete);

            IconButton btnClose = new IconButton
            {
                Text = "Close",
                Location = new Point(310, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                IconChar = IconChar.Times,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();
            pnlActions.Controls.Add(btnClose);

            // Add in strict top-to-bottom order
            this.Controls.Add(pnlActions);
            this.Controls.Add(_dgvDiscounts);
            this.Controls.Add(pnlToolbar);
            this.Controls.Add(pnlHeader);
        }

        private void LoadData()
        {
            try
            {
                _allDiscounts = DiscountRepository.GetAllDiscounts();
                _allProducts = ProductRepository.GetAllProducts();
                foreach (var productId in _allDiscounts.Select(d => d.ProductID).Distinct())
                {
                    DiscountRepository.SyncActiveDiscountForProduct(productId);
                }
                LoadDiscounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDiscounts()
        {
            try
            {
                _dgvDiscounts.Rows.Clear();

                foreach (var discount in _allDiscounts)
                {
                    Image? thumb = null;
                    try
                    {
                        var product = _allProducts.FirstOrDefault(p => p.ID == discount.ProductID);
                        if (product != null && !string.IsNullOrWhiteSpace(product.ImagePath))
                        {
                            var fullPath = ImageStore.GetFullPath(product.ImagePath);
                            if (File.Exists(fullPath))
                            {
                                using var img = Image.FromFile(fullPath);
                                thumb = new Bitmap(img, new Size(60, 60));
                            }
                        }
                    }
                    catch { }

                    _dgvDiscounts.Rows.Add(
                        thumb,
                        discount.ID,
                        discount.DiscountName,
                        discount.ProductName,
                        discount.GetFormattedPercent(),
                        discount.StartDate.ToString("dd/MM/yyyy"),
                        discount.EndDate.ToString("dd/MM/yyyy"),
                        discount.GetStatusText()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading discounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDiscount()
        {
            AddEditDiscountForm form = new AddEditDiscountForm(_allProducts);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void EditSelectedDiscount()
        {
            if (_dgvDiscounts.SelectedRows.Count > 0)
            {
                int discountId = (int)_dgvDiscounts.SelectedRows[0].Cells["ID"].Value;
                var discount = _allDiscounts.FirstOrDefault(d => d.ID == discountId);
                if (discount != null)
                {
                    AddEditDiscountForm form = new AddEditDiscountForm(_allProducts, discount);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a discount to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteSelectedDiscount()
        {
            if (_dgvDiscounts.SelectedRows.Count > 0)
            {
                int discountId = (int)_dgvDiscounts.SelectedRows[0].Cells["ID"].Value;
                var discount = _allDiscounts.FirstOrDefault(d => d.ID == discountId);
                if (MessageBox.Show("Are you sure you want to delete this discount?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (DiscountRepository.DeleteDiscount(discountId))
                        {
                            if (discount != null)
                            {
                                DiscountRepository.SyncActiveDiscountForProduct(discount.ProductID);
                            }
                            MessageBox.Show("Discount deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting discount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a discount to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
