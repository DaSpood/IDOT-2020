using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
    /// Interaction logic for ArticleWritePage.xaml
    /// </summary>
    public partial class ArticleWritePage : Page
    {
        private ArticleWriteViewModel _viewmodel;

        public ArticleWritePage()
        {
            InitializeComponent();

            // Setup viewmodel for bindings
            _viewmodel = new ArticleWriteViewModel();
            DataContext = _viewmodel;
        }

        private void ExplorerButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog browser = new OpenFileDialog();
            browser.InitialDirectory = "c:\\";
            browser.Filter = "Image Files (*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG";
            browser.FilterIndex = 1;
            browser.RestoreDirectory = true;

            if (browser.ShowDialog() == DialogResult.OK)
            {
                string file = browser.FileName;
                try
                {
                    byte[] image = File.ReadAllBytes(file);
                    double size = (double)image.Length / 1024 / 1024;

                    if (size > 2)
                        ArticleImageLink.Text = "This file is too big, maximum size: 2MB";
                    else
                    {
                        ArticleImageLink.Text = "File: " + file + "\t\tSize: " + Math.Round(size, 2) + "MB";
                        _viewmodel.ArticleImage = image;
                    }
                }
                catch (IOException)
                {
                    ArticleImageLink.Text = "There was an error while opening the file";
                }
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string title = _viewmodel.ArticleTitle;
            User author = ((MainWindow)Window.GetWindow(this)).User;
            byte[] image = _viewmodel.ArticleImage;
            string text = _viewmodel.ArticleText;
            //FIXME: Do BusinessManagement request to post new article
        }
    }
}
