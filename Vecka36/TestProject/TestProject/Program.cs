using System;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Want to run? (y/n)");
                if (Console.ReadLine().ToUpper().Equals("Y"))
                {
                    Console.WriteLine("How old are you?");
                    String input = Console.ReadLine();
                    switch (input)
                    {
                        case "18":
                            Console.WriteLine("Cool, your 18");
                            break;
                        case "15":
                            Console.WriteLine("Then you could get a moped or something");
                            break;
                        case "10":
                            Console.WriteLine("Doubledigits cool!!");
                            break;
                        default:
                            Console.WriteLine("Cool, your " + Console.ReadLine());
                            break;

                    }
                    Console.WriteLine("this is a cool for loop!");
                    for (int i = 0; i > 50; i++){
                        Console.WriteLine("This is the " + i + "time this loop is ran");
                    }
                }else if (Console.ReadLine().ToUpper().Equals("N"))
                {
                    Console.WriteLine("Goodbye");
                    break;
                }
                else
                {
                Console.WriteLine("no input or invalid answer. Try again!");
                }
            }
        }
    }
}
