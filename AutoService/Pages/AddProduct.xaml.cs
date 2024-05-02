using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AutoService.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public Product product { get; set; }
        
        public AddProductPage(Product product)
        {
            InitializeComponent();

            this.product = product;
            ManufacturerComboBox.ItemsSource = DB.Connection.Manufacturer.ToList();

            DataContext = this;
        }

        public AddProductPage()
        {
            InitializeComponent();

            product = new Product
            {
                IsActive = true
            };
            ManufacturerComboBox.ItemsSource = DB.Connection.Manufacturer.ToList();

            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DB.Connection.Product.AddOrUpdate(product);

            DB.Connection.SaveChanges();
            NavigationService.Navigate(new ProductsPage());
        }
    }
}
