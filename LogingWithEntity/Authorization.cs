using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogingWithEntity
{
    public partial class Authorization : Form
    {
        LoginForms loginForms = new LoginForms();

        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            loginForms.ShowDialog();
            if (loginForms.isLoginSuccess)
            {
                lbAuthRes.Text = "Succes!";
                lbAuthRes.ForeColor = Color.Green;
            }
            else
            {
                lbAuthRes.Text = "Access Denied!";
                lbAuthRes.ForeColor = Color.Red;
            }
        }
    }
}
