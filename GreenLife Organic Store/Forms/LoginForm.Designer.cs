using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelContainer;
        private Label labelTitle;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelUserType;
        private RadioButton radioButtonAdmin;
        private RadioButton radioButtonCustomer;
        private IconButton buttonLogin;
        private IconPictureBox iconLogo;
        private LinkLabel linkLabelRegister;
        private LinkLabel linkLabelForgot;
        private Label labelRegisterPrompt;

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
            panelContainer = new Panel();
            iconLogo = new IconPictureBox();
            labelTitle = new Label();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            linkLabelForgot = new LinkLabel();
            labelUserType = new Label();
            radioButtonAdmin = new RadioButton();
            radioButtonCustomer = new RadioButton();
            buttonLogin = new IconButton();
            labelRegisterPrompt = new Label();
            linkLabelRegister = new LinkLabel();
            panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconLogo).BeginInit();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.White;
            panelContainer.Controls.Add(linkLabelForgot);
            panelContainer.Controls.Add(iconLogo);
            panelContainer.Controls.Add(labelTitle);
            panelContainer.Controls.Add(labelEmail);
            panelContainer.Controls.Add(textBoxEmail);
            panelContainer.Controls.Add(labelPassword);
            panelContainer.Controls.Add(textBoxPassword);
            panelContainer.Controls.Add(labelUserType);
            panelContainer.Controls.Add(radioButtonAdmin);
            panelContainer.Controls.Add(radioButtonCustomer);
            panelContainer.Controls.Add(buttonLogin);
            panelContainer.Controls.Add(labelRegisterPrompt);
            panelContainer.Controls.Add(linkLabelRegister);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Margin = new Padding(3, 2, 3, 2);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(438, 500);
            panelContainer.TabIndex = 0;
            // 
            // iconLogo
            // 
            iconLogo.BackColor = Color.Transparent;
            iconLogo.ForeColor = Color.FromArgb(34, 139, 34);
            iconLogo.IconChar = IconChar.Leaf;
            iconLogo.IconColor = Color.FromArgb(34, 139, 34);
            iconLogo.IconFont = IconFont.Auto;
            iconLogo.IconSize = 36;
            iconLogo.Location = new Point(44, 30);
            iconLogo.Margin = new Padding(3, 2, 3, 2);
            iconLogo.Name = "iconLogo";
            iconLogo.Size = new Size(42, 36);
            iconLogo.TabIndex = 0;
            iconLogo.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(34, 139, 34);
            labelTitle.Location = new Point(92, 29);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(219, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GreenLife Login";
            labelTitle.Click += labelTitle_Click;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10F);
            labelEmail.Location = new Point(44, 95);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(44, 19);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new Font("Segoe UI", 11F);
            textBoxEmail.Location = new Point(44, 116);
            textBoxEmail.Margin = new Padding(3, 2, 3, 2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(350, 27);
            textBoxEmail.TabIndex = 2;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 10F);
            labelPassword.Location = new Point(44, 155);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(70, 19);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 11F);
            textBoxPassword.Location = new Point(44, 176);
            textBoxPassword.Margin = new Padding(3, 2, 3, 2);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(350, 27);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // linkLabelForgot
            // 
            linkLabelForgot.AutoSize = true;
            linkLabelForgot.Font = new Font("Segoe UI", 9F);
            linkLabelForgot.LinkColor = Color.FromArgb(34, 139, 34);
            linkLabelForgot.Location = new Point(280, 210);
            linkLabelForgot.Name = "linkLabelForgot";
            linkLabelForgot.Size = new Size(114, 15);
            linkLabelForgot.TabIndex = 5;
            linkLabelForgot.TabStop = true;
            linkLabelForgot.Text = "Forgot password?";
            linkLabelForgot.LinkClicked += linkLabelForgot_LinkClicked;
            // 
            // labelUserType
            // 
            labelUserType.AutoSize = true;
            labelUserType.Font = new Font("Segoe UI", 10F);
            labelUserType.Location = new Point(44, 240);
            labelUserType.Name = "labelUserType";
            labelUserType.Size = new Size(72, 19);
            labelUserType.TabIndex = 6;
            labelUserType.Text = "User Type:";
            // 
            // radioButtonAdmin
            // 
            radioButtonAdmin.AutoSize = true;
            radioButtonAdmin.Font = new Font("Segoe UI", 10F);
            radioButtonAdmin.Location = new Point(61, 273);
            radioButtonAdmin.Margin = new Padding(3, 2, 3, 2);
            radioButtonAdmin.Name = "radioButtonAdmin";
            radioButtonAdmin.Size = new Size(67, 23);
            radioButtonAdmin.TabIndex = 7;
            radioButtonAdmin.Text = "Admin";
            radioButtonAdmin.UseVisualStyleBackColor = true;
            radioButtonAdmin.CheckedChanged += radioButtonAdmin_CheckedChanged;
            // 
            // radioButtonCustomer
            // 
            radioButtonCustomer.AutoSize = true;
            radioButtonCustomer.Checked = true;
            radioButtonCustomer.Font = new Font("Segoe UI", 10F);
            radioButtonCustomer.Location = new Point(224, 273);
            radioButtonCustomer.Margin = new Padding(3, 2, 3, 2);
            radioButtonCustomer.Name = "radioButtonCustomer";
            radioButtonCustomer.Size = new Size(87, 23);
            radioButtonCustomer.TabIndex = 8;
            radioButtonCustomer.TabStop = true;
            radioButtonCustomer.Text = "Customer";
            radioButtonCustomer.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(34, 139, 34);
            buttonLogin.Cursor = Cursors.Hand;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.IconChar = IconChar.RightToBracket;
            buttonLogin.IconColor = Color.White;
            buttonLogin.IconFont = IconFont.Auto;
            buttonLogin.IconSize = 24;
            buttonLogin.Location = new Point(44, 320);
            buttonLogin.Margin = new Padding(3, 2, 3, 2);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(350, 42);
            buttonLogin.TabIndex = 9;
            buttonLogin.Text = "Login";
            buttonLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // labelRegisterPrompt
            // 
            labelRegisterPrompt.AutoSize = true;
            labelRegisterPrompt.Font = new Font("Segoe UI", 9.5F);
            labelRegisterPrompt.Location = new Point(85, 410);
            labelRegisterPrompt.Name = "labelRegisterPrompt";
            labelRegisterPrompt.Size = new Size(164, 17);
            labelRegisterPrompt.TabIndex = 10;
            labelRegisterPrompt.Text = "Don't have an account yet?";
            // 
            // linkLabelRegister
            // 
            linkLabelRegister.AutoSize = true;
            linkLabelRegister.Font = new Font("Segoe UI", 9.5F);
            linkLabelRegister.LinkColor = Color.FromArgb(34, 139, 34);
            linkLabelRegister.Location = new Point(246, 410);
            linkLabelRegister.Name = "linkLabelRegister";
            linkLabelRegister.Size = new Size(86, 17);
            linkLabelRegister.TabIndex = 11;
            linkLabelRegister.TabStop = true;
            linkLabelRegister.Text = "Register here";
            linkLabelRegister.LinkClicked += linkLabelRegister_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(438, 500);
            Controls.Add(panelContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GreenLife Organic Store - Login";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;
            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconLogo).EndInit();
            ResumeLayout(false);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}