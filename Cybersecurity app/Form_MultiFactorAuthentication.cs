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
    /// <summary>
    /// Class: Database
    /// Write by: Florentin Eduard Decu
    /// Description: This class can be used to validate the multi factor authentication when an account is created or after the account is created
    /// </summary>
    public partial class Form_MultiFactorAuthentication : Form
    {
        private string code;
        private DateTime datetime;
        private string registrationOptionMsg = "You activated the multi-factor-authentication. " +
                                            "An email with an unique code has been sent  to your email account. " +
                                            "Please type in the below text box the unique code to active this option. " +
                                            "If you close this window this option will be disable";

        private string afterLoginOptionMsg = "An email with an unique code has been sent to your email account. " +
                                            "Please type the unique code in the below text box to authenticate your account.";

        private bool afterLogin;

        public bool AuthEnable { get; private set; }

        /// <summary>
        /// Constractor with parameters
        /// </summary>
        /// <param name="code">A unique code</param>
        /// <param name="datetime">The creatio time of the unique code</param>
        /// <param name="afterLogin">Specify if the multi factor authentication is activated when user is created or after the user is created</param>
        public Form_MultiFactorAuthentication(string code, DateTime datetime, bool afterLogin = false)
        {
            InitializeComponent();

            this.code = code;
            this.datetime = datetime;
            this.afterLogin = afterLogin;

            
        }


        private void Form_MultiFactorAuthentication_Load(object sender, EventArgs e)
        {
            //Add five minutes to the code time
            datetime = datetime.AddMinutes(5);
            //Display message to notify the user when the code will expire
            lblExpire.Text = "Unique code will expire at: " + datetime.ToString("dd/MM/yyyy HH:mm:ss");
            

            if (afterLogin)
            {
                lblMsg.Text = afterLoginOptionMsg;
            }
            else
            {
                lblMsg.Text = registrationOptionMsg;
            }
        }


        private void btnActivate_Click(object sender, EventArgs e)
        {
            //Check for empty field
            if (!string.IsNullOrEmpty(txtUniqueCode.Text))
            {
                //Check if unique code matche
                if (code == txtUniqueCode.Text)
                {
                    //Check if 5 minutes have passed since the code was created
                    if (DateTime.Now.Minute > (datetime.Minute+5))
                    {
                        //Notify user - code expired 
                        MessageBox.Show("The unique code is no longer valid. \n Multi Factor Authentication will no longer be activated. \n Please try again later from your account settings");
                        AuthEnable = false;

                    }
                    else
                    { 
                        //Check if multi factor authentication is activated after login 
                        if (!afterLogin) // when user is creating the account 
                        {
                            MessageBox.Show("Multi Factor authentication has been succesfully activated!\n You can use your account to login now.\n " +
                            "Next time you will log in you will receive an email with an unique code that must be used as part of authentication.");
                        }
                        else 
                        {
                            MessageBox.Show("Multi Factor Authentication has been succesfully activated!\n");
                        }
                        
                        AuthEnable = true;
                    }
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("No code has been added!");
            }

        }

       
    }
}
