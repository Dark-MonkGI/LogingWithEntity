using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogingWithEntity.Model;

namespace LogingWithEntity
{
    public partial class Authorization : Form
    {
        LoginForms loginForms = new LoginForms();
        Context Context = new Context();

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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserVS user = new UserVS
            {
                Loogin = "User",
                Password = "User",
                Details = new UserDetail
                {
                    Address = "World str",
                    Phone = "+79999094455"
                },
                @Department = new Department { Name = "Sales" }
            };

            //user.Department = new Department { Name = "Sales" };
            user.Roles.Add(new Role { Name = "LOne" }); // Коллекция ролей

            Context.MyEntitiesTable.Add(user);
            Context.SaveChanges();

        }

        private void btnGetUser_Click(object sender, EventArgs e)
        {
            UserVS user = Context.MyEntitiesTable.First(u => u.Loogin == "User");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Login: {user.Loogin} Pass: {user.Password}");
            sb.AppendLine($"Addres: {user.Details.Address} Phone: {user.Details.Phone}");
            sb.AppendLine($"Department: {user.Department.Name} Role: {user.Roles.First().Name}");
            MessageBox.Show(sb.ToString());

        }
    }
}
