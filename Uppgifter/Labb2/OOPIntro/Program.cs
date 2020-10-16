using System;

namespace OOPIntro
{
    class Program
    {
        static void Main(string[] args)
        {

            var kund = new Customer();

            while (true)
            {
                Console.WriteLine("Do you want to make a purchase?");

                if (Console.ReadLine().ToLower() == "yes")
                {
                    bool purchase = true;
                    Console.WriteLine("What do you want to buy? Type 1 for Monster or 2 for Nocco, 0 for now more");

                    while (purchase) { 
                    switch (intInput())
                    {
                        case 1:
                            kund._cart.Add(new Monster("Pipeline"));
                            kund._cart[kund._cart.Count-1].ProductName = "Monster";
                            break; //add monster
                        case 2:
                            kund._cart.Add(new Nocco("Cola"));
                            kund._cart[kund._cart.Count-1].ProductName = "Nocco";
                            break; //add burger
                        case 0:
                            purchase = false;
                            break;//add kill
                        default:
                            Console.WriteLine("try again");
                            break;
                    }
                    }
                }
                else
                    break;

                Console.WriteLine("Do you want to view your cart?");
                if (Console.ReadLine().ToLower() == "yes")
                    foreach (var item in kund._cart)
                        Console.WriteLine(item.ProductName);
                else
                    Console.WriteLine("Suck a duck!");
            }
        }

        public static int intInput()
        {
            int toReturn;
            while (true)
            {
                try
                {
                    toReturn = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Not a valid input, try again!");
                }
            }
            return toReturn;
        }
    }
}
