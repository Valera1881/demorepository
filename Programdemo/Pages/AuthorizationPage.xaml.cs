using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Programdemo.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();

        }


        private void BEnter_Click(object sender, RoutedEventArgs e)
        {
            var user = MainWindow.DB.User.FirstOrDefault(u => u.Login == TBLogin.Text && u.Password == TBPassword.Text);
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");

                return;
            }
            if (user.RoleId == 1)
            {
                MessageBox.Show("Добро пожаловать, Админ");
                NavigationService.Navigate(new AdminPage());
            }
            if (user.RoleId == 2)
            {
                MessageBox.Show("Добро пожаловать, Менеджер");
                NavigationService.Navigate(new ManagerPage());

            }
            if (user.RoleId == 3)
            {
                MainWindow.LoggedUser = user;
                MessageBox.Show("Добро пожаловать, Клиент");
                NavigationService.Navigate(new ClientPage());

            }
        }

        private void BGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GuestPage());
        }
    }
}
