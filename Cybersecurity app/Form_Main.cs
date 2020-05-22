using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cybersecurity_app
{
    public partial class Form_Main : Form
    {
        private User user;
        private Encryption encryption = new Encryption();
        private EmailServices emailServices;
        private Database db;
        private PasswordChecker passwordChecker;
        private const string codeCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$";
        private bool passwordCanBeChanged;
        private string[] passwordRecommendation = new string[5];


        public Form_Main(User currentUser)
        {
            InitializeComponent();

            user = currentUser;

            //Display user info 
            lblFullName.Text = encryption.DecryptData(user.FirstName) + " " + encryption.DecryptData(user.LastName);
            lblEmail.Text = encryption.DecryptData(user.Email);
            lblPassword.Text = user.Password;
            
            //Display multi factor authentication 
            if (user.MultiFactorAuthentication)
            {
                lblAuthen.Text = "Enable";
                btnAuthen.Text = "Disable";

            }
            else
            {
                lblAuthen.Text = "Disable";
                btnAuthen.Text = "Enable";
            }

            //Hide password 
            txtPassword.UseSystemPasswordChar = true;
            chkShowHidePass.Visible = false;
            lblPassordMsg.Visible = false;

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //Check buttons state 
            if (btnChangePassword.Text != "Save password")
            {
                //Set controls for saving state 
                lblPassword.Visible = false;
                txtPassword.Visible = true;
                btnChangePassword.Text = "Save password";
                btnCancel.Visible = true;
                chkShowHidePass.Visible = true;
                lblPassordMsg.Visible = true;
            }
            else if (btnChangePassword.Text == "Save password") 
            {
                //Check for empty field 
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    if (PassMinRequirementChecker())
                    {
                        //Check the input password agains the old password
                        if (txtPassword.Text != encryption.DecryptData(user.Password))
                        {

                            //Create database
                            db = new Database();

                            //Crate query
                            string query = "UPDATE users SET password = @password WHERE ID = @userID";

                            //Check password for sql injection
                            if (!db.CheckSqlInjection(txtPassword.Text))
                            {
                                //Query database
                                db.NonQuery(query, p =>
                                {
                                    p.Add("@password", DbType.String).Value = encryption.EncryptData(txtPassword.Text);
                                    p.Add("@userID", DbType.Int32).Value = user.Id;
                                });

                                //Notify user
                                MessageBox.Show("Your password has been updated!");

                                //Set controls for default state (show password)
                                lblPassword.Visible = true;
                                lblPassword.Text = encryption.EncryptData(txtPassword.Text);
                                user.Password = encryption.EncryptData(txtPassword.Text);
                                txtPassword.Visible = false;
                                btnChangePassword.Text = "Change Password";
                                btnCancel.Visible = false;
                                chkShowHidePass.Visible = false;
                                lblPassordMsg.Visible = false;
                            }
                            else
                            {
                                //Notify user for sql injection
                                MessageBox.Show("SQL INJECTION DETECTED!. Password has not been changed");
                            }

                        }
                        else
                        {
                            //Notify user when the new password is as the old one 
                            MessageBox.Show("You can not use old password", "Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                       //Create message to notify the user 
                        string showMsg = "Password does't met all the minimum requirements.\n Recomandetion: ";
                        int countRecommendationNo = 0;
                        //Loop throug each recommendation
                        for (int i = 0; i < passwordRecommendation.Length; i++)
                        {
                            //Check recommendation 
                            if (passwordRecommendation[i] != "NONE")
                            {
                                countRecommendationNo++;
                                //Add recommendation to the message 
                                showMsg += "\n " + countRecommendationNo.ToString() + ". " + passwordRecommendation[i];
                            }
                        }

                        //Password is weak. Display recommendations
                        MessageBox.Show(showMsg, "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //Notify user when password field is empty 
                    MessageBox.Show("Password field is empty!", "Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnAuthen_Click(object sender, EventArgs e)
        {
            //Create database
            db = new Database();

            //Check button state 
            if (btnAuthen.Text == "Enable")
            {
                //Create unique code 
                string uniqueCode = CreateRandomCode(10);
                //Create the time for the code
                DateTime datetimeCode = DateTime.Now;

                
                //Create query for database
                string query = "INSERT INTO unique_codes (user_id, code, time) VALUES (@userID, @code, @time)";

                //Query database and add parameters
                db.NonQuery(query, p =>
                {
                    p.Add("@userID", DbType.Int32).Value = user.Id;
                    p.Add("@code", DbType.String).Value = uniqueCode;
                    p.Add("@time", DbType.DateTime).Value = datetimeCode;

                });

                //Create email services 
                emailServices = new EmailServices();
                //Send the unique code to the user's email 
                emailServices.SendEmail(lblEmail.Text, uniqueCode);

                //Show multi factor authentication form
                using (Form_MultiFactorAuthentication multiFactorAuthentication = new Form_MultiFactorAuthentication(uniqueCode, datetimeCode, true))
                {
                    //Check for result 
                    if (multiFactorAuthentication.ShowDialog() == DialogResult.OK)
                    {
                        //Change controls for multi factor authentication 
                        btnAuthen.Text = "Disable";
                        lblAuthen.Text = "Enable";
                        
                        //Check if multi factor authentication has succesfully activated
                        if (!multiFactorAuthentication.AuthEnable)
                        {
                            //Create query to delete the unique code
                            query = "DELETE FROM unique_codes WHERE code = @code and user_id = @userID";

                            //Query the daabase
                            db.NonQuery(query, p =>
                            {
                                p.Add("@code", DbType.String).Value = uniqueCode;
                                p.Add("@userID", DbType.Int32).Value = user.Id;

                            });

                            //Create query to update user's multi factor authentication
                            query = "UPDATE users SET two_factor_authentication = false WHERE ID = @userID";

                            //Query the database
                            db.NonQuery(query, p => { p.Add("@userID", DbType.Int32).Value = user.Id; });

                        }
                        else
                        {
                            //Query database to updated the time of the unique code 
                            query = "UPDATE unique_codes SET time = @time WHERE user_id = @userID ";
                            //Deduction 10 minutes from the time
                            datetimeCode = datetimeCode.AddMinutes(-10);

                            //Query the database and add parameters
                            db.NonQuery(query, p =>
                            {
                                p.Add("@time", DbType.DateTime).Value = datetimeCode;
                                p.Add("@userID", DbType.Int32).Value = user.Id;

                            });

                            //Query database to update the user's multi factor authentication to true
                            query = "UPDATE users SET two_factor_authentication = true WHERE ID = @userID";

                            //Query the database
                            db.NonQuery(query, p => { p.Add("@userID", DbType.Int32).Value = user.Id; });
                        }
                    }
                }

            }
            else if (btnAuthen.Text == "Disable") // Displable multi factor authentication if enable 
            {
                //Notify user to make sure that the multi factor authentication should be disable 
                DialogResult result = MessageBox.Show("Disabling Multifactor Authentication will make your account less secure.\nContinue? ",
                    "Multi Factor Authentication", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                //Check user's input 
                if (result == DialogResult.Yes)
                {
                    //Create string to update the multi factor authentication (disable)
                    string query = "UPDATE users SET two_factor_authentication = false WHERE ID = @userID";

                    //Query the database. Add parameters
                    db.NonQuery(query, p => { p.Add("@userID", DbType.Int32).Value = user.Id; });

                    //Notify user 
                    MessageBox.Show("Multifactor Authentication has been disabled");

                    btnAuthen.Text = "Enable";
                    lblAuthen.Text = "Disable";
                }



                   
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Set controls to default state when the user's cancel to change the password 
            lblPassword.Visible = true;
            txtPassword.Visible = false;
            btnChangePassword.Text = "Change password";
            btnCancel.Visible = false;
            chkShowHidePass.Visible = false;
            lblPassordMsg.Visible = false;
        }


        /// <summary>
        /// Method to create random code
        /// </summary>
        /// <param name="lenght"></param>
        /// <returns>The length of the code</returns>
        private string CreateRandomCode(int length)
        {

            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(codeCharacters[rnd.Next(codeCharacters.Length)]);
            }
            return res.ToString();

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //Open the login form 
            using (Form_Login loginForm = new Form_Login())
            {
                Hide();
                loginForm.ShowDialog();
                Close();
            }
        }

        private void chkShow_Click(object sender, EventArgs e)
        {
            //Show or hide the password 
            txtPassword.UseSystemPasswordChar = !chkShowHidePass.Checked;
        }


        
        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            passwordChecker = new PasswordChecker();
            passwordChecker.StrengthCalculator(txtPassword.Text);
            lblPassordMsg.Text =  passwordChecker.GetScoreString();

        }


        private bool PassMinRequirementChecker()
        {
            passwordRecommendation[0]= "NONE";
            passwordRecommendation[1]= "NONE";
            passwordRecommendation[2]= "NONE";
            passwordRecommendation[3]= "NONE";
            passwordRecommendation[4]= "NONE";

            //Check all minimum requirements

            //Lowercase letter at least 1
            if (passwordChecker.TotalNoOfLowerCases < 1)
            {
                 passwordRecommendation[0] = "You must add at leas one lowercase letter";
            }
            
            //Uppercase letter at least 1
            if (passwordChecker.TotalNoOfUpperCases < 1)
            {
                 passwordRecommendation[1] = "You must add at least one uppercase letters";
            }

            //Digit at least 1
            if (passwordChecker.TotalNoOfDigits < 1)
            {
                passwordRecommendation[2] = "You must add at least one digit";
            }
            
            //Symbol at least 1
            if (passwordChecker.TotalNoOfSymbols < 1)
            {
                passwordRecommendation[3] = "You must add at least one symbol";
            }
           

            //Store the total number of characters from the password
            int countCharacters = passwordChecker.TotalNoOfLowerCases + passwordChecker.TotalNoOfUpperCases + passwordChecker.TotalNoOfDigits + passwordChecker.TotalNoOfSymbols + passwordChecker.TotalNoOfSymbols;

            if (countCharacters < 8)
            {
                passwordRecommendation[4] = "Password must be at least 8 characters in length";
            }
           
            if (passwordChecker.TotalNoOfRequirements == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
