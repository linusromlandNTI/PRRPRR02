using System;
using System.Collections.Generic;

namespace Labb1
{
    class Program
    {
        public static List<Customer> customers = new List<Customer>();
        public static List<string> categories = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome the CLI Shopping Experience!\nLet's get you sorted out and create a new Customer!\n");
            createCustomer();
            
        }
        public static void createCustomer()
        {
            string username;
            while (true)
            {
                Console.WriteLine("Choose a username!");
                username = Console.ReadLine();
                if (!usernameUsed(username))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Username taken, try another one!");
                }
            }
            long persNr;
            while (true)
            {
                Console.WriteLine("What is your Social Security Number (ÅÅÅÅMMDDXXXX)?");
                persNr = long.Parse(Console.ReadLine());
                if(persNr > 99999999999)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid Social Security Number. Try again!");
                }
            }
            Adress adress = new Adress();
            customers.Add(new Customer(username, persNr, adress));
            Console.WriteLine("\nNew Customer Created!\n\nName: " + username + "\nSocial Security Number: " + persNr + "\n\nAdress: \n" + adress._street + " " + adress._streetNumber + "\n" + adress._zipCode + " " + adress._postAdress);

        }

        public static bool usernameUsed(string name)
        {
            bool toReturn = false;

            foreach (var customer in customers)
            {
                if (customer._userName == name)
                {
                    toReturn = true;
                }
            }
            return toReturn;
        }

        
    }
}
