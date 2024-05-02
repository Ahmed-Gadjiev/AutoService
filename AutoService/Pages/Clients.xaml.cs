using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace AutoService.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private DbSet<Client> Clients { get; set; }
        private AutoServiceEntities1 connection { get; set; }

        public ClientsPage()
        {
            InitializeComponent();
            

            //ClientGrid.ItemsSource = Clients.();
            GetClientsAsync();
        }

        private async void GetClientsAsync()
        {
            ClientGrid.ItemsSource = await DB.Connection.Client.ToListAsync();
        }

        //private async void GetConnection()
        //{
        //    connection = await DB.Connection.Client.Async;
        //}


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var b = ClientGrid.SelectedItem as Client;
            NavigationService.Navigate(new AddClientPage(b));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Вы действительно хотите удалить данные", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes) 
                {
                    var b = ClientGrid.SelectedItem as Client;

                    Clients.Remove(b);
                    DB.Connection.SaveChanges();

                    ClientGrid.ItemsSource = Clients.ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка удаления из базы данных");
            }
        }

        private void SortClients_Click(object sender, RoutedEventArgs e)
        {
            var _sort_type = (sender as RadioButton).Name;
            var clients = Clients.ToList();

            switch(_sort_type)
            {
                case "name":
                    ClientGrid.ItemsSource = clients.OrderBy(p => p.FirstName);
                    break;
                case "surname":
                    ClientGrid.ItemsSource = clients.OrderBy(p => p.LastName);
                    break;
                case "register_date":
                    ClientGrid.ItemsSource = clients.OrderBy(p => p.RegistrationDate);
                    break;
                case "birthday":
                    ClientGrid.ItemsSource = clients.OrderBy(p => p.Birthday);
                    break;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClientPage());
        }
    }
}
