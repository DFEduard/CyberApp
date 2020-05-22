namespace Cybersecurity_app
{
    partial class Form_Login
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panelEmail = new System.Windows.Forms.Panel();
            this.btnLoginAuthentication = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblMauthTile = new System.Windows.Forms.Label();
            this.lblMsgMauth = new System.Windows.Forms.Label();
            this.chkShowHidePass = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(98, 130);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(196, 20);
            this.txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(98, 178);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(196, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cyber app ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(105, 213);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(177, 36);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Location = new System.Drawing.Point(105, 297);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(177, 36);
            this.btnCreateAccount.TabIndex = 7;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(181, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "or";
            // 
            // panelEmail
            // 
            this.panelEmail.Controls.Add(this.btnLoginAuthentication);
            this.panelEmail.Controls.Add(this.txtCode);
            this.panelEmail.Controls.Add(this.lblMauthTile);
            this.panelEmail.Controls.Add(this.lblMsgMauth);
            this.panelEmail.Location = new System.Drawing.Point(43, 80);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(307, 287);
            this.panelEmail.TabIndex = 10;
            // 
            // btnLoginAuthentication
            // 
            this.btnLoginAuthentication.Location = new System.Drawing.Point(62, 217);
            this.btnLoginAuthentication.Name = "btnLoginAuthentication";
            this.btnLoginAuthentication.Size = new System.Drawing.Size(177, 36);
            this.btnLoginAuthentication.TabIndex = 14;
            this.btnLoginAuthentication.Text = "Login";
            this.btnLoginAuthentication.UseVisualStyleBackColor = true;
            this.btnLoginAuthentication.Click += new System.EventHandler(this.btnLoginAuthentication_Click);
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(62, 133);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(177, 29);
            this.txtCode.TabIndex = 13;
            this.txtCode.Visible = false;
            // 
            // lblMauthTile
            // 
            this.lblMauthTile.AutoSize = true;
            this.lblMauthTile.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMauthTile.Location = new System.Drawing.Point(19, 31);
            this.lblMauthTile.Name = "lblMauthTile";
            this.lblMauthTile.Size = new System.Drawing.Size(272, 31);
            this.lblMauthTile.TabIndex = 12;
            this.lblMauthTile.Text = "Authentication code";
            // 
            // lblMsgMauth
            // 
            this.lblMsgMauth.AutoSize = true;
            this.lblMsgMauth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgMauth.Location = new System.Drawing.Point(68, 73);
            this.lblMsgMauth.Name = "lblMsgMauth";
            this.lblMsgMauth.Size = new System.Drawing.Size(171, 16);
            this.lblMsgMauth.TabIndex = 11;
            this.lblMsgMauth.Text = "Code sent to your email";
            // 
            // chkShowHidePass
            // 
            this.chkShowHidePass.AutoSize = true;
            this.chkShowHidePass.Location = new System.Drawing.Point(301, 181);
            this.chkShowHidePass.Name = "chkShowHidePass";
            this.chkShowHidePass.Size = new System.Drawing.Size(53, 17);
            this.chkShowHidePass.TabIndex = 11;
            this.chkShowHidePass.Text = "Show";
            this.chkShowHidePass.UseVisualStyleBackColor = true;
            this.chkShowHidePass.Click += new System.EventHandler(this.chkShowHidePass_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(297, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Prototype";
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 372);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelEmail);
            this.Controls.Add(this.chkShowHidePass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Login_Load);
            this.panelEmail.ResumeLayout(false);
            this.panelEmail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelEmail;
        private System.Windows.Forms.Label lblMauthTile;
        private System.Windows.Forms.Label lblMsgMauth;
        private System.Windows.Forms.CheckBox chkShowHidePass;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnLoginAuthentication;
        private System.Windows.Forms.Label label4;
    }
}

