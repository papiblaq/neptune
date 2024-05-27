namespace neptune
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_forgotten = new System.Windows.Forms.Button();
            this.login_register = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.signup_showpass = new System.Windows.Forms.CheckBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sighnup_pass = new System.Windows.Forms.TextBox();
            this.login_username = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Cyan;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(-3, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 448);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btn_forgotten);
            this.panel1.Controls.Add(this.login_register);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.signup_showpass);
            this.panel1.Controls.Add(this.login_btn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.sighnup_pass);
            this.panel1.Controls.Add(this.login_username);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(224, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 448);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(28, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // btn_forgotten
            // 
            this.btn_forgotten.Location = new System.Drawing.Point(329, 306);
            this.btn_forgotten.Name = "btn_forgotten";
            this.btn_forgotten.Size = new System.Drawing.Size(142, 23);
            this.btn_forgotten.TabIndex = 20;
            this.btn_forgotten.Text = "fogotten password";
            this.btn_forgotten.UseVisualStyleBackColor = true;
            // 
            // login_register
            // 
            this.login_register.AutoSize = true;
            this.login_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_register.Location = new System.Drawing.Point(329, 356);
            this.login_register.Name = "login_register";
            this.login_register.Size = new System.Drawing.Size(117, 20);
            this.login_register.TabIndex = 19;
            this.login_register.Text = "register here";
            this.login_register.Click += new System.EventHandler(this.login_register_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Dont have an account?";
            // 
            // signup_showpass
            // 
            this.signup_showpass.AutoSize = true;
            this.signup_showpass.Location = new System.Drawing.Point(360, 265);
            this.signup_showpass.Name = "signup_showpass";
            this.signup_showpass.Size = new System.Drawing.Size(122, 20);
            this.signup_showpass.TabIndex = 17;
            this.signup_showpass.Text = "show password";
            this.signup_showpass.UseVisualStyleBackColor = true;
            this.signup_showpass.CheckedChanged += new System.EventHandler(this.login_showpas_CheckedChanged);
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.login_btn.Location = new System.Drawing.Point(119, 306);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(75, 23);
            this.login_btn.TabIndex = 16;
            this.login_btn.Text = "login";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "password";
            // 
            // sighnup_pass
            // 
            this.sighnup_pass.Location = new System.Drawing.Point(119, 225);
            this.sighnup_pass.Name = "sighnup_pass";
            this.sighnup_pass.PasswordChar = '*';
            this.sighnup_pass.Size = new System.Drawing.Size(336, 22);
            this.sighnup_pass.TabIndex = 13;
            this.sighnup_pass.TextChanged += new System.EventHandler(this.login_password_TextChanged);
            // 
            // login_username
            // 
            this.login_username.Location = new System.Drawing.Point(119, 130);
            this.login_username.Name = "login_username";
            this.login_username.Size = new System.Drawing.Size(336, 22);
            this.login_username.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(225, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "sighn in";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "sighnin";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_forgotten;
        private System.Windows.Forms.Label login_register;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox signup_showpass;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sighnup_pass;
        private System.Windows.Forms.TextBox login_username;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}