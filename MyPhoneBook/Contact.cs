// MyPhoneBook by: Björn Ettelman
// Project
// This class is used for storing contacts
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhoneBook
{
    class Contact
    {
        public Contact(string name, int number)
        {
            Name = name;
            Number = number;

        }

        public string Name { get; set; }
        public int Number { get; set; }


    }
}
