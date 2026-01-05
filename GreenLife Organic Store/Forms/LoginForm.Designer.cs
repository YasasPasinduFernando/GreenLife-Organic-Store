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
        private Button buttonLogin;
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
            buttonLogin = new Button();
            linkLabelRegister = new LinkLabel();
            labelRegisterPrompt = new Label();

            panelContainer.SuspendLayout();
            SuspendLayout();

            // panelContainer
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

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(50, 40);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(153, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GreenLife Login";

            // labelEmail
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(50, 100);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(56, 20);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email:";

            // textBoxEmail
            textBoxEmail.Location = new Point(50, 125);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(400, 30);
            textBoxEmail.TabIndex = 2;
            textBoxEmail.Padding = new Padding(5);

            // labelPassword
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(50, 170);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(82, 20);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Password:";

            // textBoxPassword
            textBoxPassword.Location = new Point(50, 195);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(400, 30);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.Padding = new Padding(5);

            // labelUserType
            labelUserType.AutoSize = true;
            labelUserType.Location = new Point(50, 240);
            labelUserType.Name = "labelUserType";
            labelUserType.Size = new Size(84, 20);
            labelUserType.TabIndex = 5;
            labelUserType.Text = "User Type:";

            // radioButtonAdmin
            radioButtonAdmin.AutoSize = true;
            radioButtonAdmin.Location = new Point(50, 265);
            radioButtonAdmin.Name = "radioButtonAdmin";
            radioButtonAdmin.Size = new Size(84, 24);
            radioButtonAdmin.TabIndex = 6;
            radioButtonAdmin.Text = "Admin";

            // radioButtonCustomer
            radioButtonCustomer.AutoSize = true;
            radioButtonCustomer.Location = new Point(200, 265);
            radioButtonCustomer.Name = "radioButtonCustomer";
            radioButtonCustomer.Size = new Size(100, 24);
            radioButtonCustomer.TabIndex = 7;
            radioButtonCustomer.Text = "Customer";

            // buttonLogin
            buttonLogin.Location = new Point(50, 330);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(400, 50);
            buttonLogin.TabIndex = 8;
            buttonLogin.Text = "Login";
            buttonLogin.Click += buttonLogin_Click;

            // labelRegisterPrompt
            labelRegisterPrompt.AutoSize = true;
            labelRegisterPrompt.Location = new Point(50, 410);
            labelRegisterPrompt.Name = "labelRegisterPrompt";
            labelRegisterPrompt.Size = new Size(230, 20);
            labelRegisterPrompt.TabIndex = 9;
            labelRegisterPrompt.Text = "Don't have an account yet?";

            // linkLabelRegister
            linkLabelRegister.AutoSize = true;
            linkLabelRegister.Location = new Point(285, 410);
            linkLabelRegister.Name = "linkLabelRegister";
            linkLabelRegister.Size = new Size(86, 20);
            linkLabelRegister.TabIndex = 10;
            linkLabelRegister.TabStop = true;
            linkLabelRegister.Text = "Register here";
            linkLabelRegister.LinkClicked += linkLabelRegister_LinkClicked;

            // LoginForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 600);
            Controls.Add(panelContainer);
            Name = "LoginForm";
            Text = "GreenLife Organic Store - Login";
            FormClosing += LoginForm_FormClosing;
            Load += LoginForm_Load;

            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
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
