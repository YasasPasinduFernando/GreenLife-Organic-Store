namespace GreenLife_Organic_Store.Forms
{
    partial class ForgotPasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblInstructions = new Label();
            this.textBoxEmail = new TextBox();
            this.buttonSendCode = new Button();
            this.progressBar = new ProgressBar();
            this.labelProgress = new Label();
            this.iconEmailStatus = new FontAwesome.Sharp.IconPictureBox();
            this.labelStatus = new Label();
            this.lblHelp = new Label();
            ((System.ComponentModel.ISupportInitialize)this.iconEmailStatus).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(34, 139, 34);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(180, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reset Your Password";
            //
            // lblInstructions
            //
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new Font("Segoe UI", 9F);
            this.lblInstructions.Location = new Point(20, 50);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new Size(380, 15);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "Enter your registered email address and we'll send you a reset code:";
            //
            // textBoxEmail
            //
            this.textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            this.textBoxEmail.Location = new Point(20, 75);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new Size(440, 23);
            this.textBoxEmail.TabIndex = 2;
            //
            // buttonSendCode
            //
            this.buttonSendCode.BackColor = Color.FromArgb(34, 139, 34);
            this.buttonSendCode.Cursor = Cursors.Hand;
            this.buttonSendCode.FlatAppearance.BorderSize = 0;
            this.buttonSendCode.FlatStyle = FlatStyle.Flat;
            this.buttonSendCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.buttonSendCode.ForeColor = Color.White;
            this.buttonSendCode.Location = new Point(20, 115);
            this.buttonSendCode.Name = "buttonSendCode";
            this.buttonSendCode.Size = new Size(150, 35);
            this.buttonSendCode.TabIndex = 3;
            this.buttonSendCode.Text = "Send Reset Code";
            this.buttonSendCode.UseVisualStyleBackColor = false;
            this.buttonSendCode.Click += this.ButtonSendCode_Click;
            //
            // progressBar
            //
            this.progressBar.Location = new Point(190, 120);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(270, 25);
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            //
            // labelProgress
            //
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new Font("Segoe UI", 9F);
            this.labelProgress.ForeColor = Color.Black;
            this.labelProgress.Location = new Point(190, 145);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new Size(0, 15);
            this.labelProgress.TabIndex = 5;
            this.labelProgress.Visible = false;
            //
            // iconEmailStatus
            //
            this.iconEmailStatus.BackColor = Color.Transparent;
            this.iconEmailStatus.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.iconEmailStatus.IconColor = Color.FromArgb(34, 139, 34);
            this.iconEmailStatus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconEmailStatus.Location = new Point(20, 170);
            this.iconEmailStatus.Name = "iconEmailStatus";
            this.iconEmailStatus.Size = new Size(20, 20);
            this.iconEmailStatus.TabIndex = 6;
            this.iconEmailStatus.TabStop = false;
            //
            // labelStatus
            //
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = Color.Transparent;
            this.labelStatus.Font = new Font("Segoe UI", 9F);
            this.labelStatus.ForeColor = Color.FromArgb(34, 139, 34);
            this.labelStatus.Location = new Point(48, 168);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new Size(155, 15);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Email service is configured";
            //
            // lblHelp
            //
            this.lblHelp.AutoSize = true;
            this.lblHelp.Font = new Font("Segoe UI", 8F);
            this.lblHelp.ForeColor = Color.Gray;
            this.lblHelp.Location = new Point(20, 230);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new Size(280, 13);
            this.lblHelp.TabIndex = 8;
            this.lblHelp.Text = "A reset code will be sent to your registered email.";
            //
            // ForgotPasswordForm
            //
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.ClientSize = new Size(464, 281);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.buttonSendCode);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.iconEmailStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.lblHelp);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ForgotPasswordForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Forgot Password";
            ((System.ComponentModel.ISupportInitialize)this.iconEmailStatus).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblInstructions;
        private TextBox textBoxEmail;
        private Button buttonSendCode;
        private ProgressBar progressBar;
        private Label labelProgress;
        private FontAwesome.Sharp.IconPictureBox iconEmailStatus;
        private Label labelStatus;
        private Label lblHelp;
    }
}
