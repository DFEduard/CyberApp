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

        public Form_Login()
        {
            InitializeComponent();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            db = new Database();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            using (Form_RegisterAccount createAccount = new Form_RegisterAccount())
            {
                if (createAccount.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
