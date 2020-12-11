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
                //USE PRODUCT/ANIMAL
                case 0:
                    System.Environment.Exit(1);
                    break;
            }
        }


        public static void ShowAnimals()
        {
            Console.WriteLine("To buy animal, select it!\nAnimals in Stock:");
            Console.WriteLine("(1) - Dog\n(2) - Goose\n(3) - Cat\n(0) - Go Back");
            Random rnd = new Random();
            string color = colors[rnd.Next(1, colors.Length)];
            string theName = names[rnd.Next(1, names.Length)];
            string name;
            switch (IntInput())
            {
                case 1:
                    name = "The dog " + theName;
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
            Console.WriteLine("(1) - Dog Bed\n(2) - Food Bowl\n(3) - Goose Hat\n(0) - Go Back");
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
                Console.WriteLine("This is your cart:");
                for (int i = 0; i < _products.Count; i++)
                {
                    Console.WriteLine(_products[i].Name + " " + _products[i].Price + "kr");
                }
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