using System.Windows;
using DAL.Services;

namespace Final11011
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShopMainWindow : Window
    {
        private readonly ProductService _service = new();

        public ShopMainWindow()
        {
            InitializeComponent();

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProductsDataGrid.ItemsSource = await _service.GetAllProductsAsync();
        }
    }
}