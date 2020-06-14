using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Client.Dbo;
using WPF_Client.Viewmodel;

namespace WPF_Client.View
{
    /// <summary>
    /// Interaction logic for CredentialWindow.xaml
    /// </summary>
    public partial class CredentialWindow : Window
    {
        private CredentialViewModel _viewmodel;
        private User _user;

        public CredentialWindow()
        {
            InitializeComponent();

            // Setup viewmodel for bindings
            _viewmodel = new CredentialViewModel();
            DataContext = _viewmodel;

            // Load default settings
            _user = null;
        }

        public User User
        {
            get { return _user; }
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            User generated = _viewmodel.GenerateLoginUser();

            // Fetch the registered user to login immediately
            _user = BusinessManagement.User.GetUserByCredentials(generated.Name, generated.Password);

            // Warn the user if login failed
            if (_user == null)
            {
                MessageBox.Show("Error: Invalid credentials.",
                    "Something happened...", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Close the credential window if login was successful
            this.DialogResult = true;
            this.Close();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            User generated = _viewmodel.GenerateRegisterUser();

            // Verify that this user does not already exist
            if (BusinessManagement.User.GetUserByName(generated.Name) != null)
            {
                MessageBox.Show("Error: This username is already taken.",
                    "Something happened...", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Register the new user
            if (!BusinessManagement.User.AddUser(generated))
            {
                MessageBox.Show("Error: Could not register. Please try again.",
                    "Something happened...", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Fetch the registered user to login immediately and inform user
            MessageBox.Show("Registration success ! You are now logged in !",
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            _user = BusinessManagement.User.GetUserByCredentials(generated.Name, generated.Password);

            // Close the credential window if login was successful
            this.DialogResult = true;
            this.Close();
        }
    }
}
