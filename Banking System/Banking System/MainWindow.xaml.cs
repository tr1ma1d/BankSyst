using Banking_System.Models;
using System.Windows;
using System.Windows.Input;



namespace Banking_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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


        // button

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            Users.NickName = tbLogin.Text;
            Users.Password = tbPassword.Text;

            bool boolSign = Users.SignIn();
            if(boolSign == true)
            {
                bool boolEmp = Users.CheckEmployes();
                if (boolEmp == true)
                {
                    MessageBox.Show("yeah bro");
                }
                else
                {
                    MainPage mainPage = new MainPage();
                    try
                    {
                        this.Close();
                        mainPage.Show();
                    }
                    catch { }
                }      
            }
            else
            {
                MessageBox.Show("Попробуйте еще");
            }
        }

        private void btLogIn_Click_1(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            try
            {
                if (logIn != null)
                {
                    this.Close();
                    logIn.Show();

                }
            }
            catch
            {

            }
        }
    }
}
