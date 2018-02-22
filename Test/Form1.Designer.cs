namespace Test
{
    partial class Form1
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
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ForgetLink = new System.Windows.Forms.LinkLabel();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.invalid_input = new System.Windows.Forms.Label();
            this.LogIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Register";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "User Name:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password:";
            // 
            // ForgetLink
            // 
            this.ForgetLink.AutoSize = true;
            this.ForgetLink.Location = new System.Drawing.Point(112, 160);
            this.ForgetLink.Name = "ForgetLink";
            this.ForgetLink.Size = new System.Drawing.Size(125, 13);
            this.ForgetLink.TabIndex = 2;
            this.ForgetLink.TabStop = true;
            this.ForgetLink.Text = "Forgot Uname/Password";
            this.ForgetLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForgetLink_LinkClicked);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(115, 55);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(157, 20);
            this.txtusername.TabIndex = 0;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(115, 94);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(157, 20);
            this.txtpassword.TabIndex = 1;
            // 
            // invalid_input
            // 
            this.invalid_input.AutoSize = true;
            this.invalid_input.Location = new System.Drawing.Point(121, 135);
            this.invalid_input.Name = "invalid_input";
            this.invalid_input.Size = new System.Drawing.Size(0, 13);
            this.invalid_input.TabIndex = 7;
            // 
            // LogIn
            // 
            this.LogIn.Location = new System.Drawing.Point(61, 187);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(83, 31);
            this.LogIn.TabIndex = 3;
            this.LogIn.Text = "LogIn";
            this.LogIn.UseVisualStyleBackColor = true;
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(333, 272);
            this.Controls.Add(this.LogIn);
            this.Controls.Add(this.invalid_input);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.ForgetLink);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel ForgetLink;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label invalid_input;
        private System.Windows.Forms.Button LogIn;
    }
}

