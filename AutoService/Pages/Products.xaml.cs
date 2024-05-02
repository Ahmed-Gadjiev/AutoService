using System;
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

        public ProductsPage()
        {
            InitializeComponent();
            ProductGrid.ItemsSource = DB.Connection.Product.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var b = ProductGrid.SelectedItem as Product;
            NavigationService.Navigate(new AddProductPage(b));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Вы действительно хотите удалить данные", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if(result == MessageBoxResult.Yes)
                {
                    var b = ProductGrid.SelectedItem as Product;
                    DB.Connection.Product.Remove(b);
                    DB.Connection.SaveChanges();
                    ProductGrid.ItemsSource = DB.Connection.Product.ToList();
                }
            } 
            catch (Exception)
            {
                MessageBox.Show("Ошибка удаления из базы данных");
            }
        }

        private void SortBook_Click(object sender, RoutedEventArgs e)
        {
            var _sort_type = (sender as RadioButton).Name;
            var products = DB.Connection.Product.ToList();

            if(_sort_type == "cost")
            {
                ProductGrid.ItemsSource = products.OrderBy(p => p.Cost);
            }
            else
            {
                ProductGrid.ItemsSource = products.OrderBy(p => p.Title);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }
    }
}
 