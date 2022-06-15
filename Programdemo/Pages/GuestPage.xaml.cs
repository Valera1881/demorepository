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
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        public GuestPage()
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
    }
}
