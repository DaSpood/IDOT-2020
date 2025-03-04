﻿using System;
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
using WPF_Client.Viewmodel;

namespace WPF_Client.View
{
    /// <summary>
    /// Interaction logic for ArticleDetailPage.xaml
    /// </summary>
    public partial class ArticleDetailPage : Page
    {
        private ArticleDetailViewModel _viewmodel;

        public ArticleDetailPage()
        {
            InitializeComponent();

            // Setup viewmodel for bindings
            _viewmodel = new ArticleDetailViewModel();
            DataContext = _viewmodel;
        }

        public void LoadArticle(Article article)
        {
            _viewmodel.Article = article;
        }
    }
}
