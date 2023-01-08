// MyPhoneBook by: Björn Ettelman
// Project
// Class for PhoneBook
// Contains most functions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPhoneBook
{
    class MyPhoneBook
    {
        // json-filename used for saving contacts
        private string filename = @"contacts.json";
        // New list. Contacts beeing saved here
        private List<Contact> _contacts { get; set; } = new List<Contact>();

        // Constructor to check for file and add file contents to list
        public MyPhoneBook()
        {
            if (File.Exists(filename) == true)
            { // If stored json data exists then read
                string jsonString = File.ReadAllText(filename);
                _contacts = JsonSerializer.Deserialize<List<Contact>>(jsonString);
            }
        }
        // Add contact with the contact class
        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
            ToFile();
            Console.WriteLine("Contact added to phonebook\n");
        }

        // Function to display all contacts, adding index
        public void DisplayAll()
        {
            int numberContact = 0;
            foreach (var contact in _contacts)
            {
                Console.WriteLine($"[{numberContact}] {contact.Name} - {contact.Number}");
                numberContact++;
            }
            if (!_contacts.Any()) Console.WriteLine("The Phonebook is empty");
        }
        // function to just display one contact with given index
        public void DisplayOne(int index)
        { 
                Console.WriteLine($"[{index}] {_contacts[index].Name} - {_contacts[index].Number}"); 
        }
        // function to search by given number
        public void SearchNumber(int number) 
        { 
            // getting first contact with given number
        var contact = _contacts.FirstOrDefault(c => c.Number == number);
            if (contact == null) 
            {
                Console.WriteLine("-Can't find any contacts with this search-");
                    } else
            {
                Console.WriteLine($"Contact found by number: {contact.Name}, {contact.Number}");
            }
        }
        // function to search by name
        public void SearchName(string name)
        {
            // adding searches to list for names containing search-term
            var searchContact = _contacts.Where(c => c.Name.Contains(name)).ToList();
            foreach (var contact in searchContact)
            {
                Console.WriteLine($"{contact.Name} - {contact.Number}");
                
            }
            if (!searchContact.Any()) Console.WriteLine("Can't find any contacts with this search");
        }

        // Function to add the current list to file
        private void ToFile()
        {
            // Using JsonSerialize on the list and save it to file
            var jsonString = JsonSerializer.Serialize(_contacts);
            File.WriteAllText(filename, jsonString);
        }

        // Function to remove a post at chosen index
        public int DelPosts(int index)
        {

            _contacts.RemoveAt(index);
            ToFile();
            Console.WriteLine("Contact deleted\n");
            return index;
        }
        // function to edit chosen contact using given index
        public int EditContact(Contact contact, int index)
        {
            _contacts[index] = contact;
            ToFile();
            return index;
        }
        public void Format()
        {
            _contacts.Clear();
            ToFile();
            Console.WriteLine("Phonebook format complete");
        }

    }
}
