using System;
using System.Collections.Generic;

namespace OOPTest
{
    class Program
    {
        static List<Person> persons = new List<Person>();
        static int selectedPerson;

        static void Main(string[] args)
        {
            Console.WriteLine("OOP Testing by linusromland!\n");
            while (true)
            {
                if (persons.Count == 0)
                {
                    Console.WriteLine("You dont have any character yet. Lets create one.");
                    CreatePerson();
                    continue;
                }
                Console.WriteLine("What do you want to do?\n\n(1) - Select Person\n(2) - Create Person\n(3) - Remove Person\n(0) - Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        SelectPerson();
                        break;
                    case "2":
                        CreatePerson();
                        break;
                    case "3":
                        break;
                    case "0":
                        System.Environment.Exit(0);
                        break;

                }
            }
        }
        static void CreatePerson()
        {
            Console.WriteLine("What will be the characters name?");
            string name = Console.ReadLine();
            Console.WriteLine("How old is the character?");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Is the person alive?");
            bool alive;
            if (Console.ReadLine().ToUpper().ToString() == "YES")
            {
                alive = true;
            }
            else if (Console.ReadLine().ToUpper().ToString() == "NO")
            {
                alive = false;
            }
            else
            {
                Console.WriteLine("Not valid input, defaulting to alive");
                alive = true;
            }
            Console.WriteLine("What blood type?");
            string bloodtype = Console.ReadLine();
            Console.WriteLine("What healthcondition?");
            string healtcondition = Console.ReadLine();
            persons.Add(new Person(name, age, alive, bloodtype, healtcondition));
            Console.WriteLine(name + " created!");
        }
        static void SelectPerson()
        {
            foreach (var person in persons)
            {
                Console.WriteLine("(" + i + ") - " + person.Name());
            }
            Console.WriteLine("Select the person you want by typing the corresponding number");
            selectedPerson = int.Parse(Console.ReadLine().ToString());
        }
    }
}