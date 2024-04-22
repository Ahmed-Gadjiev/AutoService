using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AutoService.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public List<Client> clients { get; set; }

        public ClientsPage()
        {
            InitializeComponent();
            clients = DB.Connection.Client.ToList();
            ClientGrid.ItemsSource = clients;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var b = ClientGrid.SelectedItem as Client;
            NavigationService.Navigate(new AddClientPage(b));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var b = ClientGrid.SelectedItem as Client;

            DB.Connection.Client.Remove(b);
            DB.Connection.SaveChanges();
            clients.Remove(b);

            ClientGrid.ItemsSource = clients;
        }

        private void SortBook_Click(object sender, RoutedEventArgs e)
        {
            var _sort_type = (sender as RadioButton).Name;

            if (_sort_type == "cost")
            {
                ClientGrid.ItemsSource = clients.OrderBy(p => p.FirstName);
            }
            else
            {
                ClientGrid.ItemsSource = clients.OrderBy(p => p.LastName);
            }
        }
    }
}
