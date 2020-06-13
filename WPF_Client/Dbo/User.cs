using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client.Dbo
{
    class User
    {
        private string _name;
        private bool _admin;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        public User(string name = "", bool admin = false)
        {
            _name = name;
            _admin = admin;
        }
    }
}
