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
            //FIXME: fetch _viewmodel.GenerateLoginUser() from database and set it as _user
            _user = generated; //FIXME
            this.DialogResult = true;
            this.Close();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            User generated = _viewmodel.GenerateRegisterUser();
            //FIXME: post _viewmodel.GenerateRegisterUser() to database then fetch it back and set it as _user
            _user = generated; //FIXME
            this.DialogResult = true;
            this.Close();
        }
    }
}
