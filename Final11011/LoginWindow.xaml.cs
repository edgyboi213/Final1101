using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Final11011
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly UserService _service = new();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var users = await _service.GetAllUsersAsync();

            if (users.Any(x => x.Login == LoginTextBox.Text && x.Password == PasswordTextBox.Text))
            {
                MessageBox.Show("Вы успешно вошли!");
                ShopMainWindow shopMainWindow = new();
                shopMainWindow.WelcomeTextBlock.Visibility = Visibility.Visible;
                shopMainWindow.UserNameTextBlock.Text = $"{users.FirstOrDefault(x => x.Login == LoginTextBox.Text).Surname} {users.FirstOrDefault(x => x.Login == LoginTextBox.Text).Name}";
                this.Close();
                shopMainWindow.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

    }
}
