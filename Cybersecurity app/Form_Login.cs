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
    public partial class Form_Login : Form
    {
        private Database db;
        private Encryption encrypt;
        private const string codeCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+{}:|<>?[];',./";
        

        public Form_Login()
        {
            InitializeComponent();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            db = new Database();
            encrypt = new Encryption();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            using (Form_RegisterAccount createAccount = new Form_RegisterAccount())
            {
                if (createAccount.ShowDialog() == DialogResult.OK)
                {

                    if (createAccount.MultiFactorAuthentication)
                    {

                        string query = "SELECT id FROM users WHERE email = @email";
                        int userId = -1;

                        try
                        {
                            DataTable dt = db.QueryReader(query);

                            if (dt.Rows.Count != 0)
                            {
                                userId = (int)dt.Rows[0]["id"];
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something went wrong. Please try again later!");
                        }
                        
                        string uniqueCode = CreateRandomPassword(10);
                        DateTime dateTimeCode = DateTime.Now;

                        using (Form_MultiFactorAuthentication multiFactorAuth = new Form_MultiFactorAuthentication(uniqueCode, dateTimeCode))
                        {
                            if (createAccount.ShowDialog() == DialogResult.OK)
                            {
                                query = "INSERT INTO unique_code (user_id, code, time) VALUES (@userID, @code, @time)";

                                try
                                {
                                    db.NonQuery(query, p =>
                                    {
                                        p.Add("@userID", DbType.Int32).Value = userId;
                                        p.Add("@code", DbType.String).Value = uniqueCode
                                        p.Add("@time", DbType.DateTime).Value = dateTimeCode;

                                    });
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Something went wrong. Please try again later!");
                                }
                                
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
        }


        private string CreateRandomPassword(int lenght)
        {
            
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < lenght--)
            {
                res.Append(codeCharacters[rnd.Next(codeCharacters.Length)]);
            }
            return res.ToString();

        }
    }
}
