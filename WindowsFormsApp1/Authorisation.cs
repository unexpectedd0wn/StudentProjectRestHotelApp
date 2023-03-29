using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Authorisation : Form
    {
        DBEntity db = new DBEntity();
        public Authorisation()
        {
            InitializeComponent();
            iconShowPass.Show();
            iconHidePass.Hide();

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == null || txtPassword == null)
            {
                lebelValidMessage.Text = "Логин или Пароль не заполнены";
            }
            try
            {

                User user = db.Users.FirstOrDefault(u => u.Username == txtUserName.Text);

                if (user == null)
                {
                    lebelValidMessage.Text = "Такого пользователя не существует";
                    txtUserName.ResetText();
                    txtPassword.ResetText();
                }
                else
                {
                    if (user.IsActive == false)
                    {
                        lebelValidMessage.Text = "Ваш аккаунт не активен. Свяжитесь с администратором.";
                    }
                    else
                    {
                        if (user.Password != txtPassword.Text)
                        {
                            lebelValidMessage.Text = "Введен неверный пароль";
                        }
                        else
                        {
                            if (user.isAdmininistrator == false)
                            {
                                global.userId = user.Id;
                                global.Username = user.Username;
                                global.Firstname = user.FirstName;
                                global.LastName = user.LastName;
                                global.IsAdministrator = user.isAdmininistrator;
                                this.Hide();

                                mainUser main = new mainUser();
                                main.Show();

                            }
                            else
                            {

                                global.userId = user.Id;
                                global.Username = user.Username;
                                global.Firstname = user.FirstName;
                                global.LastName = user.LastName;
                                global.IsAdministrator = user.isAdmininistrator;
                                this.Hide();

                                mainAdmin main = new mainAdmin();
                                main.Show();

                            }
                        }

                    }
                }
            }
            catch (Exception error)
            {

                MessageBox.Show("Возникла ошибка: " + error.Message, "Свяжитесь с Администратором");
            }
        }

        private void iconHidePass_Click(object sender, EventArgs e)
        {

            txtPassword.UseSystemPasswordChar = true;
            iconShowPass.Show();
            iconHidePass.Hide();
        }

        private void iconShowPass_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            iconShowPass.Hide();
            iconHidePass.Show();
        }

        private void labelForrgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Позвоните по телефону: +7991 114 60 97/n или напишите на почту: example@mail.com");
        }
    }
}
