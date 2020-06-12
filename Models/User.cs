using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_IDOT_Project.Models
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
    }
}
