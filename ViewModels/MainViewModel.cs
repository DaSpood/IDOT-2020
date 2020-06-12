using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_IDOT_Project.ViewModels
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

        public void Login(bool isAdmin, string username)
        {
            // FIXME : replace parameters with a 'User' model
            if (_isLogged)
                throw new Exception("Tried to login when already connected");

            _isLogged = true;
            _isAdmin = isAdmin;
            _username = username;

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
            _loginIcon = new BitmapImage(new Uri("Resources/login.png", UriKind.Relative));
            _logoutIcon = new BitmapImage(new Uri("Resources/logout.png", UriKind.Relative));
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
                Login(true, "Test");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
