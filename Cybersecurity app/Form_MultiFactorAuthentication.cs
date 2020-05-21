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
    public partial class Form_MultiFactorAuthentication : Form
    {
        private string code;
        private DateTime datetime;

        public Form_MultiFactorAuthentication( string code, DateTime datetime)
        {
            InitializeComponent();

            this.code = code;
            this.datetime = datetime;

            datetime = datetime.AddMinutes(10);

            lblExpire.Text = datetime.ToString("DD/mm/yyyy HH:mm:ss");
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUniqueCode.Text))
            {
                if (code == txtUniqueCode.Text)
                {
                    if ((datetime.Minute+10) < DateTime.Now.Minute)
                    {
                        MessageBox.Show("Multi Factor authentication has been succesfully activated!");
                    }
                    else
                    {
                        MessageBox.Show("The unique code is no longer valid");
                    }
                }
            }
            else
            {
                MessageBox.Show("No code has been added!");
            }

        }
    }
}
