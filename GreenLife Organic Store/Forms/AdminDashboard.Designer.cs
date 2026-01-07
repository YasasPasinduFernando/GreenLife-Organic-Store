using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label labelWelcome;
        private Panel panelButtons;
        private IconButton buttonRegisterAdmin;
        private IconButton buttonRegisterCustomer;
        private IconButton buttonViewUsers;
        private IconButton buttonEditUser;
        private IconButton buttonDeleteUser;
        private IconButton buttonLogout;
        private DataGridView dataGridViewUsers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new Panel();
            iconLogo = new IconPictureBox();
            labelWelcome = new Label();
            panelButtons = new Panel();
            buttonRegisterAdmin = new IconButton();
            buttonRegisterCustomer = new IconButton();
            buttonViewUsers = new IconButton();
            buttonEditUser = new IconButton();
            buttonDeleteUser = new IconButton();
            buttonLogout = new IconButton();
            dataGridViewUsers = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconLogo).BeginInit();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(34, 139, 34);
            panelTop.Controls.Add(iconLogo);
            panelTop.Controls.Add(labelWelcome);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 2, 3, 2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(788, 60);
            panelTop.TabIndex = 0;
            // 
            // iconLogo
            // 
            iconLogo.BackColor = Color.FromArgb(34, 139, 34);
            iconLogo.ForeColor = Color.White;
            iconLogo.IconChar = IconChar.Leaf;
            iconLogo.IconColor = Color.White;
            iconLogo.IconFont = IconFont.Auto;
            iconLogo.IconSize = 40;
            iconLogo.Location = new Point(10, 10);
            iconLogo.Margin = new Padding(3, 2, 3, 2);
            iconLogo.Name = "iconLogo";
            iconLogo.Size = new Size(40, 40);
            iconLogo.TabIndex = 0;
            iconLogo.TabStop = false;
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelWelcome.ForeColor = Color.White;
            labelWelcome.Location = new Point(60, 17);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(150, 25);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome, Admin!";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(240, 245, 240);
            panelButtons.Controls.Add(buttonRegisterAdmin);
            panelButtons.Controls.Add(buttonRegisterCustomer);
            panelButtons.Controls.Add(buttonViewUsers);
            panelButtons.Controls.Add(buttonEditUser);
            panelButtons.Controls.Add(buttonDeleteUser);
            panelButtons.Controls.Add(buttonLogout);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 60);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(788, 98);
            panelButtons.TabIndex = 1;
            // 
            // buttonRegisterAdmin
            // 
            buttonRegisterAdmin.BackColor = Color.FromArgb(34, 139, 34);
            buttonRegisterAdmin.ForeColor = Color.White;
            buttonRegisterAdmin.IconChar = IconChar.UserPlus;
            buttonRegisterAdmin.IconColor = Color.White;
            buttonRegisterAdmin.IconFont = IconFont.Auto;
            buttonRegisterAdmin.IconSize = 20;
            buttonRegisterAdmin.Location = new Point(18, 11);
            buttonRegisterAdmin.Margin = new Padding(3, 2, 3, 2);
            buttonRegisterAdmin.Name = "buttonRegisterAdmin";
            buttonRegisterAdmin.Size = new Size(149, 34);
            buttonRegisterAdmin.TabIndex = 0;
            buttonRegisterAdmin.Text = "Register Admin";
            buttonRegisterAdmin.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRegisterAdmin.UseVisualStyleBackColor = false;
            buttonRegisterAdmin.Cursor = Cursors.Hand;
            // 
            // buttonRegisterCustomer
            // 
            buttonRegisterCustomer.BackColor = Color.FromArgb(60, 179, 113);
            buttonRegisterCustomer.ForeColor = Color.White;
            buttonRegisterCustomer.IconChar = IconChar.User;
            buttonRegisterCustomer.IconColor = Color.White;
            buttonRegisterCustomer.IconFont = IconFont.Auto;
            buttonRegisterCustomer.IconSize = 20;
            buttonRegisterCustomer.Location = new Point(175, 11);
            buttonRegisterCustomer.Margin = new Padding(3, 2, 3, 2);
            buttonRegisterCustomer.Name = "buttonRegisterCustomer";
            buttonRegisterCustomer.Size = new Size(165, 34);
            buttonRegisterCustomer.TabIndex = 1;
            buttonRegisterCustomer.Text = "Register Customer";
            buttonRegisterCustomer.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRegisterCustomer.UseVisualStyleBackColor = false;
            buttonRegisterCustomer.Cursor = Cursors.Hand;
            buttonRegisterCustomer.Click += buttonRegisterCustomer_Click;
            // 
            // buttonViewUsers
            // 
            buttonViewUsers.BackColor = Color.FromArgb(100, 149, 237);
            buttonViewUsers.ForeColor = Color.White;
            buttonViewUsers.IconChar = IconChar.Sync;
            buttonViewUsers.IconColor = Color.White;
            buttonViewUsers.IconFont = IconFont.Auto;
            buttonViewUsers.IconSize = 20;
            buttonViewUsers.Location = new Point(348, 11);
            buttonViewUsers.Margin = new Padding(3, 2, 3, 2);
            buttonViewUsers.Name = "buttonViewUsers";
            buttonViewUsers.Size = new Size(133, 34);
            buttonViewUsers.TabIndex = 2;
            buttonViewUsers.Text = "Refresh Users";
            buttonViewUsers.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonViewUsers.UseVisualStyleBackColor = false;
            buttonViewUsers.Cursor = Cursors.Hand;
            // 
            // buttonEditUser
            // 
            buttonEditUser.BackColor = Color.LightBlue;
            buttonEditUser.ForeColor = Color.Black;
            buttonEditUser.IconChar = IconChar.Edit;
            buttonEditUser.IconColor = Color.Black;
            buttonEditUser.IconFont = IconFont.Auto;
            buttonEditUser.IconSize = 20;
            buttonEditUser.Location = new Point(18, 56);
            buttonEditUser.Margin = new Padding(3, 2, 3, 2);
            buttonEditUser.Name = "buttonEditUser";
            buttonEditUser.Size = new Size(149, 34);
            buttonEditUser.TabIndex = 3;
            buttonEditUser.Text = "Edit User";
            buttonEditUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonEditUser.UseVisualStyleBackColor = false;
            buttonEditUser.Cursor = Cursors.Hand;
            // 
            // buttonDeleteUser
            // 
            buttonDeleteUser.BackColor = Color.LightCoral;
            buttonDeleteUser.ForeColor = Color.White;
            buttonDeleteUser.IconChar = IconChar.TrashAlt;
            buttonDeleteUser.IconColor = Color.White;
            buttonDeleteUser.IconFont = IconFont.Auto;
            buttonDeleteUser.IconSize = 20;
            buttonDeleteUser.Location = new Point(175, 56);
            buttonDeleteUser.Margin = new Padding(3, 2, 3, 2);
            buttonDeleteUser.Name = "buttonDeleteUser";
            buttonDeleteUser.Size = new Size(149, 34);
            buttonDeleteUser.TabIndex = 4;
            buttonDeleteUser.Text = "Delete User";
            buttonDeleteUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDeleteUser.UseVisualStyleBackColor = false;
            buttonDeleteUser.Cursor = Cursors.Hand;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.FromArgb(220, 53, 69);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.IconChar = IconChar.SignOutAlt;
            buttonLogout.IconColor = Color.White;
            buttonLogout.IconFont = IconFont.Auto;
            buttonLogout.IconSize = 20;
            buttonLogout.Location = new Point(348, 56);
            buttonLogout.Margin = new Padding(3, 2, 3, 2);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(133, 34);
            buttonLogout.TabIndex = 5;
            buttonLogout.Text = "Logout";
            buttonLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Cursor = Cursors.Hand;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.Location = new Point(0, 158);
            dataGridViewUsers.Margin = new Padding(3, 2, 3, 2);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(788, 300);
            dataGridViewUsers.TabIndex = 2;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 458);
            Controls.Add(dataGridViewUsers);
            Controls.Add(panelButtons);
            Controls.Add(panelTop);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AdminDashboard";
            Text = "GreenLife Organic Store - Admin Dashboard";
            Load += AdminDashboard_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconLogo).EndInit();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
        }
        private IconPictureBox iconLogo;
    }
}