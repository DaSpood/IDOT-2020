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
using WPF_Client.Dbo;
using WPF_Client.Viewmodel;

namespace WPF_Client.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            // Setup viewmodel for bindings
            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            // Load default page
            PageLoader.Source = new Uri("pack://application:,,,/View/WIPPage.xaml", UriKind.RelativeOrAbsolute);
        }

        public User GetUser()
        {
            return _viewModel.User;
        }

        private void ButtonToHomePage_Click(object sender, RoutedEventArgs e)
        {
            PageLoader.Navigate(new Uri("pack://application:,,,/View/WIPPage.xaml", UriKind.RelativeOrAbsolute));
            //PageLoader.Navigate(new Uri("pack://application:,,,/View/ArticleListPage.xaml", UriKind.RelativeOrAbsolute));
            ButtonToCredentials.IsEnabled = true;
        }

        private void ButtonToNewPage_Click(object sender, RoutedEventArgs e)
        {
            PageLoader.Navigate(new Uri("pack://application:,,,/View/ArticleWritePage.xaml", UriKind.RelativeOrAbsolute));
            ButtonToCredentials.IsEnabled = false;
        }

        private void ButtonToCredentials_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.swapState();
            //PageLoader.Navigate(new Uri("pack://application:,,,/View/CredentialsPage.xaml", UriKind.RelativeOrAbsolute));
            ButtonToCredentials.IsEnabled = true;
        }
    }
}
