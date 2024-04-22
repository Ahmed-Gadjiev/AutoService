using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AutoService.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public List<Product> products { get; set; }

        public ProductsPage()
        {
            InitializeComponent();
            products = DB.Connection.Product.ToList();
            ProductGrid.ItemsSource = products;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var b = ProductGrid.SelectedItem as Product;
            NavigationService.Navigate(new AddProductPage(b));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var b = ProductGrid.SelectedItem as Product;

            DB.Connection.Product.Remove(b);
            DB.Connection.SaveChanges();
            products.Remove(b);

            ProductGrid.ItemsSource = products;
        }

        private void SortBook_Click(object sender, RoutedEventArgs e)
        {
            var _sort_type = (sender as RadioButton).Name;

            if(_sort_type == "cost")
            {
                ProductGrid.ItemsSource = products.OrderBy(p => p.Cost);
            }
            else
            {
                ProductGrid.ItemsSource = products.OrderBy(p => p.Title);
            }
        }
    }
}
 