using System;
namespace Vecka41
{
    public class Produkt
    {
        public Produkt()
        {
            private int _productNr;
            private int _stockStatus;

            public int ProductNumber {
                get { return _productNr; }
                set { _productNr = value; }
            }

            public int StockStatus
        {
                get { return _stockStatus; }
                set { _stockStatus = value; }
            }
    }
    }
    
}

