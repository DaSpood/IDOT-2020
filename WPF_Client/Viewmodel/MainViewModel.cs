using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WPF_Client.Dbo;

namespace WPF_Client.Viewmodel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private User _user;

        private readonly BitmapImage _loginIcon;
        private readonly BitmapImage _logoutIcon;

        // Getters

        public string Username
        {
            get { return _user != null ? _user.Name : ""; }
        }

        public string AdminStr
        {
            get { return _user != null && _user.Admin ? "Admin" : ""; }
        }

        public string CredStr
        {
            get { return _user != null ? "Logout" : "Login / Register"; }
        }

        public BitmapImage CredIcon
        {
            get { return _user != null ? _logoutIcon : _loginIcon; }
        }

        public bool IsAdmin
        {
            get { return _user != null && _user.Admin; }
        }

        public User User
        {
            get { return _user; }
        }

        // Setters

        public void Login(User user)
        {
            if (_user != null)
                throw new Exception("Tried to login when already connected");

            if (user == null)
                throw new Exception("Invalid user");

            _user = user;

            OnPropertyChange("CredIcon");
            OnPropertyChange("CredStr");
            OnPropertyChange("AdminStr");
            OnPropertyChange("IsAdmin");
            OnPropertyChange("Username");
        }

        public void Logout()
        {
            if (_user == null)
                throw new Exception("Tried to logout when already disconnected");

            _user = null;

            OnPropertyChange("CredIcon");
            OnPropertyChange("CredStr");
            OnPropertyChange("AdminStr");
            OnPropertyChange("IsAdmin");
            OnPropertyChange("Username");
        }

        // Constructors and functions

        public MainViewModel()
        {
            _user = null;
            _loginIcon = new BitmapImage(new Uri("pack://application:,,,/Resource/Img/login.png", UriKind.RelativeOrAbsolute));
            _logoutIcon = new BitmapImage(new Uri("pack://application:,,,/Resource/Img/logout.png", UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Debug function to test that the viewmodel is working
        /// </summary>
        public void swapState()
        {
            if (_user != null)
                Logout();
            else
                Login(new User(1, "testname_admin", true));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
