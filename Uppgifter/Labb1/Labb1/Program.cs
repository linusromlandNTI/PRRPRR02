using System;
using System.Collections.Generic;

namespace Labb1
{
    class Program
    {
        public static List<Customer> _customers = new List<Customer>();
        public static List<string> _categories = new List<string>();
        public static List<Goods> _goods = new List<Goods>();
        public static int _selectedPerson = 0;
        static void Main(string[] args)
        {
            generateGame();
            Console.WriteLine("Welcome the CLI Shopping Experience!\nLet's get you sorted out and create a new Customer!\n");
            createCustomer();
            mainMenu();
        }

        public static void mainMenu()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("What do you want to do?\n(1) - Select Customer\n(2) - Create Customer\n(3) - Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        selectCustomer();
                        selectedPersonMenu();
                        break;
                    case "2":
                        createCustomer();
                        break;
                    case "3":
                        run = false;
                        break;
                }
            }
        }

        public static void selectedPersonMenu()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("What do you want to do?\n(1) - List Products\n(2) - Shopping Cart\n(3) - Go back");
                switch (Console.ReadLine())
                {
                    case "1":
                        listProducts();
                        break;
                    case "2":
                        createCustomer();
                        break;
                    case "3":
                        run = false;
                        break;
                }
            }
        }

        public static void listProducts()
        {
            while (true)
            {
                Console.WriteLine("What Category? Just type the number corresponding to the category!");
                for (int i = 0; i < _categories.Count; i++)
                {
                    int tmp = i + 1;
                    Console.WriteLine("(" + tmp + ") - " + _categories[i]);
                }
                int selectCategory = int.Parse(Console.ReadLine()) - 1;
                if (_categories.Count < selectCategory)
                {
                    Console.WriteLine("Thats not a valid category! Try Again!");
                }
                else
                {
                    Console.WriteLine(_categories[selectCategory] + "is selected!");
                    while (true)
                    {
                        Console.WriteLine("What Product? Just type the number corresponding to the product!");
                        for (int i = 0; i < numberOfProuductsInCategory(selectCategory); i++)
                        {
                            Console.WriteLine("(" + i + ") - " + _categories[i - 1]);
                        }
                        Console.WriteLine("(0) - Go back");
                        int selectedProduct = int.Parse(Console.ReadLine()) - 1;
                        if (selectedProduct == 0)
                        {
                            break;
                        }
                        else if (numberOfProuductsInCategory(selectCategory) < selectedProduct)
                        {
                            Console.WriteLine("Thats not a valid product! Try Again!");
                        }
                        else
                        {
                            selectProduct(selectCategory, selectedProduct);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        public static void selectProduct(int category, int product)
        {
            for (int i = 0; i < _goods.Count; i++)
            {
                int productname = 0;
                if(_goods[i]._category == category)
                {
                    productname++;
                    if(productname == product)
                    {
                        Console.WriteLine("\n\n\n" + _goods[i]._name + "\nPrice: " + _goods[i]._price + "\nWeight (g): " + _goods[i]._weight + "\nDescriptions: " + _goods[i]._desc + "\n\n Just type the number of the quantity you want. 0 for none!");
                        int quantity;
                        while (true)
                        {
                            try
                        {
                                quantity = int.Parse(Console.ReadLine());
                                break;
                            }
                        catch
                            {
                                Console.WriteLine("Not a valid amount! Try Again!");
                                continue;
                            }
                        }
                        if(quantity != 0)
                        {
                            _customers[_selectedPerson]._shoppingCart.Add(new ShoppingCart(_goods[i], quantity));

                        }

                    }
                }
            }
        }

        public static int numberOfProuductsInCategory(int selectedCategory)
        {
            int numberOfProuducts = 0;
            for (int i = 0; i < _goods.Count; i++)
            {
                if(_goods[i]._category == selectedCategory)
                {
                    numberOfProuducts++;
                }
            }
            return numberOfProuducts;
        }

        public static void selectCustomer()
        {
            while (true)
            {
                Console.WriteLine("Type the number of the Customer you want to select.");
                for (int i = 0; i < _customers.Count; i++)
                {
                    int tmp = i + 1;

                    Console.WriteLine("(" + tmp + ") - " + _customers[i]._userName);
                }
                int selectPerson = int.Parse(Console.ReadLine()) - 1;
                if(_customers.Count < selectPerson)
                {
                    Console.WriteLine("Thats not a valid customers! Try Again!");
                }
                else
                {
                    _selectedPerson = selectPerson;
                    Console.WriteLine(_customers[_selectedPerson]._userName + " is selected!");
                    break;
                }
            }

        }

        public static void generateGame()
        {

            //categories
            _categories.Add("Food");
            _categories.Add("Clothes");
            _categories.Add("Electronics");
            _categories.Add("Furniture");

            //Food Goods
            _goods.Add(new Goods(
                200,
                "Marabou Milk Choclate",
                22,
                1,
                "Marabou is a famous Swedish Brand that makes the greates chocolate. Milk Chocolate is the most popular one."
                ));

            _goods.Add(new Goods(
                50,
                "Peanuts",
                17,
                1,
                "Eldorado Peanuts, a cheap alternative."
                ));
            _goods.Add(new Goods(
                2000,
                "Milk",
                14,
                1,
                "Arla Milk, from a farm near you"
                ));
            _goods.Add(new Goods(
                500,
                "Monster Energy",
                18,
                1,
                "The greates energy drink of all time."
                ));

            //Clothes goods
            _goods.Add(new Goods(
               250,
               "T-Shirt",
               299,
               2,
               "A plain white T-Shirt."
               ));
            _goods.Add(new Goods(
               380,
               "T-Shirt",
               699,
               2,
               "A pair of Blue Jeans."
               ));
            _goods.Add(new Goods(
               250,
               "Hoodie",
               549,
               2,
               "A black hoodie."
               ));
            _goods.Add(new Goods(
               250,
               "Shoes",
               1049,
               2,
               "White Sneakers in Size EU 43."
               ));

            //Electronic Goods
            _goods.Add(new Goods(
               2213,
               "Macbook Pro Early 2020",
               41534,
               3,
               "Intel Core i9, 32GB Ram, 8TB SSD"
               ));
            _goods.Add(new Goods(
               1123,
               "RTX 3090",
               12000,
               3,
               "Asus ROG RTX 3090"
               ));
            _goods.Add(new Goods(
               1123,
               "Samsung Galaxy Fold Z-Flip2",
               11999,
               3,
               "Samsung Galaxy Fold Z-Flip2 512GB"
               ));
            _goods.Add(new Goods(
               1000,
               "iPhone 11 Pro Max",
               18999,
               3,
               "1024GB Green"
               ));

            //Furniture Goods
            _goods.Add(new Goods(
               5000,
               "Dining Table",
               4399,
               4,
               "White IKEA Dining Table"
               ));
            _goods.Add(new Goods(
               2000,
               "Markus Desk Chair",
               1199,
               4,
               "Desk Chair - IKEA Markus"
               ));
            _goods.Add(new Goods(
               3000,
               "Sofa",
               16799,
               4,
               "IKEA Corner Sofa"
               ));
            _goods.Add(new Goods(
               5000,
               "Bed",
               9999,
               4,
               "King-Size Bed 180cm"
               ));
        }

        public static void createCustomer()
        {
            string username;
            while (true)
            {
                Console.WriteLine("Choose a username!");
                username = Console.ReadLine();
                if (!usernameUsed(username))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Username taken, try another one!");
                }
            }
            long persNr;
            while (true)
            {
                Console.WriteLine("What is your Social Security Number (ÅÅÅÅMMDDXXXX)?");
                persNr = long.Parse(Console.ReadLine());
                if(persNr > 99999999999)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid Social Security Number. Try again!");
                }
            }
            Adress adress = new Adress();
            _customers.Add(new Customer(username, persNr, adress));
            Console.WriteLine("\nNew Customer Created!\n\nName: " + username + "\nSocial Security Number: " + persNr + "\n\nAdress: \n" + adress._street + " " + adress._streetNumber + "\n" + adress._zipCode + " " + adress._postAdress + "\n");

        }

        public static bool usernameUsed(string name)
        {
            bool toReturn = false;

            foreach (var customer in _customers)
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
