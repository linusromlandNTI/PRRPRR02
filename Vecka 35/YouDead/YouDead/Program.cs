using System;

namespace YouDead
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = usrInput("What's your name?");
            int yearOfBirth = 0;
            bool alive;
            int yearOfDeath = 0;
            int ageWhenDeath = 0;
            int currentYear = DateTime.Now.Year;
            int age = 0;
            while (true)
            {
                try
                {
                    yearOfBirth = int.Parse(usrInput("When were you born? (19xx or 20xx)"));
                    break;
                }
                catch
                {
                    Console.WriteLine("Thats not a valid year! Try again!");
                }
            }
            
            while (true)
            {
                try
                {
                    alive = Convert.ToBoolean(usrInput("Are you alive? (true/false)"));
                    break;
                }
                catch
                {
                    Console.WriteLine("Thats not a valid answer! Try again!");
                }
            }
            if (!alive)
            {
                while (true)
                {
                    try
                    {
                        yearOfDeath = int.Parse(usrInput("What year did you die? (19xx or 20xx)"));
                        if (yearOfBirth > yearOfDeath)
                        {
                            Console.WriteLine("You died before you were born? Not very likely.. Try again");

                        }
                        else
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Thats not a valid year! Try again!");
                    }
                }
                ageWhenDeath = yearOfDeath - yearOfBirth;
            }
            else
            {
                age = currentYear - yearOfBirth;
            }
            String printThis = "\nYour name: " + name;
            Console.WriteLine(printThis);
            if (alive)
            {
                Console.WriteLine(printThis + "\nYou are alive!\nYou are {0} years old!", age);
            }
            else
            {
                Console.WriteLine(printThis + "\nYou are Dead!\nYou lived for {0} years!", ageWhenDeath);

            }
            Console.WriteLine("Press any key to close the application!");
            Console.ReadKey();
        }

        static String usrInput(String print)
        {
            Console.WriteLine(print);
            String input = Console.ReadLine();
            return input;
        }
    }
}
