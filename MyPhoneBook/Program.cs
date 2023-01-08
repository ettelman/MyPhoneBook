// MyPhoneBook by: Björn Ettelman
// Project
// Main program file

using System;

namespace MyPhoneBook
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("-       MyPhoneBook       -");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1 Add Contact");
            Console.WriteLine("2 Delete Contact");
            Console.WriteLine("3 Edit Contact");
            Console.WriteLine("4 Search Contact by name");
            Console.WriteLine("5 Search Contact by number");
            Console.WriteLine("6 Display all contacts");
            Console.WriteLine("7 Format phonebook");
            Console.WriteLine("8 Exit program");
            Console.WriteLine("---------------------------");

            var input = Console.ReadLine();
            // new phonebook class. This class controls most functions
            MyPhoneBook phonebook = new MyPhoneBook();
            // main program loop
            while (true)
            {
                Console.Clear();
                switch (input)
                {
                    case "1":

                        Console.WriteLine("Enter contact name");
                        var name = Console.ReadLine();
                        while (String.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("You have to enter a name \nTry again:");
                            name = Console.ReadLine();
                        }
                        int number;
                        var inputNum = string.Empty;
                        // checking for a number input
                        do
                        {
                            Console.WriteLine("Enter contact number");
                            inputNum = Console.ReadLine();
                        } while (!int.TryParse(inputNum, out number));
                      // new contact created and then added to phonebook
                        var newContact = new Contact(name, number);
                        Console.Clear();
                        phonebook.AddContact(newContact);
                        break;
                    case "2":
                        phonebook.DisplayAll();
                        Console.WriteLine("\nEnter index for post to be deleted.");
                        Console.WriteLine("X to go back");
                        var index = Console.ReadLine();
                        if (!String.IsNullOrEmpty(index))
                            try
                            {
                                Console.Clear();
                                phonebook.DelPosts(Convert.ToInt32(index));
                            }
                            // Going back to menu if failed
                            catch (Exception e)
                            {
                                Console.WriteLine("Index out of range");

                            }
                        break;
                    case "3":
                        phonebook.DisplayAll();
                        Console.WriteLine("\nEnter index for contact to be edited");
                        Console.WriteLine("X to go back");
                        var editIndex = Console.ReadLine();
                        if (!String.IsNullOrEmpty(editIndex))
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("The following contact is beeing edited:");
                                phonebook.DisplayOne(Convert.ToInt32(editIndex));

                                Console.WriteLine("Enter contact name");
                                var editName = Console.ReadLine();
                                while (String.IsNullOrEmpty(editName))
                                {
                                    Console.WriteLine("You have to enter a name \nTry again:");
                                    editName = Console.ReadLine();
                                }
                                int editNumber;
                                var inputNumber = string.Empty;
                                do
                                {
                                    Console.WriteLine("Edit contact number");
                                    inputNumber = Console.ReadLine();
                                } while (!int.TryParse(inputNumber, out editNumber));
                                // 
                                var editContact = new Contact(editName, editNumber);
                                Console.Clear();
                                phonebook.EditContact(editContact, Convert.ToInt32(editIndex));


                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Index out of range");

                            }
                        break;
                    case "4":
                        Console.WriteLine("\nSearch by name:");
                        var searchName = Console.ReadLine();
                        while (String.IsNullOrEmpty(searchName))
                        {
                            Console.WriteLine("You have to enter atleast one letter \nTry again:");
                            searchName = Console.ReadLine();
                        }
                        Console.Clear();
                        Console.WriteLine("Search results:");
                        Console.WriteLine("---------------------------");
                        phonebook.SearchName(searchName);
                        Console.WriteLine("---------------------------");

                        break;

                    case "5":
                        
                        int searchNumber;
                        var inNumber = string.Empty;
                        do
                        {
                            Console.WriteLine("\nSearch by number:");
                            inNumber = Console.ReadLine();
                        } while (!int.TryParse(inNumber, out searchNumber));
                        phonebook.SearchNumber(searchNumber);

                        break;
                    case "6":
                        Console.WriteLine("-   Display all contacts  -");
                        Console.WriteLine("---------------------------\n");
                        phonebook.DisplayAll();
                        Console.WriteLine("\n---------------------------");
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("-   Format phonebook  -");
                        Console.WriteLine("Warning: This will delete all contacts");
                        Console.WriteLine("y/n");
                        var format = Console.ReadLine();
                        if (format == "y" || format == "Y") { 
                        phonebook.Format();
                        }
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Select correct operation (1-8)");
                        break;
                }
                Console.WriteLine("-       MyPhoneBook       -");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1 Add Contact");
                Console.WriteLine("2 Delete Contact");
                Console.WriteLine("3 Edit Contact");
                Console.WriteLine("4 Search Contact by name");
                Console.WriteLine("5 Search Contact by number");
                Console.WriteLine("6 Display all contacts");
                Console.WriteLine("7 Format phonebook");
                Console.WriteLine("8 Exit program");
                Console.WriteLine("---------------------------");


                input = Console.ReadLine();

            }
        }



    }





}
