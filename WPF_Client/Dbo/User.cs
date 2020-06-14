using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client.Dbo
{
    public class User
    {
        private long _id;
        private string _name;
        private string _password;
        private bool _admin;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        public User(long id, string name, string password, bool admin)
        {
            _id = id;
            _name = name;
            _password = password;
            _admin = admin;
        }
    }
}
