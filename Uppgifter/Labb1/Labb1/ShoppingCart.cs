using System;
namespace Labb1
{
    public class ShoppingCart
    {
        public Goods _goods;
        public int _quantity;

        public ShoppingCart(Goods goods, int quantity)
        {
            _goods = goods;
            _quantity = quantity;
        }
    }
}
