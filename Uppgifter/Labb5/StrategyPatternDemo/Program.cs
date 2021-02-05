using StrategyPatternDemo.Strategy;
using System;

namespace StrategyPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to cool things");
                string name = "";
                INameGivingStrategy strat;

                Console.WriteLine("Enter the name:");
                name = Console.ReadLine();
                bool reset = false;
                name = name.ToLower();
                switch (name)
                {
                    case "linus":
                        strat = new LinusStrategy();
                        break;
                    case "anton":
                        strat = new AntonStrategy();
                        break;
                    case "markus":
                        strat = new MarkusStrategy();
                        break;
                    case "niklas":
                        strat = new NiklasStrategy();
                        break;
                    case "svante":
                        strat = new SvanteStrategy();
                        break;
                    default:
                        Console.WriteLine("not valid f u");
                        reset = true;
                        strat = new LinusStrategy();
                        break;
                }

                if (reset)
                {
                    continue;
                }

                var calc = new Calculation(strat);
                calc.CalculationInterface(name);

                Console.WriteLine("Do you wish to continue? 'y'/'n'");
                if(Console.ReadLine().ToLower() != "y")
                {
                    break;
                }
            }
        }
    }
}
