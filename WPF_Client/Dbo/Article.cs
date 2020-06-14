using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_Client.Dbo
{
    public class Article
    {
        private long _id;
        private string _title;
        private long _idAuthor;
        private DateTime _date;
        private byte[] _image;
        private string _text;
        private long _viewcount;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string TitleAuto
        {
            get { return _title != "" ? _title : "Article #" + _id.ToString(); }
        }

        public long IdAuthor
        {
            get { return _idAuthor; }
            set { _idAuthor = value; }
        }

        public System.DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public byte[] Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public BitmapSource ImageSource
        {
            get{ return (BitmapSource)new ImageSourceConverter().ConvertFrom(_image); }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string TextTrimmed
        {
            get
            {
                string tmp = _text.Replace('\r', ' ');
                tmp = tmp.Replace('\n', ' ');
                if (tmp.Length > 60)
                    return tmp.Substring(0, 60) + "...";
                return tmp;
            }
        }

        public long Viewcount
        {
            get { return _viewcount; }
            set { _viewcount = value; }
        }

        public Article(long id, string title, long author, System.DateTime date, byte[] image, string text, long viewcount)
        {
            _id = id;
            _title = title;
            _idAuthor = author;
            _date = date;
            _image = image;
            _text = text;
            _viewcount = viewcount;
        }

        public Article(string title, long author, byte[] image, string text)
        {
            _id = -1;
            _title = title;
            _idAuthor = author;
            _date = DateTime.Now;
            _image = image;
            _text = text;
            _viewcount = 0;
        }
    }
}
