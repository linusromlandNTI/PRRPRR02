using System;

namespace Vecka50
{
    public class Cat : Animal
    {
        public Cat()
        {
            NumberOfLimb = 4;
            Color = "idk";
            Price = 500;
            Console.WriteLine("Created new cat!");
        }
        public override void Breathe()
        {
            Console.WriteLine("The cat is breathing vry deep!");
        }

        public override void Rest()
        {
            Console.WriteLine("The cat is now resting, Schhh!");
        }

        public override void Eat()
        {
            Console.WriteLine("The cat is eating!");
        }
    }
}