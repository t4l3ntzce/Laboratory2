using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    public class ContactController
    {
        private List<Contact> contacts;
        private ContactView view;

        public ContactController(List<Contact> contacts, ContactView view)
        {
            this.contacts = contacts;
            this.view = view;
        }

        public void Run()
        {
            Console.WriteLine("Enter the number of action and press [Enter]. Then follow instructions.");

            while (true)
            {
                view.DisplayMenu();
                int choice = view.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        view.ShowContacts(contacts);
                        break;
                    case 2:
                        SearchContacts();
                        break;
                    case 3:
                        AddNewContact();
                        break;
                    case 4:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid menu number.");
                        break;
                }
            }
        }

        private void SearchContacts()
        {
            string searchField = view.GetSearchField();
            string searchTerm = view.GetSearchTerm();

            Console.WriteLine("Searching...");

            List<Contact> searchResults = new List<Contact>();

            switch (searchField)
            {
                case "1":
                    searchResults = contacts.Where(c => c.Name.Contains(searchTerm)).ToList();
                    break;
                case "2":
                    searchResults = contacts.Where(c => c.Surname.Contains(searchTerm)).ToList();
                    break;
                case "3":
                    searchResults = contacts.Where(c => (c.Name + " " + c.Surname).Contains(searchTerm)).ToList();
                    break;
                case "4":
                    searchResults = contacts.Where(c => c.Phone.Contains(searchTerm)).ToList();
                    break;
                case "5":
                    searchResults = contacts.Where(c => c.Email.Contains(searchTerm)).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid search choice.");
                    return;
            }

            view.ShowSearchResults(searchResults);
        }

        private void AddNewContact()
        {
            Contact newContact = view.GetNewContactInfo();
            contacts.Add(newContact);
            Console.WriteLine("Contact added.");
        }
    }
}
