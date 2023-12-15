using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    public class ContactView
    {
        public int GetMenuChoice()
        {
            Console.Write("> ");
            return int.Parse(Console.ReadLine());
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. View all contacts");
            Console.WriteLine("2. Search contacts");
            Console.WriteLine("3. Add new contact");
            Console.WriteLine("4. Exit");
        }

        public void ShowContacts(List<Contact> contacts)
        {
            Console.WriteLine("All contacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void ShowSearchResults(List<Contact> searchResults)
        {
            Console.WriteLine($"Search results ({searchResults.Count}):");
            foreach (var result in searchResults)
            {
                Console.WriteLine(result.ToString());
            }
        }

        public string GetSearchField()
        {
            Console.WriteLine("Search by");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Surname");
            Console.WriteLine("3. Name and Surname");
            Console.WriteLine("4. Phone");
            Console.WriteLine("5. E-mail");

            Console.Write("> ");
            return Console.ReadLine();
        }

        public string GetSearchTerm()
        {
            Console.Write("Request: ");
            return Console.ReadLine();
        }

        public Contact GetNewContactInfo()
        {
            Console.WriteLine("New contact");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            string phone;
            do
            {
                Console.Write("Phone: ");
                phone = Console.ReadLine();

                if (!IsPhoneNumberValid(phone))
                {
                    Console.WriteLine("Invalid phone number. Please enter a valid phone number with only digits.");
                }
            } while (!IsPhoneNumberValid(phone));

            Console.Write("E-mail: ");
            string email = Console.ReadLine();

            return new Contact { Name = name, Surname = surname, Phone = phone, Email = email };
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit);
        }
    }
}
