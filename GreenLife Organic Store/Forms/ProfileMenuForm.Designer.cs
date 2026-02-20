using FontAwesome.Sharp;

namespace GreenLife_Organic_Store.Forms
{
    partial class ProfileMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private IconButton buttonEditProfile;
        private IconButton buttonMyOrders;
        private IconButton buttonReviewOrders;
        private IconButton buttonChangePassword;
        private IconButton buttonLogout;

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
            buttonEditProfile = new IconButton();
            buttonMyOrders = new IconButton();
            buttonReviewOrders = new IconButton();
            buttonChangePassword = new IconButton();
            buttonLogout = new IconButton();
            SuspendLayout();
            // buttonEditProfile
            buttonEditProfile.BackColor = Color.FromArgb(46, 204, 113);
            buttonEditProfile.Cursor = Cursors.Hand;
            buttonEditProfile.FlatAppearance.BorderSize = 0;
            buttonEditProfile.FlatStyle = FlatStyle.Flat;
            buttonEditProfile.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonEditProfile.ForeColor = Color.White;
            buttonEditProfile.IconChar = IconChar.UserEdit;
            buttonEditProfile.IconColor = Color.White;
            buttonEditProfile.IconSize = 22;
            buttonEditProfile.Location = new Point(30, 25);
            buttonEditProfile.Name = "buttonEditProfile";
            buttonEditProfile.Size = new Size(240, 50);
            buttonEditProfile.TabIndex = 0;
            buttonEditProfile.Text = "Edit Profile";
            buttonEditProfile.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonEditProfile.UseVisualStyleBackColor = false;
            buttonEditProfile.Click += buttonEditProfile_Click;
            // buttonMyOrders
            buttonMyOrders.BackColor = Color.FromArgb(52, 152, 219);
            buttonMyOrders.Cursor = Cursors.Hand;
            buttonMyOrders.FlatAppearance.BorderSize = 0;
            buttonMyOrders.FlatStyle = FlatStyle.Flat;
            buttonMyOrders.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonMyOrders.ForeColor = Color.White;
            buttonMyOrders.IconChar = IconChar.ShoppingBag;
            buttonMyOrders.IconColor = Color.White;
            buttonMyOrders.IconSize = 22;
            buttonMyOrders.Location = new Point(30, 85);
            buttonMyOrders.Name = "buttonMyOrders";
            buttonMyOrders.Size = new Size(240, 50);
            buttonMyOrders.TabIndex = 1;
            buttonMyOrders.Text = "My Orders";
            buttonMyOrders.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonMyOrders.UseVisualStyleBackColor = false;
            buttonMyOrders.Click += buttonMyOrders_Click;
            // buttonReviewOrders
            buttonReviewOrders.BackColor = Color.FromArgb(241, 196, 15);
            buttonReviewOrders.Cursor = Cursors.Hand;
            buttonReviewOrders.FlatAppearance.BorderSize = 0;
            buttonReviewOrders.FlatStyle = FlatStyle.Flat;
            buttonReviewOrders.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonReviewOrders.ForeColor = Color.White;
            buttonReviewOrders.IconChar = IconChar.Star;
            buttonReviewOrders.IconColor = Color.White;
            buttonReviewOrders.IconSize = 22;
            buttonReviewOrders.Location = new Point(30, 145);
            buttonReviewOrders.Name = "buttonReviewOrders";
            buttonReviewOrders.Size = new Size(240, 50);
            buttonReviewOrders.TabIndex = 2;
            buttonReviewOrders.Text = "Review Orders";
            buttonReviewOrders.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonReviewOrders.UseVisualStyleBackColor = false;
            buttonReviewOrders.Click += buttonReviewOrders_Click;
            // buttonChangePassword
            buttonChangePassword.BackColor = Color.FromArgb(155, 89, 182);
            buttonChangePassword.Cursor = Cursors.Hand;
            buttonChangePassword.FlatAppearance.BorderSize = 0;
            buttonChangePassword.FlatStyle = FlatStyle.Flat;
            buttonChangePassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonChangePassword.ForeColor = Color.White;
            buttonChangePassword.IconChar = IconChar.Key;
            buttonChangePassword.IconColor = Color.White;
            buttonChangePassword.IconSize = 22;
            buttonChangePassword.Location = new Point(30, 205);
            buttonChangePassword.Name = "buttonChangePassword";
            buttonChangePassword.Size = new Size(240, 50);
            buttonChangePassword.TabIndex = 3;
            buttonChangePassword.Text = "Change Password";
            buttonChangePassword.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonChangePassword.UseVisualStyleBackColor = false;
            buttonChangePassword.Click += buttonChangePassword_Click;
            // buttonLogout
            buttonLogout.BackColor = Color.FromArgb(220, 53, 69);
            buttonLogout.Cursor = Cursors.Hand;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.IconChar = IconChar.SignOutAlt;
            buttonLogout.IconColor = Color.White;
            buttonLogout.IconSize = 22;
            buttonLogout.Location = new Point(30, 265);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(240, 50);
            buttonLogout.TabIndex = 4;
            buttonLogout.Text = "Logout";
            buttonLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // ProfileMenuForm
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(300, 345);
            Controls.Add(buttonLogout);
            Controls.Add(buttonChangePassword);
            Controls.Add(buttonReviewOrders);
            Controls.Add(buttonMyOrders);
            Controls.Add(buttonEditProfile);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProfileMenuForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Profile Menu";
            ResumeLayout(false);
        }
    }
}
