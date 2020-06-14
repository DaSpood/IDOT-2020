using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Client.Dbo;

namespace WPF_Client.Viewmodel
{
    class CredentialViewModel : INotifyPropertyChanged
    {
        private string _loginUsername;
        private string _loginPassword;

        private string _registerUsername;
        private string _registerPassword;
        private bool _registerIsAdmin;

        // Getters/Setters

        public string LoginUsername
        {
            get { return _loginUsername; }
            set
            {
                if (_loginUsername != value)
                {
                    _loginUsername = value;
                    OnPropertyChange("LoginUsername");
                }
            }
        }

        public string LoginPassword
        {
            get { return _loginPassword; }
            set
            {
                if (_loginPassword != value)
                {
                    _loginPassword = value;
                    OnPropertyChange("LoginPassword");
                }
            }
        }

        public string RegisterUsername
        {
            get { return _registerUsername; }
            set
            {
                if (_registerUsername != value)
                {
                    _registerUsername = value;
                    OnPropertyChange("RegisterUsername");
                }
            }
        }

        public string RegisterPassword
        {
            get { return _registerPassword; }
            set
            {
                if (_registerPassword != value)
                {
                    _registerPassword = value;
                    OnPropertyChange("RegisterPassword");
                }
            }
        }

        public bool RegisterIsAdmin
        {
            get { return _registerIsAdmin; }
            set
            {
                if (_registerIsAdmin != value)
                {
                    _registerIsAdmin = value;
                    OnPropertyChange("RegisterIsAdmin");
                }
            }
        }

        // Constructors and functions

        public CredentialViewModel()
        {
            _loginUsername = "";
            _loginPassword = "";
            _registerUsername = "";
            _registerPassword = "";
            _registerIsAdmin = false;
        }

        public User GenerateRegisterUser()
        {
            return new User(-1, _registerUsername, _registerPassword, _registerIsAdmin);
        }

        public User GenerateLoginUser()
        {
            return new User(-1, _loginUsername, _loginPassword, false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
