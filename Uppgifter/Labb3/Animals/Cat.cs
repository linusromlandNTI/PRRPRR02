using System;

namespace Labb3
{
    public class Cat : Animal
    {
        public Cat()
        {
            NumberOfLimb = 4;
            Price = 500;
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