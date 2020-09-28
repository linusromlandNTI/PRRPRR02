using System;
using System.Collections.Generic;

namespace Labb1
{
    class Program
    {
        public static List<Customer> _customers = new List<Customer>();
        public static Categories _goods = new Categories();
        public static List<Goods> _selectedCategories = new List<Goods>();
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
                Console.WriteLine("What do you want to do?\n(1) - List Products\n(2) - Shopping Cart\n(0) - Go back");
                switch (Console.ReadLine())
                {
                    case "1":
                        listProducts();
                        break;
                    case "2":
                        listShoppingCart();
                        break;
                    case "0":
                        run = false;
                        break;
                }
            }
        }

        public static void listProducts()
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("Choose the Category you want! \nJust type the number of the corresponding category!\n(1) - Foods\n(2) - Clothes\n(3) - Electronics\n(4) - Furniture\n(0) - Go back");
                int selected = int.Parse(Console.ReadLine());
                if(selected >= 0 && selected <= 5)
                {
                    switch (selected)
                    {
                        case 0:
                            run = false;
                            break;
                        case 1:
                            Console.WriteLine("Food is selected!");
                            _selectedCategories = _goods._foods;
                            break;
                        case 2:
                            Console.WriteLine("Clothes is selected!");
                            _selectedCategories = _goods._clothes;
                            break;
                        case 3:
                            Console.WriteLine("Electronics is selected!");
                            _selectedCategories = _goods._electronics;
                            break;
                        case 4:
                            Console.WriteLine("Furniture is selected!");
                            _selectedCategories = _goods._furniture;
                            break;
                    }
                }
                Console.WriteLine("\nChoose the product you want! \nJust type the number of the corresponding prduct!");
                for(int i = 0; i < _selectedCategories.Count; i++)
                {
                    Console.WriteLine("(" + i + ") - " + _selectedCategories[i]._name);
                }
                int selectedProduct = int.Parse(Console.ReadLine());
                run = selectProduct(selectedProduct);
            }


        }

        public static void listShoppingCart()
        {
            Console.WriteLine("Your Shopping Cart:\n");
            int price = 0;
            int weight = 0;
            for (int i = 0; i < _customers[_selectedPerson]._shoppingCart.Count; i++)
            {
                Console.WriteLine(_customers[_selectedPerson]._shoppingCart[i]._quantity + "x " + _customers[_selectedPerson]._shoppingCart[i]._goods._name);
                price = price + (_customers[_selectedPerson]._shoppingCart[i]._goods._price * _customers[_selectedPerson]._shoppingCart[i]._quantity);
                weight = weight + (_customers[_selectedPerson]._shoppingCart[i]._goods._weight * _customers[_selectedPerson]._shoppingCart[i]._quantity);
            }
            Console.WriteLine("Your total price is: " + price + "SEK\n" + "Your total weight is " + weight + "gram\n\n");

        }

        public static bool selectProduct(int product)
        {
            Console.WriteLine(_selectedCategories[product]._name + "is selected\n\n");
            Console.WriteLine(_selectedCategories[product]._name + "\nWeight: " + _selectedCategories[product]._weight + "\nDescriptions: " + _selectedCategories[product]._desc + "\nPrice: " + _selectedCategories[product]._price + "SEK");
            Console.WriteLine("Just type the quantity you want, type 0 for none!");
            int quantity = int.Parse(Console.ReadLine());
            if(quantity != 0)
            {
                _customers[_selectedPerson]._shoppingCart.Add(new ShoppingCart(_selectedCategories[product], quantity));
                Console.WriteLine("Added " + _selectedCategories[product]._name + " to the Shopping Cart!\n");
            }

            return false;
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
            //Food Goods
            _goods._foods.Add(new Goods(
                200,
                "Marabou Milk Choclate",
                22,
                "Marabou is a famous Swedish Brand that makes the greates chocolate. Milk Chocolate is the most popular one."
                ));

            _goods._foods.Add(new Goods(
                50,
                "Peanuts",
                17,
                "Eldorado Peanuts, a cheap alternative."
                ));
            _goods._foods.Add(new Goods(
                2000,
                "Milk",
                14,
                "Arla Milk, from a farm near you"
                ));
            _goods._foods.Add(new Goods(
                500,
                "Monster Energy",
                18,
                "The greates energy drink of all time."
                ));

            //Clothes goods
            _goods._clothes.Add(new Goods(
               250,
               "T-Shirt",
               299,
               "A plain white T-Shirt."
               ));
            _goods._clothes.Add(new Goods(
               380,
               "Jeans",
               699,
               "A pair of Blue Jeans."
               ));
            _goods._clothes.Add(new Goods(
               250,
               "Hoodie",
               549,
               "A black hoodie."
               ));
            _goods._clothes.Add(new Goods(
               250,
               "Shoes",
               1049,
               "White Sneakers in Size EU 43."
               ));

            //Electronic Goods
            _goods._electronics.Add(new Goods(
               2213,
               "Macbook Pro Early 2020",
               41534,
               "Intel Core i9, 32GB Ram, 8TB SSD"
               ));
            _goods._electronics.Add(new Goods(
               1123,
               "RTX 3090",
               12000,
               "Asus ROG RTX 3090"
               ));
            _goods._electronics.Add(new Goods(
               1123,
               "Samsung Galaxy Fold Z-Flip2",
               11999,
               "Samsung Galaxy Fold Z-Flip2 512GB"
               ));
            _goods._electronics.Add(new Goods(
               1000,
               "iPhone 11 Pro Max",
               18999,
               "1024GB Green"
               ));

            //Furniture Goods
            _goods._furniture.Add(new Goods(
               5000,
               "Dining Table",
               4399,
               "White IKEA Dining Table"
               ));
            _goods._furniture.Add(new Goods(
               2000,
               "Markus Desk Chair",
               1199,
               "Desk Chair - IKEA Markus"
               ));
            _goods._furniture.Add(new Goods(
               3000,
               "Sofa",
               16799,
               "IKEA Corner Sofa"
               ));
            _goods._furniture.Add(new Goods(
               5000,
               "Bed",
               9999,
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
