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
                    OnPropertyChange("LoginReady");
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
                    OnPropertyChange("LoginReady");
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
                    OnPropertyChange("RegisterReady");
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
                    OnPropertyChange("RegisterReady");
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

        public bool LoginReady
        {
            get { return _loginUsername.Trim() != "" && _loginPassword.Trim() != ""; }
        }

        public bool RegisterReady
        {
            get { return _registerUsername.Trim() != "" && _registerPassword.Trim() != ""; }
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
            return new User(-1, _registerUsername.Trim(), _registerPassword.Trim(), _registerIsAdmin);
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
