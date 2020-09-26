using System;
namespace Labb1
{
    public class Goods
    {
        public int _weight;
        public string _name;
        public int _price;
        public int _category;
        public string _desc;

        public Goods(int weight, string name, int price, int category, string desc)
        {
            _weight = weight;
            _name = name;
            _price = price;
            _category = category;
            _desc = desc;
        }
    }
}
