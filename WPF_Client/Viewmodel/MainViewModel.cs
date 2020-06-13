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
    class MainViewModel : INotifyPropertyChanged
    {
        private string _username;

        private readonly BitmapImage _loginIcon;
        private readonly BitmapImage _logoutIcon;

        private bool _isLogged;
        private bool _isAdmin;

        // Getters

        public string Username
        {
            get { return _username; }
        }

        public string AdminStr
        {
            get
            {
                if (_isAdmin)
                    return "Admin";
                return "";
            }
        }

        public string CredStr
        {
            get
            {
                if (_isLogged)
                    return "Logout";
                return "Login / Register";
            }
        }

        public BitmapImage CredIcon
        {
            get
            {
                if (_isLogged)
                    return _logoutIcon;
                return _loginIcon;
            }
        }

        public bool IsAdmin
        {
            get { return _isAdmin; }
        }

        // Setters

        public void Login(User user)
        {
            // FIXME : replace parameters with a 'User' model
            if (_isLogged)
                throw new Exception("Tried to login when already connected");

            _isLogged = true;
            _isAdmin = user.Admin;
            _username = user.Name;

            OnPropertyChange("CredIcon");
            OnPropertyChange("CredStr");
            OnPropertyChange("AdminStr");
            OnPropertyChange("Username");
        }

        public void Logout()
        {
            if (!_isLogged)
                throw new Exception("Tried to logout when already disconnected");

            _isLogged = false;
            _isAdmin = false;
            _username = "";

            OnPropertyChange("CredIcon");
            OnPropertyChange("CredStr");
            OnPropertyChange("AdminStr");
            OnPropertyChange("Username");
        }

        // Constructors and functions

        public MainViewModel()
        {
            _username = "";
            _loginIcon = new BitmapImage(new Uri("pack://application:,,,/Resource/Img/login.png", UriKind.RelativeOrAbsolute));
            _logoutIcon = new BitmapImage(new Uri("pack://application:,,,/Resource/Img/logout.png", UriKind.RelativeOrAbsolute));
            _isLogged = false;
            _isAdmin = false;
        }

        /// <summary>
        /// Debug function to test that the viewmodel is working
        /// </summary>
        public void swapState()
        {
            if (_isLogged)
                Logout();
            else
                Login(new User("testname_admin", true));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
