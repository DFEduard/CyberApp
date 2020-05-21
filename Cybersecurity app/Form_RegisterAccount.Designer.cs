namespace Cybersecurity_app
{
    partial class Form_RegisterAccount
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPasswordMsg = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPass = new System.Windows.Forms.Panel();
            this.lblpassPercent = new System.Windows.Forms.Label();
            this.lblMsgConfirmPass = new System.Windows.Forms.Label();
            this.grpPassAnalysis = new System.Windows.Forms.GroupBox();
            this.lstRecommendation = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblOkSymbols = new System.Windows.Forms.Label();
            this.lblOkNumbers = new System.Windows.Forms.Label();
            this.lblOkLowercase = new System.Windows.Forms.Label();
            this.lblOkuppercase = new System.Windows.Forms.Label();
            this.lblOkCharactersLong = new System.Windows.Forms.Label();
            this.lblActualMiddleNoSym = new System.Windows.Forms.Label();
            this.lblAMiddleNoSymbols = new System.Windows.Forms.Label();
            this.lblARequirements = new System.Windows.Forms.Label();
            this.lblASymbols = new System.Windows.Forms.Label();
            this.lblANumbers = new System.Windows.Forms.Label();
            this.lblALowercaseLetters = new System.Windows.Forms.Label();
            this.lblAUppercaseLetters = new System.Windows.Forms.Label();
            this.lblActualSymbols = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblActualNumbers = new System.Windows.Forms.Label();
            this.lblActualLowercase = new System.Windows.Forms.Label();
            this.lblActualUppercase = new System.Windows.Forms.Label();
            this.lblActualRequirements = new System.Windows.Forms.Label();
            this.lblSymbols = new System.Windows.Forms.Label();
            this.lblNumbers = new System.Windows.Forms.Label();
            this.lblLowercaseLetter = new System.Windows.Forms.Label();
            this.lblUppercaseLetter = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkShowHidePass = new System.Windows.Forms.CheckBox();
            this.chkShowHideConfirmPass = new System.Windows.Forms.CheckBox();
            this.lblMsgEmail = new System.Windows.Forms.Label();
            this.chkMoreAnalysis = new System.Windows.Forms.CheckBox();
            this.chkTwoFactorAuth = new System.Windows.Forms.CheckBox();
            this.panelPass.SuspendLayout();
            this.grpPassAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(77, 91);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(208, 20);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Enter += new System.EventHandler(this.txtFirstName_Enter);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(77, 136);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(208, 20);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.Enter += new System.EventHandler(this.txtLastName_Enter);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(77, 181);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 20);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyUp);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(77, 226);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(208, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Location = new System.Drawing.Point(77, 404);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(208, 39);
            this.btnCreateAccount.TabIndex = 8;
            this.btnCreateAccount.Text = "Create";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(78, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 33);
            this.label5.TabIndex = 9;
            this.label5.Text = "New account";
            // 
            // lblPasswordMsg
            // 
            this.lblPasswordMsg.AutoSize = true;
            this.lblPasswordMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordMsg.Location = new System.Drawing.Point(3, 2);
            this.lblPasswordMsg.Name = "lblPasswordMsg";
            this.lblPasswordMsg.Size = new System.Drawing.Size(42, 15);
            this.lblPasswordMsg.TabIndex = 10;
            this.lblPasswordMsg.Text = "Weak";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(77, 316);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(208, 20);
            this.txtConfirmPass.TabIndex = 11;
            this.txtConfirmPass.Enter += new System.EventHandler(this.txtConfirmPass_Enter);
            this.txtConfirmPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPass_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Confirm password";
            // 
            // panelPass
            // 
            this.panelPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPass.Controls.Add(this.lblpassPercent);
            this.panelPass.Controls.Add(this.lblPasswordMsg);
            this.panelPass.Location = new System.Drawing.Point(77, 265);
            this.panelPass.Name = "panelPass";
            this.panelPass.Size = new System.Drawing.Size(208, 22);
            this.panelPass.TabIndex = 13;
            // 
            // lblpassPercent
            // 
            this.lblpassPercent.AutoSize = true;
            this.lblpassPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpassPercent.Location = new System.Drawing.Point(160, 3);
            this.lblpassPercent.Name = "lblpassPercent";
            this.lblpassPercent.Size = new System.Drawing.Size(27, 15);
            this.lblpassPercent.TabIndex = 11;
            this.lblpassPercent.Text = "0%";
            // 
            // lblMsgConfirmPass
            // 
            this.lblMsgConfirmPass.AutoSize = true;
            this.lblMsgConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgConfirmPass.Location = new System.Drawing.Point(185, 298);
            this.lblMsgConfirmPass.Name = "lblMsgConfirmPass";
            this.lblMsgConfirmPass.Size = new System.Drawing.Size(12, 15);
            this.lblMsgConfirmPass.TabIndex = 12;
            this.lblMsgConfirmPass.Text = "-";
            // 
            // grpPassAnalysis
            // 
            this.grpPassAnalysis.Controls.Add(this.lstRecommendation);
            this.grpPassAnalysis.Controls.Add(this.label10);
            this.grpPassAnalysis.Controls.Add(this.lblOkSymbols);
            this.grpPassAnalysis.Controls.Add(this.lblOkNumbers);
            this.grpPassAnalysis.Controls.Add(this.lblOkLowercase);
            this.grpPassAnalysis.Controls.Add(this.lblOkuppercase);
            this.grpPassAnalysis.Controls.Add(this.lblOkCharactersLong);
            this.grpPassAnalysis.Controls.Add(this.lblActualMiddleNoSym);
            this.grpPassAnalysis.Controls.Add(this.lblAMiddleNoSymbols);
            this.grpPassAnalysis.Controls.Add(this.lblARequirements);
            this.grpPassAnalysis.Controls.Add(this.lblASymbols);
            this.grpPassAnalysis.Controls.Add(this.lblANumbers);
            this.grpPassAnalysis.Controls.Add(this.lblALowercaseLetters);
            this.grpPassAnalysis.Controls.Add(this.lblAUppercaseLetters);
            this.grpPassAnalysis.Controls.Add(this.lblActualSymbols);
            this.grpPassAnalysis.Controls.Add(this.label9);
            this.grpPassAnalysis.Controls.Add(this.lblActualNumbers);
            this.grpPassAnalysis.Controls.Add(this.lblActualLowercase);
            this.grpPassAnalysis.Controls.Add(this.lblActualUppercase);
            this.grpPassAnalysis.Controls.Add(this.lblActualRequirements);
            this.grpPassAnalysis.Controls.Add(this.lblSymbols);
            this.grpPassAnalysis.Controls.Add(this.lblNumbers);
            this.grpPassAnalysis.Controls.Add(this.lblLowercaseLetter);
            this.grpPassAnalysis.Controls.Add(this.lblUppercaseLetter);
            this.grpPassAnalysis.Controls.Add(this.label8);
            this.grpPassAnalysis.Controls.Add(this.label7);
            this.grpPassAnalysis.Location = new System.Drawing.Point(350, 72);
            this.grpPassAnalysis.Name = "grpPassAnalysis";
            this.grpPassAnalysis.Size = new System.Drawing.Size(275, 371);
            this.grpPassAnalysis.TabIndex = 14;
            this.grpPassAnalysis.TabStop = false;
            this.grpPassAnalysis.Text = "Password info";
            // 
            // lstRecommendation
            // 
            this.lstRecommendation.FormattingEnabled = true;
            this.lstRecommendation.Location = new System.Drawing.Point(9, 293);
            this.lstRecommendation.Name = "lstRecommendation";
            this.lstRecommendation.Size = new System.Drawing.Size(252, 69);
            this.lstRecommendation.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(254, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Recommendation for strong password:";
            // 
            // lblOkSymbols
            // 
            this.lblOkSymbols.AutoSize = true;
            this.lblOkSymbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkSymbols.Location = new System.Drawing.Point(162, 117);
            this.lblOkSymbols.Name = "lblOkSymbols";
            this.lblOkSymbols.Size = new System.Drawing.Size(11, 13);
            this.lblOkSymbols.TabIndex = 23;
            this.lblOkSymbols.Text = "-";
            // 
            // lblOkNumbers
            // 
            this.lblOkNumbers.AutoSize = true;
            this.lblOkNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkNumbers.Location = new System.Drawing.Point(162, 97);
            this.lblOkNumbers.Name = "lblOkNumbers";
            this.lblOkNumbers.Size = new System.Drawing.Size(11, 13);
            this.lblOkNumbers.TabIndex = 22;
            this.lblOkNumbers.Text = "-";
            // 
            // lblOkLowercase
            // 
            this.lblOkLowercase.AutoSize = true;
            this.lblOkLowercase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkLowercase.Location = new System.Drawing.Point(162, 78);
            this.lblOkLowercase.Name = "lblOkLowercase";
            this.lblOkLowercase.Size = new System.Drawing.Size(11, 13);
            this.lblOkLowercase.TabIndex = 21;
            this.lblOkLowercase.Text = "-";
            // 
            // lblOkuppercase
            // 
            this.lblOkuppercase.AutoSize = true;
            this.lblOkuppercase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkuppercase.Location = new System.Drawing.Point(162, 58);
            this.lblOkuppercase.Name = "lblOkuppercase";
            this.lblOkuppercase.Size = new System.Drawing.Size(11, 13);
            this.lblOkuppercase.TabIndex = 20;
            this.lblOkuppercase.Text = "-";
            // 
            // lblOkCharactersLong
            // 
            this.lblOkCharactersLong.AutoSize = true;
            this.lblOkCharactersLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkCharactersLong.Location = new System.Drawing.Point(162, 38);
            this.lblOkCharactersLong.Name = "lblOkCharactersLong";
            this.lblOkCharactersLong.Size = new System.Drawing.Size(11, 13);
            this.lblOkCharactersLong.TabIndex = 19;
            this.lblOkCharactersLong.Text = "-";
            // 
            // lblActualMiddleNoSym
            // 
            this.lblActualMiddleNoSym.AutoSize = true;
            this.lblActualMiddleNoSym.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualMiddleNoSym.Location = new System.Drawing.Point(162, 252);
            this.lblActualMiddleNoSym.Name = "lblActualMiddleNoSym";
            this.lblActualMiddleNoSym.Size = new System.Drawing.Size(14, 13);
            this.lblActualMiddleNoSym.TabIndex = 18;
            this.lblActualMiddleNoSym.Text = "0";
            // 
            // lblAMiddleNoSymbols
            // 
            this.lblAMiddleNoSymbols.AutoSize = true;
            this.lblAMiddleNoSymbols.Location = new System.Drawing.Point(6, 252);
            this.lblAMiddleNoSymbols.Name = "lblAMiddleNoSymbols";
            this.lblAMiddleNoSymbols.Size = new System.Drawing.Size(136, 13);
            this.lblAMiddleNoSymbols.TabIndex = 17;
            this.lblAMiddleNoSymbols.Text = "Middle numbers or symbols:";
            // 
            // lblARequirements
            // 
            this.lblARequirements.AutoSize = true;
            this.lblARequirements.Location = new System.Drawing.Point(67, 156);
            this.lblARequirements.Name = "lblARequirements";
            this.lblARequirements.Size = new System.Drawing.Size(75, 13);
            this.lblARequirements.TabIndex = 16;
            this.lblARequirements.Text = "Requirements:";
            // 
            // lblASymbols
            // 
            this.lblASymbols.AutoSize = true;
            this.lblASymbols.Location = new System.Drawing.Point(93, 233);
            this.lblASymbols.Name = "lblASymbols";
            this.lblASymbols.Size = new System.Drawing.Size(49, 13);
            this.lblASymbols.TabIndex = 15;
            this.lblASymbols.Text = "Symbols:";
            // 
            // lblANumbers
            // 
            this.lblANumbers.AutoSize = true;
            this.lblANumbers.Location = new System.Drawing.Point(90, 214);
            this.lblANumbers.Name = "lblANumbers";
            this.lblANumbers.Size = new System.Drawing.Size(52, 13);
            this.lblANumbers.TabIndex = 14;
            this.lblANumbers.Text = "Numbers:";
            // 
            // lblALowercaseLetters
            // 
            this.lblALowercaseLetters.AutoSize = true;
            this.lblALowercaseLetters.Location = new System.Drawing.Point(49, 195);
            this.lblALowercaseLetters.Name = "lblALowercaseLetters";
            this.lblALowercaseLetters.Size = new System.Drawing.Size(93, 13);
            this.lblALowercaseLetters.TabIndex = 13;
            this.lblALowercaseLetters.Text = "Lowercase letters:";
            // 
            // lblAUppercaseLetters
            // 
            this.lblAUppercaseLetters.AutoSize = true;
            this.lblAUppercaseLetters.Location = new System.Drawing.Point(49, 174);
            this.lblAUppercaseLetters.Name = "lblAUppercaseLetters";
            this.lblAUppercaseLetters.Size = new System.Drawing.Size(93, 13);
            this.lblAUppercaseLetters.TabIndex = 12;
            this.lblAUppercaseLetters.Text = "Uppercase letters:";
            // 
            // lblActualSymbols
            // 
            this.lblActualSymbols.AutoSize = true;
            this.lblActualSymbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualSymbols.Location = new System.Drawing.Point(162, 233);
            this.lblActualSymbols.Name = "lblActualSymbols";
            this.lblActualSymbols.Size = new System.Drawing.Size(14, 13);
            this.lblActualSymbols.TabIndex = 11;
            this.lblActualSymbols.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Password Analysis";
            // 
            // lblActualNumbers
            // 
            this.lblActualNumbers.AutoSize = true;
            this.lblActualNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualNumbers.Location = new System.Drawing.Point(162, 214);
            this.lblActualNumbers.Name = "lblActualNumbers";
            this.lblActualNumbers.Size = new System.Drawing.Size(14, 13);
            this.lblActualNumbers.TabIndex = 9;
            this.lblActualNumbers.Text = "0";
            // 
            // lblActualLowercase
            // 
            this.lblActualLowercase.AutoSize = true;
            this.lblActualLowercase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualLowercase.Location = new System.Drawing.Point(162, 195);
            this.lblActualLowercase.Name = "lblActualLowercase";
            this.lblActualLowercase.Size = new System.Drawing.Size(14, 13);
            this.lblActualLowercase.TabIndex = 8;
            this.lblActualLowercase.Text = "0";
            // 
            // lblActualUppercase
            // 
            this.lblActualUppercase.AutoSize = true;
            this.lblActualUppercase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualUppercase.Location = new System.Drawing.Point(162, 176);
            this.lblActualUppercase.Name = "lblActualUppercase";
            this.lblActualUppercase.Size = new System.Drawing.Size(14, 13);
            this.lblActualUppercase.TabIndex = 7;
            this.lblActualUppercase.Text = "0";
            // 
            // lblActualRequirements
            // 
            this.lblActualRequirements.AutoSize = true;
            this.lblActualRequirements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualRequirements.Location = new System.Drawing.Point(162, 156);
            this.lblActualRequirements.Name = "lblActualRequirements";
            this.lblActualRequirements.Size = new System.Drawing.Size(14, 13);
            this.lblActualRequirements.TabIndex = 6;
            this.lblActualRequirements.Text = "0";
            // 
            // lblSymbols
            // 
            this.lblSymbols.AutoSize = true;
            this.lblSymbols.Location = new System.Drawing.Point(6, 117);
            this.lblSymbols.Name = "lblSymbols";
            this.lblSymbols.Size = new System.Drawing.Size(108, 13);
            this.lblSymbols.TabIndex = 5;
            this.lblSymbols.Text = "- at least one symbols";
            // 
            // lblNumbers
            // 
            this.lblNumbers.AutoSize = true;
            this.lblNumbers.Location = new System.Drawing.Point(6, 97);
            this.lblNumbers.Name = "lblNumbers";
            this.lblNumbers.Size = new System.Drawing.Size(106, 13);
            this.lblNumbers.TabIndex = 4;
            this.lblNumbers.Text = "- at least one number";
            // 
            // lblLowercaseLetter
            // 
            this.lblLowercaseLetter.AutoSize = true;
            this.lblLowercaseLetter.Location = new System.Drawing.Point(6, 78);
            this.lblLowercaseLetter.Name = "lblLowercaseLetter";
            this.lblLowercaseLetter.Size = new System.Drawing.Size(145, 13);
            this.lblLowercaseLetter.TabIndex = 3;
            this.lblLowercaseLetter.Text = "- at least one lowercase letter";
            // 
            // lblUppercaseLetter
            // 
            this.lblUppercaseLetter.AutoSize = true;
            this.lblUppercaseLetter.Location = new System.Drawing.Point(6, 58);
            this.lblUppercaseLetter.Name = "lblUppercaseLetter";
            this.lblUppercaseLetter.Size = new System.Drawing.Size(147, 13);
            this.lblUppercaseLetter.TabIndex = 2;
            this.lblUppercaseLetter.Text = "- at least one uppercase letter";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(266, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Minimum Requirements for a strong password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "- at least 8 characters long";
            // 
            // chkShowHidePass
            // 
            this.chkShowHidePass.AutoSize = true;
            this.chkShowHidePass.Location = new System.Drawing.Point(291, 229);
            this.chkShowHidePass.Name = "chkShowHidePass";
            this.chkShowHidePass.Size = new System.Drawing.Size(53, 17);
            this.chkShowHidePass.TabIndex = 15;
            this.chkShowHidePass.Text = "Show";
            this.chkShowHidePass.UseVisualStyleBackColor = true;
            this.chkShowHidePass.Click += new System.EventHandler(this.chkShowHidePass_Click);
            // 
            // chkShowHideConfirmPass
            // 
            this.chkShowHideConfirmPass.AutoSize = true;
            this.chkShowHideConfirmPass.Location = new System.Drawing.Point(291, 319);
            this.chkShowHideConfirmPass.Name = "chkShowHideConfirmPass";
            this.chkShowHideConfirmPass.Size = new System.Drawing.Size(53, 17);
            this.chkShowHideConfirmPass.TabIndex = 16;
            this.chkShowHideConfirmPass.Text = "Show";
            this.chkShowHideConfirmPass.UseVisualStyleBackColor = true;
            this.chkShowHideConfirmPass.Click += new System.EventHandler(this.chkShowHideConfirmPass_Click);
            // 
            // lblMsgEmail
            // 
            this.lblMsgEmail.AutoSize = true;
            this.lblMsgEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgEmail.Location = new System.Drawing.Point(139, 163);
            this.lblMsgEmail.Name = "lblMsgEmail";
            this.lblMsgEmail.Size = new System.Drawing.Size(144, 15);
            this.lblMsgEmail.TabIndex = 12;
            this.lblMsgEmail.Text = "Invalid email address";
            // 
            // chkMoreAnalysis
            // 
            this.chkMoreAnalysis.AutoSize = true;
            this.chkMoreAnalysis.Location = new System.Drawing.Point(78, 248);
            this.chkMoreAnalysis.Name = "chkMoreAnalysis";
            this.chkMoreAnalysis.Size = new System.Drawing.Size(115, 17);
            this.chkMoreAnalysis.TabIndex = 17;
            this.chkMoreAnalysis.Text = "View more analysis";
            this.chkMoreAnalysis.UseVisualStyleBackColor = true;
            this.chkMoreAnalysis.Click += new System.EventHandler(this.chkMoreAnalysis_Click);
            // 
            // chkTwoFactorAuth
            // 
            this.chkTwoFactorAuth.AutoSize = true;
            this.chkTwoFactorAuth.Location = new System.Drawing.Point(77, 347);
            this.chkTwoFactorAuth.Name = "chkTwoFactorAuth";
            this.chkTwoFactorAuth.Size = new System.Drawing.Size(169, 17);
            this.chkTwoFactorAuth.TabIndex = 18;
            this.chkTwoFactorAuth.Text = "Use multi-factor authentication";
            this.chkTwoFactorAuth.UseVisualStyleBackColor = true;
            this.chkTwoFactorAuth.Click += new System.EventHandler(this.chkTwoFactorAuth_Click);
            // 
            // Form_RegisterAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 460);
            this.Controls.Add(this.chkTwoFactorAuth);
            this.Controls.Add(this.chkMoreAnalysis);
            this.Controls.Add(this.lblMsgEmail);
            this.Controls.Add(this.chkShowHideConfirmPass);
            this.Controls.Add(this.chkShowHidePass);
            this.Controls.Add(this.grpPassAnalysis);
            this.Controls.Add(this.lblMsgConfirmPass);
            this.Controls.Add(this.panelPass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Name = "Form_RegisterAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_RegisterAccount";
            this.Load += new System.EventHandler(this.Form_RegisterAccount_Load);
            this.panelPass.ResumeLayout(false);
            this.panelPass.PerformLayout();
            this.grpPassAnalysis.ResumeLayout(false);
            this.grpPassAnalysis.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPasswordMsg;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelPass;
        private System.Windows.Forms.Label lblpassPercent;
        private System.Windows.Forms.Label lblMsgConfirmPass;
        private System.Windows.Forms.GroupBox grpPassAnalysis;
        private System.Windows.Forms.Label lblActualMiddleNoSym;
        private System.Windows.Forms.Label lblAMiddleNoSymbols;
        private System.Windows.Forms.Label lblARequirements;
        private System.Windows.Forms.Label lblASymbols;
        private System.Windows.Forms.Label lblANumbers;
        private System.Windows.Forms.Label lblALowercaseLetters;
        private System.Windows.Forms.Label lblAUppercaseLetters;
        private System.Windows.Forms.Label lblActualSymbols;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblActualNumbers;
        private System.Windows.Forms.Label lblActualLowercase;
        private System.Windows.Forms.Label lblActualUppercase;
        private System.Windows.Forms.Label lblActualRequirements;
        private System.Windows.Forms.Label lblSymbols;
        private System.Windows.Forms.Label lblNumbers;
        private System.Windows.Forms.Label lblLowercaseLetter;
        private System.Windows.Forms.Label lblUppercaseLetter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOkSymbols;
        private System.Windows.Forms.Label lblOkNumbers;
        private System.Windows.Forms.Label lblOkLowercase;
        private System.Windows.Forms.Label lblOkuppercase;
        private System.Windows.Forms.Label lblOkCharactersLong;
        private System.Windows.Forms.CheckBox chkShowHidePass;
        private System.Windows.Forms.CheckBox chkShowHideConfirmPass;
        private System.Windows.Forms.Label lblMsgEmail;
        private System.Windows.Forms.ListBox lstRecommendation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkMoreAnalysis;
        private System.Windows.Forms.CheckBox chkTwoFactorAuth;
    }
}