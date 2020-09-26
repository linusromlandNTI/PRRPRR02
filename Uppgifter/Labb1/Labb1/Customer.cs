using System;
namespace Labb1
{
    public class Customer
    {
        public string _userName;
        public Adress _adress;
        public int[] _shoppingCart;
        public int _persNr;

        public Customer(string userName, int persNr)
        {
            _userName = userName;
            _persNr = persNr;
        }

    }
}
   
   
