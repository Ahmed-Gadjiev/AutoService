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

namespace AutoService.Pages
{
    /// <summary>
    /// Логика взаимодействия для Requests.xaml
    /// </summary>
    public partial class RequestsPage : Page
    {
        public RequestsPage()
        {
            InitializeComponent();
            RequestGrid.ItemsSource = DB.Connection.ClientService.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRequestPage());
        }

        private void SortRequests_Click(object sender, RoutedEventArgs e)
        {
            var _sort_type = (sender as RadioButton).Name;
            var requests = DB.Connection.ClientService.ToList();

            if (_sort_type == "clients")
            {
                RequestGrid.ItemsSource = requests.OrderBy(p => p.Client.ToString());
            }
            else 
            {
                RequestGrid.ItemsSource = requests.OrderBy(p => p.Service.ToString());
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var b = RequestGrid.SelectedItem as ClientService;
            NavigationService.Navigate(new AddRequestPage(b));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Вы действительно хотите удалить данные", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    var b = RequestGrid.SelectedItem as ClientService;
                    DB.Connection.ClientService.Remove(b);
                    DB.Connection.SaveChanges();
                    RequestGrid.ItemsSource = DB.Connection.ClientService.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка удаления из базы данных");
            }
        }
    }
}
