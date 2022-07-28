using LogingWithEntity.Model;
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
    public partial class LoginForms : Form
    {
        public bool isLoginSuccess { get; private set; }
        Context context = new Context(); // предостовляет доступ к самой бд
        Task task;

        public LoginForms()
        {
            InitializeComponent();
            isLoginSuccess = false;

            //Делаем асинхронно запрос к БД
            task = Task.Run(() =>
            {
                context.MyEntitiesTable.ToList(); //загрузим таблицу
            }); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            task.Wait();
            //запрос к таблице
            UserVS logineduserVS = context.MyEntitiesTable.FirstOrDefault(user => user.Loogin == tbLogin.Text && user.Password == tbPassword.Text); //функция возвращает первый элемент в таблице, соответствующий условию в скобках


            //isLoginSuccess = logineduserVS != null; //аналогично

            if (logineduserVS != null)
            {
                isLoginSuccess = true;
            }
            else
            {
                isLoginSuccess = false;
            }


            Close();
        }
    }
}
