namespace GreenLife_Organic_Store.Forms
{
    partial class CustomerDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelTop;
        private Label labelWelcome;
        private Panel panelInfo;
        private Label labelInfoTitle;
        private Label labelInfoContent;
        private Button buttonEditProfile;
        private Button buttonChangePassword;
        private Button buttonLogout;

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
            panelInfo = new Panel();
            labelInfoTitle = new Label();
            labelInfoContent = new Label();
            buttonEditProfile = new Button();
            buttonChangePassword = new Button();
            buttonLogout = new Button();

            panelTop.SuspendLayout();
            panelInfo.SuspendLayout();
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
            labelWelcome.Location = new Point(30, 25);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(250, 38);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome, Customer!";

            // panelInfo
            panelInfo.Controls.Add(labelInfoTitle);
            panelInfo.Controls.Add(labelInfoContent);
            panelInfo.Location = new Point(30, 100);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(500, 300);
            panelInfo.TabIndex = 1;

            // labelInfoTitle
            labelInfoTitle.AutoSize = true;
            labelInfoTitle.Location = new Point(15, 15);
            labelInfoTitle.Name = "labelInfoTitle";
            labelInfoTitle.Size = new Size(168, 20);
            labelInfoTitle.TabIndex = 0;
            labelInfoTitle.Text = "Your Profile Information:";

            // labelInfoContent
            labelInfoContent.AutoSize = true;
            labelInfoContent.Location = new Point(15, 45);
            labelInfoContent.Name = "labelInfoContent";
            labelInfoContent.Size = new Size(50, 20);
            labelInfoContent.TabIndex = 1;
            labelInfoContent.Text = "Label";

            // buttonEditProfile
            buttonEditProfile.Location = new Point(30, 420);
            buttonEditProfile.Name = "buttonEditProfile";
            buttonEditProfile.Size = new Size(150, 45);
            buttonEditProfile.TabIndex = 2;
            buttonEditProfile.Text = "Edit Profile";
            buttonEditProfile.Click += buttonEditProfile_Click;

            // buttonChangePassword
            buttonChangePassword.Location = new Point(190, 420);
            buttonChangePassword.Name = "buttonChangePassword";
            buttonChangePassword.Size = new Size(150, 45);
            buttonChangePassword.TabIndex = 3;
            buttonChangePassword.Text = "Change Password";
            buttonChangePassword.Click += buttonChangePassword_Click;

            // buttonLogout
            buttonLogout.Location = new Point(350, 420);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(150, 45);
            buttonLogout.TabIndex = 4;
            buttonLogout.Text = "Logout";
            buttonLogout.Click += buttonLogout_Click;

            // CustomerDashboard
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 500);
            Controls.Add(buttonLogout);
            Controls.Add(buttonChangePassword);
            Controls.Add(buttonEditProfile);
            Controls.Add(panelInfo);
            Controls.Add(panelTop);
            Name = "CustomerDashboard";
            Text = "GreenLife Organic Store - Customer Dashboard";
            Load += CustomerDashboard_Load;

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            ResumeLayout(false);
        }
    }
}
