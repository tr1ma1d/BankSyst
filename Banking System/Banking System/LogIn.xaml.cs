using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Banking_System.Models;

namespace Banking_System
{
    public partial class LogIn : Window
    {

        public LogIn()
        {
            InitializeComponent();
        }
        private void Windows_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void Auth()
        {
            Users.Email = tbEmailRegister.Text;
            Users.NickName = tbLoginRegister.Text;
            Users.Password = tbPasswordRegister.Text;
            Users.FullName = tbNameRegister.Text;
            Users.Cash = "2999$";
            Users.Phone = tbPhoneRegister.Text;


        }
        private void btLogin_Click(object sender, RoutedEventArgs e)
        {

            Auth();

            bool checkUser = Users.CheckUserRegisterButton();
            if (checkUser == true)
            {
                Users.RegisterUser();
            }
            else
            {
                MessageBox.Show("What is it?");
            }
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
       
       

        private void tbPhoneRegister_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
