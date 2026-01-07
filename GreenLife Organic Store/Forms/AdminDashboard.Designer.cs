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
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.FromArgb(34, 139, 34);
            // Add a small logo and welcome label
            var iconLogo = new IconPictureBox
            {
                IconChar = IconChar.Leaf,
                IconColor = Color.White,
                Location = new Point(10, 20),
                Size = new Size(40, 40),
                BackColor = Color.Transparent
            };
            panelTop.Controls.Add(iconLogo);
            panelTop.Controls.Add(labelWelcome);
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 80;
            panelTop.Name = "panelTop";
            panelTop.TabIndex = 0;

            // labelWelcome
            labelWelcome.AutoSize = true;
            labelWelcome.ForeColor = Color.White;
            labelWelcome.Location = new Point(60, 20);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(200, 38);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome, Admin!";

            // panelButtons
            panelButtons.BackColor = Color.FromArgb(240, 245, 240);
            panelButtons.Controls.Add(buttonRegisterAdmin);
            panelButtons.Controls.Add(buttonRegisterCustomer);
            panelButtons.Controls.Add(buttonViewUsers);
            panelButtons.Controls.Add(buttonEditUser);
            panelButtons.Controls.Add(buttonDeleteUser);
            panelButtons.Controls.Add(buttonLogout);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Height = 130;
            panelButtons.Location = new Point(0, 80);
            panelButtons.Name = "panelButtons";
            panelButtons.TabIndex = 1;

            // buttonRegisterAdmin
            buttonRegisterAdmin.Location = new Point(20, 15);
            buttonRegisterAdmin.Name = "buttonRegisterAdmin";
            buttonRegisterAdmin.Size = new Size(170, 45);
            buttonRegisterAdmin.TabIndex = 0;
            buttonRegisterAdmin.Text = "Register Admin";
            buttonRegisterAdmin.IconChar = IconChar.UserPlus;
            buttonRegisterAdmin.IconColor = Color.White;
            buttonRegisterAdmin.IconFont = IconFont.Auto;
            buttonRegisterAdmin.BackColor = Color.FromArgb(34, 139, 34);
            buttonRegisterAdmin.ForeColor = Color.White;
            buttonRegisterAdmin.TextImageRelation = TextImageRelation.ImageBeforeText;

            // buttonRegisterCustomer
            buttonRegisterCustomer.Location = new Point(200, 15);
            buttonRegisterCustomer.Name = "buttonRegisterCustomer";
            buttonRegisterCustomer.Size = new Size(170, 45);
            buttonRegisterCustomer.TabIndex = 1;
            buttonRegisterCustomer.Text = "Register Customer";
            buttonRegisterCustomer.IconChar = IconChar.User;
            buttonRegisterCustomer.IconColor = Color.White;
            buttonRegisterCustomer.IconFont = IconFont.Auto;
            buttonRegisterCustomer.BackColor = Color.FromArgb(60, 179, 113);
            buttonRegisterCustomer.ForeColor = Color.White;
            buttonRegisterCustomer.TextImageRelation = TextImageRelation.ImageBeforeText;

            // buttonViewUsers
            buttonViewUsers.Location = new Point(380, 15);
            buttonViewUsers.Name = "buttonViewUsers";
            buttonViewUsers.Size = new Size(170, 45);
            buttonViewUsers.TabIndex = 2;
            buttonViewUsers.Text = "Refresh Users";
            buttonViewUsers.IconChar = IconChar.Sync;
            buttonViewUsers.IconColor = Color.White;
            buttonViewUsers.IconFont = IconFont.Auto;
            buttonViewUsers.BackColor = Color.FromArgb(100, 149, 237);
            buttonViewUsers.ForeColor = Color.White;
            buttonViewUsers.TextImageRelation = TextImageRelation.ImageBeforeText;

            // buttonEditUser
            buttonEditUser.Location = new Point(20, 75);
            buttonEditUser.Name = "buttonEditUser";
            buttonEditUser.Size = new Size(170, 45);
            buttonEditUser.TabIndex = 3;
            buttonEditUser.Text = "Edit User";
            buttonEditUser.IconChar = IconChar.Edit;
            buttonEditUser.IconColor = Color.White;
            buttonEditUser.IconFont = IconFont.Auto;
            buttonEditUser.BackColor = Color.LightBlue;
            buttonEditUser.ForeColor = Color.Black;
            buttonEditUser.TextImageRelation = TextImageRelation.ImageBeforeText;

            // buttonDeleteUser
            buttonDeleteUser.Location = new Point(200, 75);
            buttonDeleteUser.Name = "buttonDeleteUser";
            buttonDeleteUser.Size = new Size(170, 45);
            buttonDeleteUser.TabIndex = 4;
            buttonDeleteUser.Text = "Delete User";
            buttonDeleteUser.IconChar = IconChar.TrashAlt;
            buttonDeleteUser.IconColor = Color.White;
            buttonDeleteUser.IconFont = IconFont.Auto;
            buttonDeleteUser.BackColor = Color.LightCoral;
            buttonDeleteUser.ForeColor = Color.White;
            buttonDeleteUser.TextImageRelation = TextImageRelation.ImageBeforeText;

            // buttonLogout
            buttonLogout.Location = new Point(380, 75);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(170, 45);
            buttonLogout.TabIndex = 5;
            buttonLogout.Text = "Logout";
            buttonLogout.IconChar = IconChar.SignOutAlt;
            buttonLogout.IconColor = Color.White;
            buttonLogout.IconFont = IconFont.Auto;
            buttonLogout.BackColor = Color.FromArgb(220, 53, 69);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.TextImageRelation = TextImageRelation.ImageBeforeText;

            // dataGridViewUsers
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.Location = new Point(0, 210);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(900, 400);
            dataGridViewUsers.TabIndex = 2;

            // AdminDashboard
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 610);
            Controls.Add(dataGridViewUsers);
            Controls.Add(panelButtons);
            Controls.Add(panelTop);
            Name = "AdminDashboard";
            Text = "GreenLife Organic Store - Admin Dashboard";
            Load += AdminDashboard_Load;

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
        }
    }
}
