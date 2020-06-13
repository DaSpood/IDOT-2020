using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WPF_Client.Dbo;

namespace WPF_Client.Viewmodel
{
    class ArticleDetailViewModel : INotifyPropertyChanged
    {
        private Article _article;

        // Getters/Setters

        public Article Article
        {
            get { return _article; }
            set
            {
                if (_article != value)
                {
                    _article = value;
                    OnPropertyChange("Title");
                    OnPropertyChange("Author");
                    OnPropertyChange("Date");
                    OnPropertyChange("Viewcount");
                    OnPropertyChange("ImageSource");
                    OnPropertyChange("Text");
                }
            }
        }

        public string Title
        {
            get { return _article.Title; }
        }

        public string Author
        {
            get
            {
                return "TODO";
            }
        }

        public string Date
        {
            get { return "On " + _article.Date.ToString(); }
        }

        public string Viewcount
        {
            get { return _article.Viewcount.ToString(); }
        }

        public BitmapSource ImageSource
        {
            get { return _article.ImageSource; }
        }

        public string Text
        {
            get { return _article.Text; }
        }

        // Constructors and functions

        public ArticleDetailViewModel()
        {
            _article = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
