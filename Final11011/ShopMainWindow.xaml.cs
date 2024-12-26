using System.Windows;
using System.Windows.Controls;
using DAL.Services;

namespace Final11011
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShopMainWindow : Window
    {
        private readonly ProductService _productService = new();
        private readonly UserService _userService = new();

        public ShopMainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var products = await _productService.GetAllProductsAsync();
            ShopGrid.DataContext = products;


            foreach (var product in products)
            {
                // объявление элементов
                StackPanel shopStackPanel = new();
                Border border = new();
                TextBlock nameTextBlock = new();
                TextBlock descriptionTextBlock = new();
                TextBlock costTextBlock = new();
                Button orderButton = new();

                // настройка стиля границы
                border.BorderBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
                border.BorderThickness = new Thickness(1);
                border.Margin = new Thickness(20);
                border.Width = 400;

                // привязка и настройка TextBlock-ов
                nameTextBlock.Text = product.Name;
                nameTextBlock.HorizontalAlignment = HorizontalAlignment.Left;

                descriptionTextBlock.Text = product.Description;
                descriptionTextBlock.HorizontalAlignment = HorizontalAlignment.Left;

                costTextBlock.Text = product.Cost.ToString();
                costTextBlock.HorizontalAlignment = HorizontalAlignment.Left;

                // настройка Button
                orderButton.Content = "Заказать";
                orderButton.Width = 100;
                orderButton.HorizontalAlignment = HorizontalAlignment.Right;
                
                // добавление в StackPanel
                shopStackPanel.Children.Add(nameTextBlock);
                shopStackPanel.Children.Add(descriptionTextBlock);
                shopStackPanel.Children.Add(costTextBlock);
                shopStackPanel.Children.Add(orderButton);
                border.Child = shopStackPanel;

                ProductsStackPanel.Children.Add(border);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            WelcomeTextBlock.Visibility = Visibility.Hidden;
            UserNameTextBlock.Visibility = Visibility.Hidden;
        }
    }
}
