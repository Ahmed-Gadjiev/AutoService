using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AutoService.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddRequest.xaml
    /// </summary>
    public partial class AddRequestPage : Page
    {
        public ClientService request { get; set; }

        public AddRequestPage()
        {
            InitializeComponent();
            request = new ClientService();
            ClientComboBox.ItemsSource = DB.Connection.Client.ToList();
            ServiceComboBox.ItemsSource = DB.Connection.Service.ToList();
            request.StartTime = DateTime.Now;
            DataContext = this;
        }

        public AddRequestPage(ClientService request)
        {
            InitializeComponent();
            this.request = request;
            ClientComboBox.ItemsSource = DB.Connection.Client.ToList();
            ServiceComboBox.ItemsSource = DB.Connection.Service.ToList();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DB.Connection.ClientService.AddOrUpdate(request);
            DB.Connection.SaveChanges();
            NavigationService.Navigate(new RequestsPage());
        }
    }
}
