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

            Article[] articles = BusinessManagement.Article.GetArticleList().ToArray();
            this.Articles.ItemsSource = articles;
        }

        private void Articles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Article article = (Article)Articles.SelectedItems[0];
            article.Viewcount = article.Viewcount + 1;
            if (!BusinessManagement.Article.IncrementArticleViewcountById(article.Id))
            {
                MessageBox.Show("Warning: could not update view counter for this article",
                    "Something happened...", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            ((MainWindow)Window.GetWindow(this)).NavigateToArticle(article);
        }
    }
}
