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
        private static bool run = true;

        static void Main(string[] args)
        {
            generateGame();
            Console.WriteLine("Welcome the CLI Shopping Experience!\nLet's get you sorted out and create a new Customer!\n");
            createCustomer();
            mainMenu();
        }

        public static void mainMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("What do you want to do?\n(1) - Select Customer\n(2) - Create Customer\n(0) - Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        selectCustomer();
                        run = true;
                        selectedPersonMenu();
                        break;
                    case "2":
                        createCustomer();
                        break;
                    case "0":
                        running = false;
                        break;
                }
            }
        }

        public static void selectedPersonMenu()
        {
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
                int selected = intInput();
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
                    int tmp = i + 1;
                    Console.WriteLine("(" + tmp + ") - " + _selectedCategories[i]._name);
                }
                int selectedProduct = (intInput() -1);
                run = selectProduct(selectedProduct);
            }


        }

        public static void listShoppingCart()
        {
           Console.WriteLine("\n\nYour Shopping Cart:\n");
           int price = 0;
           int weight = 0;
           for (int i = 0; i < _customers[_selectedPerson]._shoppingCart.Count; i++)
           {
                Console.WriteLine(_customers[_selectedPerson]._shoppingCart[i]._quantity + "x " + _customers[_selectedPerson]._shoppingCart[i]._goods._name);
                price = price + (_customers[_selectedPerson]._shoppingCart[i]._goods._price * _customers[_selectedPerson]._shoppingCart[i]._quantity);
                weight = weight + (_customers[_selectedPerson]._shoppingCart[i]._goods._weight * _customers[_selectedPerson]._shoppingCart[i]._quantity);
           }
           int shipping = calculateShippingCost(weight, price);
           Console.WriteLine("\nYour total price is: " + price + "SEK\n" + "Your total weight is " + weight + "gram\nShipping: " + shipping + "SEK");
            Console.WriteLine("\nWhat do you want to do?\n(1) - Purchase\n(2) - Remove Product from Cart\n(0) - Go Back");
            int inputint;

            long age = (DateTime.Now.Year - getFirstDigits(_customers[_selectedPerson]._persNr));
            while (true)
            {
                inputint = intInput();
                if (inputint == 0 || (inputint > 0 && inputint <= 3))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not valid, try again");
                }
            }
            switch (inputint)
            {
                case 1:
                    purchase(price, shipping, age);
                    break;
                case 2:
                    deleteProduct();
                    break;
                case 0:
                    break;

            }
        }

        public static long getFirstDigits(long number)
        {
            number = Math.Abs(number);
            if (number == 0)
                return number;
            long numberOfDigits = (long)Math.Floor(Math.Log10(number) + 1);
            if (numberOfDigits >= 4)
                return (long)Math.Truncate((number / Math.Pow(10, numberOfDigits - 4)));
            else
                return number;
        }

        public static void purchase(int price, int shipping, long age)
        {
            if(age > 65)
            {
                Console.WriteLine("\nYou are over 65 years! You apply for the elders discount!\n You get 20% off the entire purchase!");
                Console.WriteLine("Your discount: " + ((int)(price * 0.2)) + "SEK");
                price = ((int)(price * 0.8));
            }
            Console.WriteLine("\nYour total is: " + price + "SEK\nShipping: " + shipping + "SEK\nItems will be shipped to:\n" + _customers[_selectedPerson]._adress._street + " " + _customers[_selectedPerson]._adress._streetNumber + "\n" + _customers[_selectedPerson]._adress._zipCode + " " + _customers[_selectedPerson]._adress._postAdress + "\nPayment is via Swish.\nSwish " + (price+shipping) + "SEK to 070-601 51 35.\nPress any key when payment is complete!");
            Console.ReadKey();
            Console.WriteLine("Thank you for your Purchase!");
            _customers[_selectedPerson]._shoppingCart.Clear();
            run = false;
        }

        public static void deleteProduct()
        {
            Console.WriteLine("What product do you want to remove? Type the number corresponding to the product!");
            for(int i = 0; i < _customers[_selectedPerson]._shoppingCart.Count; i++)
            {
                Console.WriteLine("(" + (i + 1) + ") - " + _customers[_selectedPerson]._shoppingCart[i]._goods._name);
            }
            int selectedDeleteProduct;
            while (true)
            {
                selectedDeleteProduct = (intInput() - 1);
                if(selectedDeleteProduct > _customers[_selectedPerson]._shoppingCart.Count)
                {
                    Console.WriteLine("Not valid, try again!");
                }else if(selectedDeleteProduct < 0 ){
                    Console.WriteLine("Not valid, try again!");
                }
                else
                {
                    break;
                }
            }
            _customers[_selectedPerson]._shoppingCart.RemoveAt(selectedDeleteProduct);
            Console.WriteLine("Remove product from shopping cart!");

        }

        public static int calculateShippingCost(int weight, int price)
        {
            int shipping;
            if(price > 5000){ shipping = 0; }
            else if(weight < 500) { shipping = 29; }
            else if (weight < 1500) { shipping = 49; }
            else if (weight < 2500) { shipping = 79; }
            else if (weight < 5000) { shipping = 149; }
            else{shipping = 499;}
            return shipping;
        }

        public static bool selectProduct(int product)
        {
            Console.WriteLine(_selectedCategories[product]._name + " is selected\n\n");
            Console.WriteLine(_selectedCategories[product]._name + "\nWeight: " + _selectedCategories[product]._weight + "\nDescriptions: " + _selectedCategories[product]._desc + "\nPrice: " + _selectedCategories[product]._price + "SEK");
            Console.WriteLine("Just type the quantity you want, type 0 for none!");
            int quantity = intInput();
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
                int selectPerson = intInput() - 1;
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
                while (true)
                {
                    try
                    {
                        persNr = long.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Not a valid input, try again!");
                    }

                }
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
