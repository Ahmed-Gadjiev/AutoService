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
        public List<Service> services { get; set; }

        public ServicePage()
        {
            InitializeComponent();
            services = DB.Connection.Service.ToList();
            ServiceGrid.ItemsSource = services;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var b = ServiceGrid.SelectedItem as Service;
            NavigationService.Navigate(new RequestForServicePage(b));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var b = ServiceGrid.SelectedItem as Service;

            DB.Connection.Service.Remove(b);
            DB.Connection.SaveChanges();
            services.Remove(b);

            ServiceGrid.ItemsSource = services;
        }

        private void SortBook_Click(object sender, RoutedEventArgs e)
        {
            var _sort_type = (sender as RadioButton).Name;

            if (_sort_type == "cost")
            {
                ServiceGrid.ItemsSource = services.OrderBy(p => p.Cost);
            }
            else
            {
                ServiceGrid.ItemsSource = services.OrderBy(p => p.Title);
            }
        }
    }
}
