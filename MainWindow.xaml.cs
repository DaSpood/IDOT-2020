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
using WPF_IDOT_Project.ViewModels;

namespace WPF_IDOT_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            // Setup viewmodel for bindings
            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            // Load default page
            PageLoader.Source = new Uri("Views/WIPPage.xaml", UriKind.Relative);
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
            _viewModel.swapState();
            //PageLoader.Navigate(new Uri("Views/CredentialsPage.xaml", UriKind.Relative));
        }
    }
}
