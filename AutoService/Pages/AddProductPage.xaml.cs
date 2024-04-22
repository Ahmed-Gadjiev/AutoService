using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Data.Entity.Migrations;

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
            DataContext = this;
        }

        public AddProductPage()
        {
            InitializeComponent();

            product = new Product
            {
                IsActive = true
            };

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
