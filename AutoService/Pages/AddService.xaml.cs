using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для RequestForServicePage.xaml
    /// </summary>
    public partial class AddService : Page
    {
        public Service service { get; set; }

        public AddService()
        {
            InitializeComponent();
            service = new Service();
            DataContext = this;
        }

        public AddService(Service service)
        {
            InitializeComponent();
            this.service = service;
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DB.Connection.Service.AddOrUpdate(service);
            DB.Connection.SaveChanges();
            NavigationService.Navigate(new ClientsPage());
        }
    }
}
