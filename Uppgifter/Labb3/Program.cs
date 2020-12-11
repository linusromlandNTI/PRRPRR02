using System;
using System.Collections.Generic;

namespace Labb3
{
    internal class Program
    {
        private static List<Product> _products = new List<Product>();
        private static String[] colors = {"Black", "White", "Brown", "Ginger", "Black & White", "Aqua"};
        private static String[] names = {"Bella", "Luna", "Charlie", "Lucy", "Cooper", "Max", "Bailey", "Daisy", "Sadie", "Lola", "Buddy", "Molly", "Stella", "Tucker", "Bear", "Zoey", "Duke", "Harley", "Maggie", "Jax", "Bentley"};

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Animal Store!");
            while (true)
            { mainMenu(); }
        }

        public static void mainMenu()
        {
            Console.WriteLine("Main menu! Choose what you want do!");
            Console.WriteLine("(1) - Show Animals\n(2) - Show Accessories\n(3) - Show Cart\n(4) - Use Product/Animal\n(0) - Exit Program");
            switch (IntInput())
            {
                case 1:
                    ShowAnimals();
                    break;
                case 2:
                    ShowAccessories();
                break;
                case 3:
                    ShowCart();
                    break;
                case 4: 
                    UseProductAnimal();
                    break;
                case 0:
                    System.Environment.Exit(1);
                    break;
            }
        }


        public static void UseProductAnimal()
        {
            if (_products.Count <= 0)
            {
                Console.WriteLine("You cart is empty, add some before using them!");
            }
            else
            {
                string print = "Choose what you want to do by choosing!\n";
                for (int i = 0; i < _products.Count; i++)
                {
                    int temp = i + 1;
                    print += "(" + temp + ") - " + _products[i].Name + "\n";
                }

                Console.WriteLine(print + "(0) - Go Back");
                int tmp = IntInput()-1;
                if (_products[tmp] is Animal animal)
                {
                    Console.WriteLine("What do you want to do?\n(1) - Breathe\n(2) - Eat\n(3) - Restn\n(0) - Go Back");
                    switch (IntInput())
                    {
                        case 1:
                            animal.Breathe();
                            break;
                        case 2:
                            animal.Eat();
                            break;
                        case 3:
                            animal.Rest();
                            break;
                        case 0:
                            break;
                    }
                }else if (_products[tmp] is Accesories accesorie)
                {
                    Console.WriteLine("What do you want to do?\n(1) - Use\n(2) - Destroy\n(3) - Throw\n(0) - Go Back");
                    switch (IntInput())
                    {
                        case 1:
                            accesorie.Use();
                            break;
                        case 2:
                            accesorie.Destroy();
                            _products.RemoveAt(tmp);
                            break;
                        case 3:
                            accesorie.Throw();
                            break;
                        case 0:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Something went wrong!");
                }
            }
            
        }
        
        public static void ShowAnimals()
        {
            Console.WriteLine("To buy animal, select it!\nAnimals in Stock:");
            Console.WriteLine("(1) - Dog [25000kr]\n(2) - Goose [150kr]\n(3) - Cat [500kr]\n(0) - Go Back");
            Random rnd = new Random();
            string color = colors[rnd.Next(1, colors.Length)];
            string theName = names[rnd.Next(1, names.Length)];
            string name;
            switch (IntInput())
            {
                case 1:
                    name = "The Dog " + theName;
                    _products.Add(new Dog{Name = name, Color = color});
                    Console.WriteLine("Added a " + color + " Dog named " + theName + " to you cart");
                    break;
                case 2:
                    name = "The Goose " + theName;
                    _products.Add(new Goose{Name = name, Color = color});
                    Console.WriteLine("Added a " + color + " Goose named " + theName + " to you cart");
                    break;
                case 3:
                    name = "The Cat " + theName;
                    _products.Add(new Cat{Name = name, Color = color});
                    Console.WriteLine("Added a " + color + " Cat named " + theName + " to you cart");
                    break;
                case 0:
                    break;
            }
        }
        
        public static void ShowAccessories()
        {
            Console.WriteLine("To buy accessories, select it!");
            Console.WriteLine("(1) - Dog Bed [125kr]\n(2) - Food Bowl [75kr]\n(3) - Goose Hat [833kr]\n(0) - Go Back");
            switch (IntInput())
            {
                case 1:
                    _products.Add(new DogBed{Name = "Dog Bed"});
                    Console.WriteLine("Added a Dog Bed to you cart");
                    break;
                case 2:
                    _products.Add(new FoodBowl{Name = "Food Bowl"});
                    Console.WriteLine("Added a Food Bowl to you cart");
                    break;
                case 3:
                    _products.Add(new GooseHat{Name = "Goose Hat"});
                    Console.WriteLine("Added a Goose Hat to you cart");
                    break;
                case 0:
                    break;
            }
        }
        
        public static void ShowCart()
        {
            if (_products.Count <= 0)
            {
                Console.WriteLine("You cart is empty!");
            }
            else
            {
                int totalPrice = 0;
                Console.WriteLine("This is your cart:");
                for (int i = 0; i < _products.Count; i++)
                {
                    totalPrice = totalPrice + _products[i].Price;
                    Console.WriteLine(_products[i].Name + " " + _products[i].Price + "kr");
                }

                Console.WriteLine("Your total is: " + totalPrice + "kr\nSorry we dont accept payments!");
            }
            Console.WriteLine("Choose what you want do!");
            Console.WriteLine("(1) - Go back\n(0) - Exit Program");

            switch (IntInput())
            {
                case 1:
                    break;
                case 0:
                    System.Environment.Exit(1);
                    break;
            }
        }
        
        public static int IntInput()
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