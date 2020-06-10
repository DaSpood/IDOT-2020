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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_IDOT_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ButtonToCredentialsText.Text = "Login / Register";
            ButtonToCredentialsIcon.Source = new BitmapImage(new Uri("Resources/user.png", UriKind.Relative));
        }

        private void ButtonToHomePage_Click(object sender, RoutedEventArgs e)
        {
            PageLoader.Navigate(new Uri("Views/WIPPage.xaml", UriKind.Relative));
            //PageLoader.Navigate(new Uri("Views/ArticleListPage.xaml", UriKind.Relative));
        }

        private void ButtonToNewPage_Click(object sender, RoutedEventArgs e)
        {
            PageLoader.Navigate(new Uri("Views/WIPPage.xaml", UriKind.Relative));
            //PageLoader.Navigate(new Uri("Views/ArticleNewPage.xaml", UriKind.Relative));
        }

        private void ButtonToCredentials_Click(object sender, RoutedEventArgs e)
        {
            PageLoader.Navigate(new Uri("Views/WIPPage.xaml", UriKind.Relative));
            //PageLoader.Navigate(new Uri("Views/CredentialsPage.xaml", UriKind.Relative));

            //Note: max username length: 40
        }
    }
}
