using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client.Viewmodel
{
    class ArticleWriteViewModel : INotifyPropertyChanged
    {
        private string _articleTitle;
        private byte[] _articleImage;
        private string _articleText;

        // Getters/Setters

        public string ArticleTitle
        {
            get { return _articleTitle; }
            set
            {
                if (_articleTitle != value)
                {
                    _articleTitle = value;
                    OnPropertyChange("ArticleTitle");
                }
            }
        }

        public byte[] ArticleImage
        {
            get { return _articleImage; }
            set
            {
                if (_articleImage != value)
                {
                    _articleImage = value;
                    OnPropertyChange("MandatoryFieldStatus");
                    OnPropertyChange("SubmitStatus");
                }
            }
        }

        public string ArticleText
        {
            get { return _articleText; }
            set
            {
                if (_articleText != value)
                {
                    _articleText = value;
                    OnPropertyChange("ArticleText");
                    OnPropertyChange("MandatoryFieldStatus");
                    OnPropertyChange("SubmitStatus");
                }
            }
        }

        public bool SubmitStatus
        {
            get { return _articleImage != null && _articleText.Trim() != ""; }
        }

        public string MandatoryFieldStatus
        {
            get
            {
                if (_articleImage == null)
                {
                    if (_articleText.Trim() == "")
                        return "Missing the article image and text";
                    return "Missing the article image";
                }
                else if (_articleText.Trim() == "")
                    return "Missing the article text";
                return "";
            }
        }

        // Constructor and functions

        public ArticleWriteViewModel()
        {
            _articleTitle = "";
            _articleImage = null;
            _articleText = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
