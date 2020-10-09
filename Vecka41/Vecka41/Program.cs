using System;

namespace Vecka41
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produkt> cart = new List<Produkt>();
            cart.Add(new Milk());
            cart[0].FatContent = 1;
            cart[0].ProductNr = 123;
            cart[0].StockStatus = 10;

            cart.Add(new Nocco());
            cart[1].Flavour = "Usch Nocco";
            cart[1].ProductNr = 234;
            cart[1].StockStatus = 11;

            cart.Add(new Coffee());
            cart[2].Roast = "baclk";
            cart[2].ProductNr = 345;
            cart[2].StockStatus = 12;
        }
    }
}
