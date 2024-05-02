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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
            ServiceGrid.ItemsSource = DB.Connection.Service.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var b = ServiceGrid.SelectedItem as Service;
            NavigationService.Navigate(new AddService(b));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Вы действительно хотите удалить данные", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    var b = ServiceGrid.SelectedItem as Service;
                    DB.Connection.Service.Remove(b);
                    DB.Connection.SaveChanges();
                    ServiceGrid.ItemsSource = DB.Connection.Service.ToList(); 
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка удаления из базы данных");
            }
        } 

        private void SortServices_Click(object sender, RoutedEventArgs e)
        {
            var _sort_type = (sender as RadioButton).Name;
            var services = DB.Connection.Service.ToList();

            if (_sort_type == "cost")
            {
                ServiceGrid.ItemsSource = services.OrderBy(p => p.Cost);
            }
            else 
            {
                ServiceGrid.ItemsSource = services.OrderBy(p => p.Title);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddService());

        }
    }
}
