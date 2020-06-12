using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_IDOT_Project.Models;

namespace WPF_IDOT_Project.Views
{
    /// <summary>
    /// Interaction logic for ArticleListPage.xaml
    /// </summary>
    public partial class ArticleListPage : Page
    {
        public ArticleListPage()
        {
            InitializeComponent();

            Article[] articles = null; // BusinessManagement request for articles
            this.Articles.ItemsSource = articles;
        }
    }
}
