using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cybersecurity_app
{
    public partial class Form_Login : Form
    {
        private Database db;
        private Encryption encrypt;
        private User user;
        private EmailServices emailServices;
        private EmailChecker emailChecker;
        private const string codeCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$";
        private string uniqueCode;
        private DateTime dateTimeCode;



        public Form_Login()
        {
            InitializeComponent();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            //Initial all properties 
            db = new Database();
            encrypt = new Encryption();
            emailServices = new EmailServices();
            emailChecker = new EmailChecker();
            panelEmail.Visible = false;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            //Initialise registretion form tp create new account
            using (Form_RegisterAccount createAccount = new Form_RegisterAccount())
            {
                //Show form and check the resul 
                if (createAccount.ShowDialog() == DialogResult.OK)
                {
                    //Get the created user from the form 
                    user = createAccount.User;
                    //Show panel to notify the user that an email is sending
                    panelEmail.Visible = true;

                    //Check if the multi factor authentication has been selected
                    if (user.MultiFactorAuthentication)
                    {
                        //Create query to take the user's id from the database
                        string query = "SELECT ID FROM users WHERE email = @email";

                        //Store returned data from database. Query database. Add parameter email
                        DataTable dt = db.QueryReader(query, p => { p.Add("email", DbType.String).Value = user.Email; });

                        //Check if there is any data returned 
                        if (dt.Rows.Count != 0)
                        {
                            //Initialise the user's id with the id from database
                            user.Id = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        }

                        //Create a random code 
                        uniqueCode = CreateRandomCode(10);
                        //Create a time to determinate when the code was created 
                        dateTimeCode = DateTime.Now;

                        //Create a query to insert the code into database
                        query = "INSERT INTO unique_codes (user_id, code, time) VALUES (@userID, @code, @time)";

                        //Query the database. add parameters 
                        db.NonQuery(query, p =>
                        {
                            p.Add("@userID", DbType.Int32).Value = user.Id;
                            p.Add("@code", DbType.String).Value = uniqueCode;
                            p.Add("@time", DbType.DateTime).Value = dateTimeCode;

                        });

                        //Send email to the user with the created code 
                        emailServices.SendEmail(encrypt.DecryptData(user.Email), uniqueCode);

                        //Initialse the multi factor authentication form 
                        using (Form_MultiFactorAuthentication multiFactorAuth = new Form_MultiFactorAuthentication(uniqueCode, dateTimeCode))
                        {
                            //Show form and check the result 
                            if (multiFactorAuth.ShowDialog() == DialogResult.OK)
                            {
                                //Check if the multi factor authentication has been succesfully created
                               if (!multiFactorAuth.AuthEnable)
                                {
                                    //Create query to delete the code form database
                                    query = "DELETE FROM unique_codes WHERE code = @code and user_id = @userID";

                                    //Query database
                                    db.NonQuery(query, p => 
                                    {
                                        p.Add("@code", DbType.String).Value = uniqueCode;
                                        p.Add("@userID", DbType.Int32).Value = user.Id;

                                    });

                                    //Create query to update the user's multi factor authentication 
                                    query = "UPDATE users SET two_factor_authentication = false WHERE ID = @userID";

                                    //Query the database
                                    db.NonQuery(query, p => { p.Add("@userID", DbType.Int32).Value = user.Id; });
                                }
                            }

                        }
                    }

                    //Hide the information panel 
                    panelEmail.Visible = false;
                    //Populat the field for login. Decrypt the user's data
                    txtEmail.Text = encrypt.DecryptData(user.Email);
                    txtPassword.Text = encrypt.DecryptData(user.Password);
                }
            }

            

        }

        /// <summary>
        /// Function used to crate random code
        /// </summary>
        /// <param name="lenght"></param>
        /// <returns></returns>
        private string CreateRandomCode(int lenght)
        {
            
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < lenght--)
            {
                res.Append(codeCharacters[rnd.Next(codeCharacters.Length)]);
            }
            return res.ToString();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Check input validation
            if (!ValidationError())
            {
                //Check for sql injection
                if (!SqlInjectionDetected())
                {
                    //Check if email is valid
                    if (emailChecker.CheckEmail(txtEmail.Text))
                    {
                        //Create query to selecte the user's info 
                        string query = "SELECT * FROM users WHERE email = @email and password = @password";

                        //Create table to store the data from database
                        DataTable dt = db.QueryReader(query, p =>
                        {
                            p.Add("@email", DbType.String).Value = encrypt.EncryptData(txtEmail.Text);
                            p.Add("@password", DbType.String).Value = encrypt.EncryptData(txtPassword.Text);
                        });

                        //Check for result (empty returns means there is no row)
                        if (dt.Rows.Count != 0)
                        {
                            //Store the data from datatabase 
                            string dbEmail = dt.Rows[0]["email"].ToString();
                            string dbPassword = dt.Rows[0]["password"].ToString();
                            string dbId = dt.Rows[0]["ID"].ToString();
                            string dbFirstName = dt.Rows[0]["first_name"].ToString();
                            string dbLastName = dt.Rows[0]["last_name"].ToString();
                            bool dbMultiFactorAuth = (bool)dt.Rows[0]["two_factor_authentication"];

                            //Check for second time if email and password are correct 
                            if (encrypt.DecryptData(dbEmail) == txtEmail.Text && encrypt.DecryptData(dbPassword) == txtPassword.Text)
                            {
                                //Check if user object is created
                                if (user == null)
                                {
                                    //Create user object 
                                    user = new User();
                                }

                                //Initialise all properties with the data from database
                                user.Id = Convert.ToInt32(dbId);
                                user.FirstName = dbFirstName;
                                user.LastName = dbLastName;
                                user.Email = dbEmail;
                                user.Password = dbPassword;
                                user.MultiFactorAuthentication = dbMultiFactorAuth;

                                if (!user.MultiFactorAuthentication)
                                {
                                    //Create main form 
                                    Form_Main mainForm = new Form_Main(user);
                                    //Hide this form 
                                    Hide();
                                    //Show main form
                                    mainForm.ShowDialog();
                                    //Close this form 
                                    Close();
                                }
                                else
                                {

                                    panelEmail.Visible = true;
                                    lblMauthTile.Text = "Authentication code";
                                    lblMsgMauth.Visible = false;
                                    txtCode.Visible = true;

                                    //Create a random code 
                                    uniqueCode = CreateRandomCode(10);
                                    //Create a time to determinate when the code was created 
                                    dateTimeCode = DateTime.Now;

                                    //Create a query to insert the code into database
                                    query = "Update unique_codes SET code = @code, time = @time WHERE user_id = @userID";

                                    //Query the database. add parameters 
                                    db.NonQuery(query, p =>
                                    {
                                        p.Add("@userID", DbType.Int32).Value = user.Id;
                                        p.Add("@code", DbType.String).Value = uniqueCode;
                                        p.Add("@time", DbType.DateTime).Value = dateTimeCode;

                                    });

                                    Task.Run(() => 
                                    {
                                        //Send email to the user with the created code 
                                        emailServices.SendEmail(encrypt.DecryptData(user.Email), uniqueCode);
                                    });
                                    MessageBox.Show("Multi factor authentication is enabled. An email has been send with a validation code.");
                                    
                                }

                            }
                            else
                            {
                                //Notify user whne passowrd or email is wrong from second check (databse result)
                                MessageBox.Show("Email or password is wrong!");
                            }
                        }
                        else
                        {
                            //Notify user whne passowrd or email is wrong from first check (user's input)
                            MessageBox.Show("Email or password is wrong!");
                        }
                    }
                    else
                    {
                        //Notifiy user- invalid email
                        MessageBox.Show("Invalid email");
                    }
                    
                }
            }
            else
            {
                //Notify user when is empty field 
                MessageBox.Show("You must complete all fields");
            }
        }

        /// <summary>
        /// Function used to check all fields for empty input
        /// </summary>
        /// <returns></returns>
        private bool ValidationError()
        {
            //Flag for input error 
            bool validationError = false;

            //Check  email field 
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                //Check if validation is false
                if (!validationError)
                {
                    //Set flag to true
                    validationError = true;
                }
            }
            //Check password field 
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                //Check if validation error is false
                if (!validationError)
                {
                    //Set flag to truw
                    validationError = true;
                }
            }

            //Retunr the validation error 
            return validationError;
        }

        /// <summary>
        /// Function used to check sql injection
        /// </summary>
        /// <returns></returns>
        private bool SqlInjectionDetected()
        {
            //Sql injection counter - store how many injections have been found 
            int sqlInjectionCounter = 0;

            //Check the email field for sql injection
            if (db.CheckSqlInjection(txtEmail.Text))
            {
                //Count +1
                sqlInjectionCounter++;
            }
            //Check the password field for sql injection 
            if (db.CheckSqlInjection(txtPassword.Text))
            {
                //Count +1
                sqlInjectionCounter++;
            }

            //Check counter 
            if (sqlInjectionCounter > 0)
            {
                //Show message to notify the user for sql injection 
                MessageBox.Show(sqlInjectionCounter + " SQL INJECTION DETECTED! \nThis incident will be analysed and investigated." +
                   "\nTry again if this was an error", "SQL INJECTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void chkShowHidePass_Click(object sender, EventArgs e)
        {
            //Show or hide passsword
            txtPassword.UseSystemPasswordChar = !chkShowHidePass.Checked;
        }

        private void btnLoginAuthentication_Click(object sender, EventArgs e)
        {
            //Check for empty field
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                //Check if unique code matche
                if (uniqueCode == txtCode.Text)
                {
                    //Check if 5 minutes have passed since the code was created
                    if (DateTime.Now.Minute > (dateTimeCode.Minute + 5))
                    {
                        //Notify user - code expired 
                        MessageBox.Show("The unique code is no longer valid. \n Authentication failed!");
                    }
                    else
                    {
                        //Create main form 
                        Form_Main mainForm = new Form_Main(user);
                        //Hide this form 
                        Hide();
                        //Show main form
                        mainForm.ShowDialog();
                        //Close this form 
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid code.");
                }
            }
            else
            {
                MessageBox.Show("No code has been added!");
            }
        }
    }
}
