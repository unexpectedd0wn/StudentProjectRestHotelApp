
namespace WindowsFormsApp1
{
    partial class Authorisation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorisation));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelForrgotPass = new System.Windows.Forms.LinkLabel();
            this.lebelValidMessage = new System.Windows.Forms.Label();
            this.labelAuth = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconHidePass = new FontAwesome.Sharp.IconPictureBox();
            this.iconShowPass = new FontAwesome.Sharp.IconPictureBox();
            this.iconUsername = new FontAwesome.Sharp.IconPictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconPassword = new FontAwesome.Sharp.IconPictureBox();
            this.btnEnter = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconHidePass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconShowPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconUsername)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtUserName.Location = new System.Drawing.Point(54, 7);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(302, 27);
            this.txtUserName.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 511);
            this.panel1.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ARMCafeAdmin.Properties.Resources.main;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 511);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelForrgotPass
            // 
            this.labelForrgotPass.AutoSize = true;
            this.labelForrgotPass.Location = new System.Drawing.Point(561, 359);
            this.labelForrgotPass.Name = "labelForrgotPass";
            this.labelForrgotPass.Size = new System.Drawing.Size(99, 16);
            this.labelForrgotPass.TabIndex = 28;
            this.labelForrgotPass.TabStop = true;
            this.labelForrgotPass.Text = "забыли пароль?";
            this.labelForrgotPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelForrgotPass_LinkClicked);
            // 
            // lebelValidMessage
            // 
            this.lebelValidMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lebelValidMessage.ForeColor = System.Drawing.Color.Red;
            this.lebelValidMessage.Location = new System.Drawing.Point(325, 199);
            this.lebelValidMessage.Name = "lebelValidMessage";
            this.lebelValidMessage.Size = new System.Drawing.Size(335, 16);
            this.lebelValidMessage.TabIndex = 27;
            this.lebelValidMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAuth
            // 
            this.labelAuth.AutoSize = true;
            this.labelAuth.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuth.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelAuth.Location = new System.Drawing.Point(433, 174);
            this.labelAuth.Name = "labelAuth";
            this.labelAuth.Size = new System.Drawing.Size(150, 22);
            this.labelAuth.TabIndex = 26;
            this.labelAuth.Text = "АВТОРИЗАЦИЯ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.iconHidePass);
            this.panel2.Controls.Add(this.iconShowPass);
            this.panel2.Controls.Add(this.iconUsername);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Location = new System.Drawing.Point(304, 271);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 41);
            this.panel2.TabIndex = 25;
            // 
            // iconHidePass
            // 
            this.iconHidePass.BackColor = System.Drawing.Color.White;
            this.iconHidePass.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.iconHidePass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.iconHidePass.IconColor = System.Drawing.SystemColors.HotTrack;
            this.iconHidePass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconHidePass.IconSize = 23;
            this.iconHidePass.Location = new System.Drawing.Point(330, 9);
            this.iconHidePass.Name = "iconHidePass";
            this.iconHidePass.Size = new System.Drawing.Size(23, 23);
            this.iconHidePass.TabIndex = 57;
            this.iconHidePass.TabStop = false;
            this.iconHidePass.Click += new System.EventHandler(this.iconHidePass_Click);
            // 
            // iconShowPass
            // 
            this.iconShowPass.BackColor = System.Drawing.Color.White;
            this.iconShowPass.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.iconShowPass.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.iconShowPass.IconColor = System.Drawing.SystemColors.HotTrack;
            this.iconShowPass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconShowPass.IconSize = 23;
            this.iconShowPass.Location = new System.Drawing.Point(331, 9);
            this.iconShowPass.Margin = new System.Windows.Forms.Padding(0);
            this.iconShowPass.Name = "iconShowPass";
            this.iconShowPass.Size = new System.Drawing.Size(23, 23);
            this.iconShowPass.TabIndex = 56;
            this.iconShowPass.TabStop = false;
            this.iconShowPass.Click += new System.EventHandler(this.iconShowPass_Click);
            // 
            // iconUsername
            // 
            this.iconUsername.BackColor = System.Drawing.Color.White;
            this.iconUsername.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.iconUsername.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconUsername.IconColor = System.Drawing.SystemColors.HotTrack;
            this.iconUsername.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconUsername.IconSize = 27;
            this.iconUsername.Location = new System.Drawing.Point(21, 7);
            this.iconUsername.Name = "iconUsername";
            this.iconUsername.Size = new System.Drawing.Size(27, 27);
            this.iconUsername.TabIndex = 3;
            this.iconUsername.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtPassword.Location = new System.Drawing.Point(54, 7);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(302, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.iconPassword);
            this.panel3.Controls.Add(this.txtUserName);
            this.panel3.Location = new System.Drawing.Point(304, 224);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(377, 41);
            this.panel3.TabIndex = 24;
            // 
            // iconPassword
            // 
            this.iconPassword.BackColor = System.Drawing.Color.White;
            this.iconPassword.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.iconPassword.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.iconPassword.IconColor = System.Drawing.SystemColors.HotTrack;
            this.iconPassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPassword.IconSize = 27;
            this.iconPassword.Location = new System.Drawing.Point(21, 7);
            this.iconPassword.Name = "iconPassword";
            this.iconPassword.Size = new System.Drawing.Size(27, 27);
            this.iconPassword.TabIndex = 59;
            this.iconPassword.TabStop = false;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEnter.FlatAppearance.BorderSize = 0;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEnter.IconColor = System.Drawing.Color.Black;
            this.btnEnter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnter.Location = new System.Drawing.Point(551, 329);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(109, 27);
            this.btnEnter.TabIndex = 58;
            this.btnEnter.Text = "ВХОД";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // Authorisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(693, 511);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelForrgotPass);
            this.Controls.Add(this.lebelValidMessage);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.labelAuth);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Authorisation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconHidePass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconShowPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconUsername)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel labelForrgotPass;
        private System.Windows.Forms.Label lebelValidMessage;
        private System.Windows.Forms.Label labelAuth;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btnEnter;
        private FontAwesome.Sharp.IconPictureBox iconPassword;
        private FontAwesome.Sharp.IconPictureBox iconUsername;
        private FontAwesome.Sharp.IconPictureBox iconHidePass;
        private FontAwesome.Sharp.IconPictureBox iconShowPass;
    }
}