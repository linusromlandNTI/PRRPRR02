using System;

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
            while (true)
            {
                Console.WriteLine("What person do you want the information from? 0-4");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("\nName: " + persons[num].name + "\nAge: " +  persons[num].age + "\nAlive: " + persons[num].alive);

                Console.WriteLine("Get info from other person? y/n");
                string yn = Console.ReadLine().ToUpper();
                if (yn.Equals("N"))
                {
                    System.Environment.Exit(1);
                }
            }

        }
    }
}
