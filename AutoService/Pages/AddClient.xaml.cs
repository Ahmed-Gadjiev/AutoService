using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoService.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public Client client { get; set; }

        public AddClientPage()
        {
            InitializeComponent();
            client = new Client
            {
                RegistrationDate = DateTime.Today
            };

            GenderCombobox.ItemsSource = DB.Connection.Gender.ToList();

            DataContext = this;
        }

        public AddClientPage(Client client)
        {
            InitializeComponent();
            this.client = client;
            GenderCombobox.ItemsSource = DB.Connection.Gender.ToList();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DB.Connection.Client.AddOrUpdate(client);
            DB.Connection.SaveChanges();
            NavigationService.Navigate(new ClientsPage());
        }
    }
}
