using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class ResetPasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelEmail = new Label();
            this.lblCode = new Label();
            this.textBoxCode = new TextBox();
            this.lblNew = new Label();
            this.textBoxNewPassword = new TextBox();
            this.lblConfirm = new Label();
            this.textBoxConfirmPassword = new TextBox();
            this.buttonResetPassword = new IconButton();
            this.SuspendLayout();
            // labelEmail
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new Point(20, 20);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new Size(100, 15);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "Email: (set at runtime)";
            // lblCode
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new Point(20, 55);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new Size(62, 15);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Reset Code:";
            // textBoxCode
            this.textBoxCode.Location = new Point(20, 75);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new Size(360, 23);
            this.textBoxCode.TabIndex = 2;
            // lblNew
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new Point(20, 110);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new Size(84, 15);
            this.lblNew.TabIndex = 3;
            this.lblNew.Text = "New Password:";
            // textBoxNewPassword
            this.textBoxNewPassword.Location = new Point(20, 130);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new Size(360, 23);
            this.textBoxNewPassword.TabIndex = 4;
            this.textBoxNewPassword.UseSystemPasswordChar = true;
            // lblConfirm
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new Point(20, 165);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new Size(104, 15);
            this.lblConfirm.TabIndex = 5;
            this.lblConfirm.Text = "Confirm Password:";
            // textBoxConfirmPassword
            this.textBoxConfirmPassword.Location = new Point(20, 185);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new Size(360, 23);
            this.textBoxConfirmPassword.TabIndex = 6;
            this.textBoxConfirmPassword.UseSystemPasswordChar = true;
            // buttonResetPassword
            this.buttonResetPassword.BackColor = Color.FromArgb(34, 139, 34);
            this.buttonResetPassword.Cursor = Cursors.Hand;
            this.buttonResetPassword.FlatAppearance.BorderSize = 0;
            this.buttonResetPassword.FlatStyle = FlatStyle.Flat;
            this.buttonResetPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.buttonResetPassword.ForeColor = Color.White;
            this.buttonResetPassword.IconChar = IconChar.Key;
            this.buttonResetPassword.IconColor = Color.White;
            this.buttonResetPassword.IconSize = 18;
            this.buttonResetPassword.Location = new Point(20, 225);
            this.buttonResetPassword.Name = "buttonResetPassword";
            this.buttonResetPassword.Padding = new Padding(8, 0, 0, 0);
            this.buttonResetPassword.Size = new Size(150, 36);
            this.buttonResetPassword.TabIndex = 7;
            this.buttonResetPassword.Text = "Reset Password";
            this.buttonResetPassword.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.buttonResetPassword.UseVisualStyleBackColor = false;
            this.buttonResetPassword.Click += this.ButtonResetPassword_Click;
            // ResetPasswordForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(404, 284);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.buttonResetPassword);
            this.Name = "ResetPasswordForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Reset Password";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label labelEmail;
        private Label lblCode;
        private TextBox textBoxCode;
        private Label lblNew;
        private TextBox textBoxNewPassword;
        private Label lblConfirm;
        private TextBox textBoxConfirmPassword;
        private IconButton buttonResetPassword;
    }
}
