using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Cybersecurity_app
{
    public partial class Form_RegisterAccount : Form
    {
        //Private properties
        private PasswordChecker passwordChecker;
        private EmailChecker emailChecker;
        private Database db;
        private User user;
        private Encryption encryption;
        private string msgRequirementOk = "OK";
        private string msgRequirementNone = "-";
        private string firstName, lastName, email, password;

        public bool MultiFactorAuthentication { get; private set; }
        public User User { get => user; private set => user = value; }

        public Form_RegisterAccount()
        {
            InitializeComponent();
        }
        private void Form_RegisterAccount_Load(object sender, EventArgs e)
        {
            //Initialise password checker class
            passwordChecker = new PasswordChecker();
            ViewPasswordAnalysis(false);

            //Disable the confirm password field 
            txtConfirmPass.Enabled = false;

            //Clear text message for confirmation password
            lblMsgConfirmPass.Text = "";

            chkShowHideConfirmPass.Enabled = false;

            //Show password message as not applicable 
            lblPasswordMsg.Text = "N/A";

            //Check show password checkboxes
            chkShowHidePass.Checked = false;
            chkShowHideConfirmPass.Checked = false;

            //Hide passwords
            txtConfirmPass.UseSystemPasswordChar = true;
            txtPassword.UseSystemPasswordChar = true;

            //Initialise email checker class
            emailChecker = new EmailChecker();

            //Clear message
            lblMsgEmail.Text = "";

            btnCreateAccount.DialogResult = DialogResult.OK;

        }


        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            //Initialise database class
            db = new Database();
            //Initialse encryption class
            encryption = new Encryption();

            //Check input validation (false means is ok)
            if (!InputValidation())
            {

                //Check sql injection validation (false means is ok)
                if (!SqlInjectionDetected())
                {

                    if (emailChecker.ValidEmailAddress)
                    {
                        if (passwordChecker.TotalNoOfRequirements == 5)
                        {
                            try
                            {
                                //Store user data (user data will be encrypted)
                                firstName = encryption.EncryptData(txtFirstName.Text);
                                lastName = encryption.EncryptData(txtLastName.Text);
                                email = encryption.EncryptData(txtEmail.Text);
                                password = encryption.EncryptData(txtPassword.Text);

                                //Create user object
                                User = new User(firstName, lastName, email, password);

                                //Create query to save user data into database
                                string query = "INSERT INTO [users] (first_name, last_name, email, password, two_factor_authentication) VALUES (@firstName, @lastName, @email, @password, @twoFactorAuthentication)";

                                //Query database and add user data as parameters
                                db.NonQuery(query, p =>
                                {
                                    p.Add("@firstName", DbType.String).Value = firstName;
                                    p.Add("@lastName", DbType.String).Value = lastName;
                                    p.Add("@email", DbType.String).Value = email;
                                    p.Add("@password", DbType.String).Value = password;

                                    if (MultiFactorAuthentication)
                                    {
                                        p.Add("@twoFactorAuthentication", DbType.Boolean).Value = true;
                                    }
                                    else
                                    {
                                        p.Add("@twoFactorAuthentication", DbType.Boolean).Value = false;
                                    }
                                });

                                MessageBox.Show("The account has been succesfully created", "Account", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                DialogResult = DialogResult.OK;
                                
                            }
                            catch(SQLiteException ex)
                            {
                                MessageBox.Show("Something went wrong!");
                            }
                           
                        }
                        else
                        {
                            if (!chkMoreAnalysis.Checked)
                            {
                                MessageBox.Show("Password doesn't meet all minimum requirements.\nMinimum requirements info can be seen on the top of the Password info area\n" +
                                    "To close the Password info click on the checkbox -View more analysis- below the password field\n" +
                                    "Check also the recommendations to create a strong password from the bottom of the Password info area");

                                Size = new Size(Size.Width + grpPassAnalysis.Width, Size.Height);
                                grpPassAnalysis.Visible = true;
                                chkMoreAnalysis.Checked = true;
                            }
                            else
                            {
                                MessageBox.Show("Password doesn't meet all minimum requirements.\nMinimum requirements info can be seen on the top of the Password info area\n" +
                                    "Check also the recommendations to create a strong password from the bottom of the Password info area");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid email address. Please type a valid email address");
                    }

                    
                }

                   
            }
            else
            {
                //Notify user to complete all teh fields
                MessageBox.Show("All field must be completed", "Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            //Store the score of the password in percentage
            double percentPass = 0;

            if (lstRecommendation.Items.Count !=0)
            {
                lstRecommendation.Items.Clear();
            }

            //Calculate the strenght of the password
            passwordChecker.StrengthCalculator(txtPassword.Text);
            //Get the text result (weak, medium, strong)
            lblPasswordMsg.Text = passwordChecker.GetScoreString();
            //Get the result in percentage (from 0 to 100%)
            percentPass = passwordChecker.GetScorePercent();
            //Display the strength of the password in percentage 
            lblpassPercent.Text = percentPass.ToString() + "%";

            //Display different panel colour based on the result 
            if (percentPass <= 40) //password week
            {
                //Show colour red
                panelPass.BackColor = Color.FromArgb(247, 27, 27);
            }
            else if (percentPass >= 40 && percentPass < 70) //password medium
            {
                //Show colour orange
                panelPass.BackColor = Color.FromArgb(247, 236, 25);
            }
            else if (percentPass >= 70)// password strong
            {
                //Show colour green
                panelPass.BackColor = Color.FromArgb(62, 247, 0);
            }

            //Password analysis 
            //Display the total number of requirements met
            lblActualRequirements.Text = passwordChecker.TotalNoOfRequirements.ToString();
            //Display the total number of uppercase letters from the password
            lblActualUppercase.Text = passwordChecker.TotalNoOfUpperCases.ToString();
            //Display the total number of lowercase letters from the password
            lblActualLowercase.Text = passwordChecker.TotalNoOfLowerCases.ToString();
            //Display the total number of digits from the password
            lblActualNumbers.Text = passwordChecker.TotalNoOfDigits.ToString();
            //Display the total number of symbols from the password
            lblActualSymbols.Text = passwordChecker.TotalNoOfSymbols.ToString();
            //Display the total number of middle symbols or numbers (in both cases first and last is not consideret)
            //Example 1: !@#$12 will be 4 (numbers + symbols) and not 6
            //Example 2: a!@2$s wil be 4 (numbers + symbols) 
            lblActualMiddleNoSym.Text = passwordChecker.TotalNoOfNnS.ToString();


            //
            // If statements that shows if minimum requirements have been met 
            //

            //Check if the total number of upperscase letters is 1 or more
            if ( passwordChecker.TotalNoOfUpperCases >= 1)
            {
                //Display: ok
                lblOkuppercase.Text = msgRequirementOk;
            }
            else if (passwordChecker.TotalNoOfLowerCases < 1) // less than 1
            {
                //Display: -
                lblOkuppercase.Text = msgRequirementNone;
               
                
            }

            //Check if the total number of lowercase letters is 1 or more
            if (passwordChecker.TotalNoOfLowerCases >= 1)
            {
                //Display: ok
                lblOkLowercase.Text = msgRequirementOk;
            }
            else if (passwordChecker.TotalNoOfLowerCases < 1) // less than 1
            {
                //Display: -
                lblOkLowercase.Text = msgRequirementNone;
                
            }

            //Store the total number of characters from the password 
            int charactersCounter = passwordChecker.TotalNoOfUpperCases + passwordChecker.TotalNoOfLowerCases + passwordChecker.TotalNoOfDigits + passwordChecker.TotalNoOfSymbols;

            //Check the total number of characters from password
            if (charactersCounter >= 1) 
            {
                //Enable confirm password field
                txtConfirmPass.Enabled = true;
                chkShowHideConfirmPass.Enabled = true;

            }
            else if (charactersCounter < 1)
            {
                //Disable confirm password field
                txtConfirmPass.Enabled = false;
                txtConfirmPass.Text = "";
                chkShowHideConfirmPass.Enabled = false;
                lblPasswordMsg.Text = "N/A";
                lblMsgConfirmPass.Visible = false;
            }

            //Check the total number of characters 
            if (charactersCounter >= 8 ) // above 8
            {
                //Display: OK
                lblOkCharactersLong.Text = msgRequirementOk;
                
            }
            else if (charactersCounter < 8) // below 8 
            {
                //Display: -
                lblOkCharactersLong.Text = msgRequirementNone;
                
            }

           

            //Check total number of digits 
            if (passwordChecker.TotalNoOfDigits >= 1) 
            {
                //Display: OK
                lblOkNumbers.Text = msgRequirementOk;
            }
            else if (passwordChecker.TotalNoOfDigits < 1)
            {
                //Display: -
                lblOkNumbers.Text = msgRequirementNone;
                
            }

            //Check the total number of symbols 
            if (passwordChecker.TotalNoOfSymbols >= 1)
            {
                //Display: OK
                lblOkSymbols.Text = msgRequirementOk;
            }
            else if (passwordChecker.TotalNoOfSymbols < 1)
            {
                //Display: -
                lblOkSymbols.Text = msgRequirementNone;
                
            }


            //User recommendation 
            if (passwordChecker.GetScoreString() == "Strong")
            {
                lstRecommendation.Items.Clear();
                lstRecommendation.Items.Add("No recommendation.Password is strong!");
            }
            else
            {
                //Check all requirements and show recommendation 
                if (lblOkCharactersLong.Text == msgRequirementNone)
                {
                    lstRecommendation.Items.Add("Add at least 8 characters (Minimum is 8)");
                }
                if(lblOkuppercase.Text == msgRequirementNone)
                {
                    lstRecommendation.Items.Add("Add at least one Uppercase letter");
                }
                if(lblOkLowercase.Text == msgRequirementNone)
                {
                    lstRecommendation.Items.Add("Add at lest one Lowercase letter");
                }
                if(lblOkNumbers.Text == msgRequirementNone)
                {
                    lstRecommendation.Items.Add("Add at least one number");
                }
                if(lblOkSymbols.Text == msgRequirementNone)
                {
                    lstRecommendation.Items.Add("Add at least one symbol. E.g. @,#,$,%");
                }
            }  

            
            //Check if confirm password contains text
            if (chkShowHideConfirmPass.Text.Length != 0)
            {
                //Check match
                if (txtPassword.Text != txtConfirmPass.Text)
                {
                    lblMsgConfirmPass.Text = "Not Matching";
                }
                else if (txtPassword.Text == txtConfirmPass.Text)
                {
                    lblMsgConfirmPass.Text = "Match";
                }
            }
            
        }

        private void txtConfirmPass_KeyUp(object sender, KeyEventArgs e)
        {
            //Check for empty password field
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                lblMsgConfirmPass.Visible = true;
                //Check if password is matching
                if (txtPassword.Text != txtConfirmPass.Text)
                {
                    lblMsgConfirmPass.Text = "Not Matching";
                }
                else if (txtPassword.Text == txtConfirmPass.Text)
                {
                    lblMsgConfirmPass.Text = "Match";
                }
            }
        }

        private void chkShowHidePass_Click(object sender, EventArgs e)
        {
            //Hide or show the password based on the checkbox check state
            txtPassword.UseSystemPasswordChar = !chkShowHidePass.Checked;
        }

        private void chkShowHideConfirmPass_Click(object sender, EventArgs e)
        {
            //Hide or show the password based on the checkbox check state
            txtConfirmPass.UseSystemPasswordChar = !chkShowHideConfirmPass.Checked;
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            //Check for empty input 
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                //Check the email
                if (emailChecker.CheckEmail(txtEmail.Text))
                {
                    //Message for user feedback 
                    lblMsgEmail.Text = "Valid email address";
                }
                else
                {
                    //Message for user feedback
                    lblMsgEmail.Text = "Invalid email address";
                }
            }
            else
            {
                lblMsgEmail.Text = "";
            }
        }

        /// <summary>
        /// Show or hide the password 
        /// </summary>
        /// <param name="show"></param>
        private void ViewPasswordAnalysis(bool show)
        {
            if (show)
            {
                Size = new Size(Size.Width + grpPassAnalysis.Size.Width, Size.Height);
                grpPassAnalysis.Visible = true;
            }
            else
            {
                Size = new Size(Size.Width - grpPassAnalysis.Size.Width, Size.Height);
                grpPassAnalysis.Visible = false;
            }
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            ChangeTextBoxColor(txtFirstName);
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            ChangeTextBoxColor(txtLastName);
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            ChangeTextBoxColor(txtEmail);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            ChangeTextBoxColor(txtPassword);
        }

        private void txtConfirmPass_Enter(object sender, EventArgs e)
        {
            ChangeTextBoxColor(txtConfirmPass);
        }

        private void chkMoreAnalysis_Click(object sender, EventArgs e)
        {
            ViewPasswordAnalysis(chkMoreAnalysis.Checked);
        }

        private void chkTwoFactorAuth_Click(object sender, EventArgs e)
        {
            MessageBox.Show(

                       "Two factor authentication will make your account more secure. This option will be activated after the account will be created.\n" +
                       "Follow the instructions after your account is created to activate the two factor authentication", "Two factor authentication",
                       MessageBoxButtons.OK, MessageBoxIcon.Information
                  );

            MultiFactorAuthentication = true;  
            
        }




        /// <summary>
        /// Function to check for empty input.
        /// </summary>
        /// <returns>False if all field are completed. True if not all field are completed</returns>
        private bool InputValidation()
        {
            //Flag for error 
            bool validationError = false;

            //Check all inputs for empty or null. 
            //Fields will be highlighted if there is no input 
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                txtFirstName.BackColor = Color.LightPink;

                if (!validationError)
                {
                    validationError = true;
                }
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                txtLastName.BackColor = Color.LightPink;
                if (!validationError)
                {
                    validationError = true;
                }
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.BackColor = Color.LightPink;
                if (!validationError)
                {
                    validationError = true;
                }
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.BackColor = Color.LightPink;
                if (!validationError)
                {
                    validationError = true;
                }
            }
            if (string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                if (txtConfirmPass.Enabled)
                {
                    txtConfirmPass.BackColor = Color.LightPink;
                }

                if (!validationError)
                {
                    validationError = true;
                }
            }

            return validationError;
        }


        /// <summary>
        /// Check inputs for SQL Injection
        /// </summary>
        /// <returns>True if sql injection is detected</returns>
        private bool SqlInjectionDetected()
        {
            bool injectionDetected = false;
            int sqlInjectionCounter = 0;

            if (db.CheckSqlInjection(txtFirstName.Text))
            {
                injectionDetected = true;
                sqlInjectionCounter++;
            }
            if (db.CheckSqlInjection(txtLastName.Text))
            {
                injectionDetected = true;
                sqlInjectionCounter++;
            }
            if (db.CheckSqlInjection(txtEmail.Text))
            {
                injectionDetected = true;
                sqlInjectionCounter++;
            }
            if (db.CheckSqlInjection(txtPassword.Text))
            {
                injectionDetected = true;
                sqlInjectionCounter++;

            }

            //Notify user if sql injection has been detected
            if (injectionDetected)
            {
                MessageBox.Show(sqlInjectionCounter + " SQL INJECTION DETECTED! \nThis incident will be analysed and investigated. \nThis account will not be created." +
                    "\n\nTry again if this was an error", "SQL INJECTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else // No sql injection detected
            {
                return false;
            }
        }

        /// <summary>
        /// Used to chage the background of a textbox 
        /// </summary>
        /// <param name="txt"></param>
        private void ChangeTextBoxColor(TextBox txt)
        {
            if (txt.BackColor == Color.LightPink)
            {
                txt.BackColor = Color.White;
            }
        }

    }
}
