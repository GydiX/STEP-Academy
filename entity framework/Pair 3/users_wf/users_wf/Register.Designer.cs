namespace users_wf
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tbEmail = new TextBox();
            tbFirstName = new TextBox();
            tbUsername = new TextBox();
            tbLastName = new TextBox();
            numAge = new NumericUpDown();
            btnRegister = new Button();
            panelRegister = new Panel();
            button2 = new Button();
            panelLogin = new Panel();
            button1 = new Button();
            label1 = new Label();
            btnLogin = new Button();
            label8 = new Label();
            tbUsernameLogin = new TextBox();
            tbEmailLogin = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            panelRegister.SuspendLayout();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(422, 52);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Register";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 11);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 110);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 2;
            label3.Text = "Last name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 44);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 2;
            label4.Text = "Username";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 77);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 3;
            label5.Text = "First name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(50, 142);
            label6.Name = "label6";
            label6.Size = new Size(36, 20);
            label6.TabIndex = 4;
            label6.Text = "Age";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(92, 8);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(213, 27);
            tbEmail.TabIndex = 5;
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(92, 74);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(213, 27);
            tbFirstName.TabIndex = 6;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(92, 41);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(213, 27);
            tbUsername.TabIndex = 7;
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(92, 107);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(213, 27);
            tbLastName.TabIndex = 8;
            // 
            // numAge
            // 
            numAge.Location = new Point(92, 140);
            numAge.Name = "numAge";
            numAge.Size = new Size(213, 27);
            numAge.TabIndex = 9;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(50, 203);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(213, 41);
            btnRegister.TabIndex = 10;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // panelRegister
            // 
            panelRegister.Controls.Add(button2);
            panelRegister.Controls.Add(label2);
            panelRegister.Controls.Add(btnRegister);
            panelRegister.Controls.Add(label3);
            panelRegister.Controls.Add(numAge);
            panelRegister.Controls.Add(label4);
            panelRegister.Controls.Add(tbLastName);
            panelRegister.Controls.Add(label5);
            panelRegister.Controls.Add(tbUsername);
            panelRegister.Controls.Add(label6);
            panelRegister.Controls.Add(tbFirstName);
            panelRegister.Controls.Add(tbEmail);
            panelRegister.Location = new Point(51, 75);
            panelRegister.Name = "panelRegister";
            panelRegister.Size = new Size(316, 283);
            panelRegister.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(50, 254);
            button2.Name = "button2";
            button2.Size = new Size(213, 29);
            button2.TabIndex = 12;
            button2.Text = "To login";
            button2.UseVisualStyleBackColor = true;
            button2.Click += FormChange_Click;
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(button1);
            panelLogin.Controls.Add(label1);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(label8);
            panelLogin.Controls.Add(tbUsernameLogin);
            panelLogin.Controls.Add(tbEmailLogin);
            panelLogin.Location = new Point(51, 75);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(316, 197);
            panelLogin.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(61, 153);
            button1.Name = "button1";
            button1.Size = new Size(213, 29);
            button1.TabIndex = 11;
            button1.Text = "To register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += FormChange_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 11);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(61, 96);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(213, 41);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 44);
            label8.Name = "label8";
            label8.Size = new Size(75, 20);
            label8.TabIndex = 2;
            label8.Text = "Username";
            // 
            // tbUsernameLogin
            // 
            tbUsernameLogin.Location = new Point(92, 41);
            tbUsernameLogin.Name = "tbUsernameLogin";
            tbUsernameLogin.Size = new Size(213, 27);
            tbUsernameLogin.TabIndex = 7;
            // 
            // tbEmailLogin
            // 
            tbEmailLogin.Location = new Point(92, 8);
            tbEmailLogin.Name = "tbEmailLogin";
            tbEmailLogin.Size = new Size(213, 27);
            tbEmailLogin.TabIndex = 5;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 361);
            Controls.Add(panelLogin);
            Controls.Add(panelRegister);
            Controls.Add(lblTitle);
            Name = "Register";
            Text = "Register";
            Load += Register_Load;
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            panelRegister.ResumeLayout(false);
            panelRegister.PerformLayout();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tbEmail;
        private TextBox tbFirstName;
        private TextBox tbUsername;
        private TextBox tbLastName;
        private NumericUpDown numAge;
        private Button btnRegister;
        private Panel panelRegister;
        private Panel panelLogin;
        private Label label1;
        private Button btnLogin;
        private Label label8;
        private TextBox tbUsernameLogin;
        private TextBox tbEmailLogin;
        private Button button2;
        private Button button1;
    }
}