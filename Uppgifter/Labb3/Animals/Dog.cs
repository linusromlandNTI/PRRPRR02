using System;

namespace Labb3
{
    public class Dog : Animal
    {
        public Dog()
        {
            NumberOfLimb = 4;
            Price = 25000;
        }
        public override void Breathe()
        {
            Console.WriteLine("The doggo is breathing vry deep!");
        }

        public override void Rest()
        {
            Console.WriteLine("The dog is now resting, Schhh!");
        }

        public override void Eat()
        {
            Console.WriteLine("The dog is eating!");
        }
    }
}