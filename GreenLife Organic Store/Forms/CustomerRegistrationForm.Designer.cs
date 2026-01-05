namespace GreenLife_Organic_Store.Forms
{
    partial class CustomerRegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelContainer;
        private Label labelTitle;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelPhone;
        private TextBox textBoxPhone;
        private Label labelAge;
        private TextBox textBoxAge;
        private Label labelAddress;
        private TextBox textBoxAddress;
        private Label labelGender;
        private RadioButton radioButtonMale;
        private RadioButton radioButtonFemale;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Label labelConfirmPassword;
        private TextBox textBoxConfirmPassword;
        private Button buttonSave;
        private Button buttonCancel;

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
            labelName = new Label();
            textBoxName = new TextBox();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelAge = new Label();
            textBoxAge = new TextBox();
            labelAddress = new Label();
            textBoxAddress = new TextBox();
            labelGender = new Label();
            radioButtonMale = new RadioButton();
            radioButtonFemale = new RadioButton();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            labelConfirmPassword = new Label();
            textBoxConfirmPassword = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();

            panelContainer.SuspendLayout();
            SuspendLayout();

            // panelContainer
            panelContainer.AutoScroll = true;
            panelContainer.Controls.Add(labelTitle);
            panelContainer.Controls.Add(labelEmail);
            panelContainer.Controls.Add(textBoxEmail);
            panelContainer.Controls.Add(labelName);
            panelContainer.Controls.Add(textBoxName);
            panelContainer.Controls.Add(labelPhone);
            panelContainer.Controls.Add(textBoxPhone);
            panelContainer.Controls.Add(labelAge);
            panelContainer.Controls.Add(textBoxAge);
            panelContainer.Controls.Add(labelAddress);
            panelContainer.Controls.Add(textBoxAddress);
            panelContainer.Controls.Add(labelGender);
            panelContainer.Controls.Add(radioButtonMale);
            panelContainer.Controls.Add(radioButtonFemale);
            panelContainer.Controls.Add(labelPassword);
            panelContainer.Controls.Add(textBoxPassword);
            panelContainer.Controls.Add(labelConfirmPassword);
            panelContainer.Controls.Add(textBoxConfirmPassword);
            panelContainer.Controls.Add(buttonSave);
            panelContainer.Controls.Add(buttonCancel);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(500, 700);
            panelContainer.TabIndex = 0;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(30, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(270, 28);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Register New Customer";

            // labelEmail
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(30, 65);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(56, 20);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email:";

            // textBoxEmail
            textBoxEmail.Location = new Point(30, 90);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(420, 28);
            textBoxEmail.TabIndex = 2;

            // labelName
            labelName.AutoSize = true;
            labelName.Location = new Point(30, 125);
            labelName.Name = "labelName";
            labelName.Size = new Size(53, 20);
            labelName.TabIndex = 3;
            labelName.Text = "Name:";

            // textBoxName
            textBoxName.Location = new Point(30, 150);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(420, 28);
            textBoxName.TabIndex = 4;

            // labelPhone
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(30, 185);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(62, 20);
            labelPhone.TabIndex = 5;
            labelPhone.Text = "Phone:";

            // textBoxPhone
            textBoxPhone.Location = new Point(30, 210);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(420, 28);
            textBoxPhone.TabIndex = 6;

            // labelAge
            labelAge.AutoSize = true;
            labelAge.Location = new Point(30, 245);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(40, 20);
            labelAge.TabIndex = 7;
            labelAge.Text = "Age:";

            // textBoxAge
            textBoxAge.Location = new Point(30, 270);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.Size = new Size(420, 28);
            textBoxAge.TabIndex = 8;

            // labelAddress
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(30, 305);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(73, 20);
            labelAddress.TabIndex = 9;
            labelAddress.Text = "Address:";

            // textBoxAddress
            textBoxAddress.Location = new Point(30, 330);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(420, 60);
            textBoxAddress.TabIndex = 10;
            textBoxAddress.Multiline = true;

            // labelGender
            labelGender.AutoSize = true;
            labelGender.Location = new Point(30, 400);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(65, 20);
            labelGender.TabIndex = 11;
            labelGender.Text = "Gender:";

            // radioButtonMale
            radioButtonMale.AutoSize = true;
            radioButtonMale.Location = new Point(30, 425);
            radioButtonMale.Name = "radioButtonMale";
            radioButtonMale.Size = new Size(63, 24);
            radioButtonMale.TabIndex = 12;
            radioButtonMale.Text = "Male";

            // radioButtonFemale
            radioButtonFemale.AutoSize = true;
            radioButtonFemale.Location = new Point(150, 425);
            radioButtonFemale.Name = "radioButtonFemale";
            radioButtonFemale.Size = new Size(83, 24);
            radioButtonFemale.TabIndex = 13;
            radioButtonFemale.Text = "Female";

            // labelPassword
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(30, 465);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(82, 20);
            labelPassword.TabIndex = 14;
            labelPassword.Text = "Password:";

            // textBoxPassword
            textBoxPassword.Location = new Point(30, 490);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(420, 28);
            textBoxPassword.TabIndex = 15;
            textBoxPassword.UseSystemPasswordChar = true;

            // labelConfirmPassword
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Location = new Point(30, 525);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(139, 20);
            labelConfirmPassword.TabIndex = 16;
            labelConfirmPassword.Text = "Confirm Password:";

            // textBoxConfirmPassword
            textBoxConfirmPassword.Location = new Point(30, 550);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(420, 28);
            textBoxConfirmPassword.TabIndex = 17;
            textBoxConfirmPassword.UseSystemPasswordChar = true;

            // buttonSave
            buttonSave.Location = new Point(30, 600);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(190, 45);
            buttonSave.TabIndex = 18;
            buttonSave.Text = "Register";
            buttonSave.Click += buttonSave_Click;

            // buttonCancel
            buttonCancel.Location = new Point(260, 600);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(190, 45);
            buttonCancel.TabIndex = 19;
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;

            // CustomerRegistrationForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 700);
            Controls.Add(panelContainer);
            Name = "CustomerRegistrationForm";
            Text = "Register New Customer";

            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ResumeLayout(false);
        }
    }
}
