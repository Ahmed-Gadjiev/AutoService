using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Windows;
using System.Windows.Controls;

namespace AutoService.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        private Client client { get; set; }

        public AddClientPage()
        {
            InitializeComponent();

            client = new Client();
            

            dateRegistration.SelectedDate = DateTime.Now;
            DataContext = this;
        }

        public AddClientPage(Client client)
        {
            InitializeComponent();

            this.client = client;
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.Connection.Client.AddOrUpdate(client);

                DB.Connection.SaveChanges();
                NavigationService.Navigate(new ClientsPage());
            }
            catch (DbEntityValidationException error)
            {
                throw error;
            }
        }
    }
}
