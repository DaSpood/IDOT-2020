﻿using System;
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
        private User _author;

        // Getters/Setters

        public Article Article
        {
            get { return _article; }
            set
            {
                if (_article != value)
                {
                    _article = value;
                    _author = BusinessManagement.User.GetUserById(_article.IdAuthor);
                    OnPropertyChange("Title");
                    OnPropertyChange("Author");
                    OnPropertyChange("Date");
                    OnPropertyChange("Viewcount");
                    OnPropertyChange("ImageSource");
                    OnPropertyChange("Text");
                }
            }
        }

        public string TitleAuto
        {
            get { return _article.TitleAuto; }
        }

        public string Author
        {
            get{ return "By " + _author.Name; }
        }

        public string Date
        {
            get { return "On " + _article.Date.ToString("yyyy-MM-dd HH:mm"); }
        }

        public string Viewcount
        {
            get { return _article.Viewcount.ToString() + (_article.Viewcount > 1 ? " views" : " view"); }
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
