using System.Windows;
using System.Windows.Navigation;
using AutoService.Pages;

namespace AutoService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServicePage());
        }

        private void RequestOfService_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddService());
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage());
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientsPage());
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddProductPage());
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddClientPage());
        }
        private void RequestsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RequestsPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();    
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void MainFrame_Navigated_1(object sender, NavigationEventArgs e)
        {

        }
    }
}
