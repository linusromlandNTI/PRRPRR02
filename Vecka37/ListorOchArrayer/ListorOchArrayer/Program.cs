using System;
using System.Linq;

namespace ListorOchArrayer
{
    class Program
    {
        static void Main(string[] args)
        {
            People[] persons = new People[5];
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("What is your name");
                string name = Console.ReadLine();
                Console.WriteLine("Age?");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Are you alive");
                string alive = Console.ReadLine();
                persons[i] = new People(name, age, alive);
                Console.WriteLine("\n\n\nNext Person now..\n");
            }
      
            persons.Reverse();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("\nName: " + persons[i].name + "\nAge: " + persons[i].age + "\nAlive: " + persons[i].alive);
            }
            }

    }
    }

