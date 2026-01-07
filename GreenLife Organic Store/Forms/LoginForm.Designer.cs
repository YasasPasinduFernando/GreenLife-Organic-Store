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
            labelTitle = new Label();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            labelUserType = new Label();
            radioButtonAdmin = new RadioButton();
            radioButtonCustomer = new RadioButton();
            buttonLogin = new IconButton();
            iconLogo = new IconPictureBox();
            linkLabelRegister = new LinkLabel();
            labelRegisterPrompt = new Label();

            panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(iconLogo)).BeginInit();
            SuspendLayout();

            // panelContainer
            panelContainer.BackColor = Color.White;
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
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(500, 600);
            panelContainer.TabIndex = 0;

            // iconLogo
            iconLogo.IconChar = IconChar.Leaf;
            iconLogo.IconColor = Color.FromArgb(34, 139, 34);
            iconLogo.Location = new Point(50, 40);
            iconLogo.Size = new Size(48, 48);
            iconLogo.BackColor = Color.Transparent;
            iconLogo.TabStop = false;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(34, 139, 34);
            labelTitle.Location = new Point(108, 48);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(210, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GreenLife Login";

            // labelEmail
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10F);
            labelEmail.Location = new Point(50, 130);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(52, 19);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email:";

            // textBoxEmail
            textBoxEmail.Font = new Font("Segoe UI", 11F);
            textBoxEmail.Location = new Point(50, 155);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(400, 32);
            textBoxEmail.TabIndex = 2;
            textBoxEmail.Padding = new Padding(8, 5, 8, 5);

            // labelPassword
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 10F);
            labelPassword.Location = new Point(50, 200);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(73, 19);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Password:";

            // textBoxPassword
            textBoxPassword.Font = new Font("Segoe UI", 11F);
            textBoxPassword.Location = new Point(50, 225);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(400, 32);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.Padding = new Padding(8, 5, 8, 5);

            // labelUserType
            labelUserType.AutoSize = true;
            labelUserType.Font = new Font("Segoe UI", 10F);
            labelUserType.Location = new Point(50, 270);
            labelUserType.Name = "labelUserType";
            labelUserType.Size = new Size(76, 19);
            labelUserType.TabIndex = 5;
            labelUserType.Text = "User Type:";

            // radioButtonAdmin
            radioButtonAdmin.AutoSize = true;
            radioButtonAdmin.Font = new Font("Segoe UI", 10F);
            radioButtonAdmin.Location = new Point(50, 295);
            radioButtonAdmin.Name = "radioButtonAdmin";
            radioButtonAdmin.Size = new Size(72, 23);
            radioButtonAdmin.TabIndex = 6;
            radioButtonAdmin.Text = "Admin";
            radioButtonAdmin.UseVisualStyleBackColor = true;

            // radioButtonCustomer
            radioButtonCustomer.AutoSize = true;
            radioButtonCustomer.Checked = true;
            radioButtonCustomer.Font = new Font("Segoe UI", 10F);
            radioButtonCustomer.Location = new Point(180, 295);
            radioButtonCustomer.Name = "radioButtonCustomer";
            radioButtonCustomer.Size = new Size(90, 23);
            radioButtonCustomer.TabIndex = 7;
            radioButtonCustomer.TabStop = true;
            radioButtonCustomer.Text = "Customer";
            radioButtonCustomer.UseVisualStyleBackColor = true;

            // buttonLogin
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
            buttonLogin.Location = new Point(50, 350);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(400, 50);
            buttonLogin.TabIndex = 8;
            buttonLogin.Text = "Login";
            buttonLogin.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;

            // labelRegisterPrompt
            labelRegisterPrompt.AutoSize = true;
            labelRegisterPrompt.Font = new Font("Segoe UI", 9.5F);
            labelRegisterPrompt.Location = new Point(100, 430);
            labelRegisterPrompt.Name = "labelRegisterPrompt";
            labelRegisterPrompt.Size = new Size(179, 17);
            labelRegisterPrompt.TabIndex = 9;
            labelRegisterPrompt.Text = "Don't have an account yet?";

            // linkLabelRegister
            linkLabelRegister.AutoSize = true;
            linkLabelRegister.Font = new Font("Segoe UI", 9.5F);
            linkLabelRegister.LinkColor = Color.FromArgb(34, 139, 34);
            linkLabelRegister.Location = new Point(285, 430);
            linkLabelRegister.Name = "linkLabelRegister";
            linkLabelRegister.Size = new Size(86, 17);
            linkLabelRegister.TabIndex = 10;
            linkLabelRegister.TabStop = true;
            linkLabelRegister.Text = "Register here";
            linkLabelRegister.LinkClicked += linkLabelRegister_LinkClicked;

            // LoginForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 600);
            Controls.Add(panelContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GreenLife Organic Store - Login";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;

            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(iconLogo)).EndInit();
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