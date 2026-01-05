namespace GreenLife_Organic_Store.Forms
{
    partial class CustomerProfileEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelContainer;
        private Label labelTitle;
        private Label labelEmail;
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
            buttonSave = new Button();
            buttonCancel = new Button();

            panelContainer.SuspendLayout();
            SuspendLayout();

            // panelContainer
            panelContainer.AutoScroll = true;
            panelContainer.Controls.Add(labelTitle);
            panelContainer.Controls.Add(labelEmail);
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
            panelContainer.Controls.Add(buttonSave);
            panelContainer.Controls.Add(buttonCancel);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(500, 600);
            panelContainer.TabIndex = 0;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(30, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(180, 28);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Edit Your Profile";

            // labelEmail
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(30, 65);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(100, 20);
            labelEmail.TabIndex = 1;
            labelEmail.Text = "Email:";

            // labelName
            labelName.AutoSize = true;
            labelName.Location = new Point(30, 95);
            labelName.Name = "labelName";
            labelName.Size = new Size(53, 20);
            labelName.TabIndex = 2;
            labelName.Text = "Name:";

            // textBoxName
            textBoxName.Location = new Point(30, 120);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(420, 28);
            textBoxName.TabIndex = 3;

            // labelPhone
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(30, 155);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(62, 20);
            labelPhone.TabIndex = 4;
            labelPhone.Text = "Phone:";

            // textBoxPhone
            textBoxPhone.Location = new Point(30, 180);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(420, 28);
            textBoxPhone.TabIndex = 5;

            // labelAge
            labelAge.AutoSize = true;
            labelAge.Location = new Point(30, 215);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(40, 20);
            labelAge.TabIndex = 6;
            labelAge.Text = "Age:";

            // textBoxAge
            textBoxAge.Location = new Point(30, 240);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.Size = new Size(420, 28);
            textBoxAge.TabIndex = 7;

            // labelAddress
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(30, 275);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(73, 20);
            labelAddress.TabIndex = 8;
            labelAddress.Text = "Address:";

            // textBoxAddress
            textBoxAddress.Location = new Point(30, 300);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(420, 60);
            textBoxAddress.TabIndex = 9;
            textBoxAddress.Multiline = true;

            // labelGender
            labelGender.AutoSize = true;
            labelGender.Location = new Point(30, 370);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(65, 20);
            labelGender.TabIndex = 10;
            labelGender.Text = "Gender:";

            // radioButtonMale
            radioButtonMale.AutoSize = true;
            radioButtonMale.Location = new Point(30, 395);
            radioButtonMale.Name = "radioButtonMale";
            radioButtonMale.Size = new Size(63, 24);
            radioButtonMale.TabIndex = 11;
            radioButtonMale.Text = "Male";

            // radioButtonFemale
            radioButtonFemale.AutoSize = true;
            radioButtonFemale.Location = new Point(150, 395);
            radioButtonFemale.Name = "radioButtonFemale";
            radioButtonFemale.Size = new Size(83, 24);
            radioButtonFemale.TabIndex = 12;
            radioButtonFemale.Text = "Female";

            // buttonSave
            buttonSave.Location = new Point(30, 450);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(190, 45);
            buttonSave.TabIndex = 13;
            buttonSave.Text = "Save Changes";
            buttonSave.Click += buttonSave_Click;

            // buttonCancel
            buttonCancel.Location = new Point(260, 450);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(190, 45);
            buttonCancel.TabIndex = 14;
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;

            // CustomerProfileEditForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 520);
            Controls.Add(panelContainer);
            Name = "CustomerProfileEditForm";
            Text = "Edit Your Profile";
            Load += CustomerProfileEditForm_Load;

            panelContainer.ResumeLayout(false);
            panelContainer.PerformLayout();
            ResumeLayout(false);
        }
    }
}
