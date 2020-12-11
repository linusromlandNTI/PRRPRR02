using System;

namespace Labb3
{
    public class FoodBowl: Accesories
    {
        public FoodBowl()
        {
            Color = "idk";
            Price = 75;
        }
        public override void Throw()
        {
            Console.WriteLine("You just threw the bowl of food!");
        }

        public override void Destroy()
        {
            Console.WriteLine("You destoyed the Food Bowl!");
        }

        public override void Use()
        {
            Console.WriteLine("You ate the food in the bowlYpu ou areare werYou put on the hat made ofgoo goose!!");
        }
    }
}