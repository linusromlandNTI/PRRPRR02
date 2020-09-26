using System;


namespace Labb1
{
    class Program
    {
        public Customer[] customers;
        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome the CLI Shopping Experience!\n Let's get you sorted out and create a new Customer!");
            Adress tmp = new Adress();
            
        }
        public void createCustomer(string userName, string adress, int postAdress, string zipCode, int persNr)
        {
            while (true)
            {
                Console.WriteLine("Choose a username!");
                string username = Console.ReadLine();
                if (!usernameUsed(username))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Username taken, try another one!");
                }
            }
            
        }

        public bool usernameUsed(string name)
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
