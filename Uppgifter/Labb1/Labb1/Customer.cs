using System;
namespace Labb1
{
    public class Customer
    {
        public string _userName;
        private string _adress;
        private int _postAdress;
        private string _zipCode;
        private int[] _shoppingCart;
        private int _persNr;

        public Customer(string userName, string adress, int postAdress, string zipCode, int persNr)
        {
            _userName = userName;
            _adress = adress;
            _postAdress = postAdress;
            _zipCode = zipCode;
            _persNr = persNr;
        }
    }

}
   
   
