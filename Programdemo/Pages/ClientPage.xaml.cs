using Programdemo.ModelApp;
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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            var filtered = MainWindow.DB.Product.ToList();
            if (!string.IsNullOrWhiteSpace(TBSearch.Text))
                filtered = filtered.Where(f => f.Title.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            LVProduct.ItemsSource = filtered;

        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthorizationPage());
        }

        private void TBSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void LVProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sproduct = LVProduct.SelectedItem as Product;
            if (sproduct == null)
                return;
            if (MessageBox.Show("Вы хотите заказать?", "", MessageBoxButton.YesNo) ==MessageBoxResult.Yes)
            {
                MainWindow.DB.Order.Add(new Order { ProductId = sproduct.IdProduct, UserId = MainWindow.LoggedUser.IdUser });
                MainWindow.DB.SaveChanges();
                MessageBox.Show("Заказ успешно добавлен в корзину");
                Refresh();
            }

        }

        private void BOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage());
        }
    }
}
