using System;
namespace Labb1
{
    public class Customer
    {
        public string _userName;
        public Adress _adress;
        public ShoppingCart[] _shoppingCart;
        public long _persNr;

        public Customer(string userName, long persNr, Adress adress)
        {
            _userName = userName;
            _persNr = persNr;
            _adress = adress;
        }

    }
}
   
   
