namespace GreenLife_Organic_Store.Forms
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelContainer;
        private Label labelTitle;
        private Label labelNewPassword;
        private TextBox textBoxNewPassword;
        private Label labelConfirmPassword;
        private TextBox textBoxConfirmPassword;
        private Button buttonChange;
        private Button buttonCancel;
        private Label labelInfo;

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
            labelInfo = new Label();
            labelNewPassword = new Label();
            textBoxNewPassword = new TextBox();
            labelConfirmPassword = new Label();
            textBoxConfirmPassword = new TextBox();
            buttonChange = new Button();
            buttonCancel = new Button();

            panelContainer.SuspendLayout();
            SuspendLayout();

            // panelContainer
            panelContainer.AutoScroll = true;
            panelContainer.Controls.Add(labelTitle);
            panelContainer.Controls.Add(labelInfo);
            panelContainer.Controls.Add(labelNewPassword);
            panelContainer.Controls.Add(textBoxNewPassword);
            panelContainer.Controls.Add(labelConfirmPassword);
            panelContainer.Controls.Add(textBoxConfirmPassword);
            panelContainer.Controls.Add(buttonChange);
            panelContainer.Controls.Add(buttonCancel);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(500, 400);
            panelContainer.TabIndex = 0;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(30, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(200, 28);
            labelTitle.TabIndex = 0;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.Text = "Change Password";

            // labelInfo
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(30, 65);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(300, 40);
            labelInfo.TabIndex = 1;
            labelInfo.Text = "Please enter your new password below.";

            // labelNewPassword
            labelNewPassword.AutoSize = true;
            labelNewPassword.Location = new Point(30, 120);
            labelNewPassword.Name = "labelNewPassword";
            labelNewPassword.Size = new Size(110, 20);
            labelNewPassword.TabIndex = 2;
            labelNewPassword.Text = "New Password:";

            // textBoxNewPassword
            textBoxNewPassword.Location = new Point(30, 145);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.Size = new Size(420, 28);
            textBoxNewPassword.TabIndex = 3;
            textBoxNewPassword.UseSystemPasswordChar = true;
            textBoxNewPassword.BorderStyle = BorderStyle.FixedSingle;

            // labelConfirmPassword
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Location = new Point(30, 180);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(139, 20);
            labelConfirmPassword.TabIndex = 4;
            labelConfirmPassword.Text = "Confirm Password:";

            // textBoxConfirmPassword
            textBoxConfirmPassword.Location = new Point(30, 205);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(420, 28);
            textBoxConfirmPassword.TabIndex = 5;
            textBoxConfirmPassword.UseSystemPasswordChar = true;
            textBoxConfirmPassword.BorderStyle = BorderStyle.FixedSingle;

            // buttonChange
            buttonChange.Location = new Point(30, 270);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(190, 45);
            buttonChange.TabIndex = 6;
            buttonChange.Text = "Change Password";
            buttonChange.Click += buttonChange_Click;

            // buttonCancel
            buttonCancel.Location = new Point(260, 270);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(190, 45);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;

            // ChangePasswordForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 350);
            Controls.Add(panelContainer);
            Name = "ChangePasswordForm";
            Text = "Change Password";

            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ResumeLayout(false);
        }
    }
}
