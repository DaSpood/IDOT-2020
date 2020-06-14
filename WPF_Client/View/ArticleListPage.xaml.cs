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
using WPF_Client.Dbo;

namespace WPF_Client.View
{
    /// <summary>
    /// Interaction logic for ArticleListPage.xaml
    /// </summary>
    public partial class ArticleListPage : Page
    {
        public ArticleListPage()
        {
            InitializeComponent();

            Article[] articles = null; //FIXME: Do BusinessManagement request for a list of Dbo.Article
            this.Articles.ItemsSource = articles;
        }

        private void Articles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((MainWindow)Window.GetWindow(this)).NavigateToArticle((Article)Articles.SelectedItem);
        }
    }
}
