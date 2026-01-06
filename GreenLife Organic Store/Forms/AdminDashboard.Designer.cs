namespace GreenLife_Organic_Store.Forms
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label labelWelcome;
        private Panel panelButtons;
        private Button buttonRegisterAdmin;
        private Button buttonRegisterCustomer;
        private Button buttonViewUsers;
        private Button buttonEditUser;
        private Button buttonDeleteUser;
        private Button buttonLogout;
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
            buttonRegisterAdmin = new Button();
            buttonRegisterCustomer = new Button();
            buttonViewUsers = new Button();
            buttonEditUser = new Button();
            buttonDeleteUser = new Button();
            buttonLogout = new Button();
            dataGridViewUsers = new DataGridView();

            panelTop.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.FromArgb(34, 139, 34);
            panelTop.Controls.Add(labelWelcome);
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 80;
            panelTop.Name = "panelTop";
            panelTop.TabIndex = 0;

            // labelWelcome
            labelWelcome.AutoSize = true;
            labelWelcome.ForeColor = Color.White;
            labelWelcome.Location = new Point(20, 25);
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

            // buttonRegisterCustomer
            buttonRegisterCustomer.Location = new Point(200, 15);
            buttonRegisterCustomer.Name = "buttonRegisterCustomer";
            buttonRegisterCustomer.Size = new Size(170, 45);
            buttonRegisterCustomer.TabIndex = 1;
            buttonRegisterCustomer.Text = "Register Customer";

            // buttonViewUsers
            buttonViewUsers.Location = new Point(380, 15);
            buttonViewUsers.Name = "buttonViewUsers";
            buttonViewUsers.Size = new Size(170, 45);
            buttonViewUsers.TabIndex = 2;
            buttonViewUsers.Text = "Refresh Users";

            // buttonEditUser
            buttonEditUser.Location = new Point(20, 75);
            buttonEditUser.Name = "buttonEditUser";
            buttonEditUser.Size = new Size(170, 45);
            buttonEditUser.TabIndex = 3;
            buttonEditUser.Text = "Edit User";

            // buttonDeleteUser
            buttonDeleteUser.Location = new Point(200, 75);
            buttonDeleteUser.Name = "buttonDeleteUser";
            buttonDeleteUser.Size = new Size(170, 45);
            buttonDeleteUser.TabIndex = 4;
            buttonDeleteUser.Text = "Delete User";

            // buttonLogout
            buttonLogout.Location = new Point(380, 75);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(170, 45);
            buttonLogout.TabIndex = 5;
            buttonLogout.Text = "Logout";

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
