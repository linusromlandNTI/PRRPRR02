using System;

namespace Vecka50
{
    public class Dog : Animal
    {
        public Dog()
        {
            NumberOfLimb = 4;
            Color = "idk";
            Console.WriteLine("New dog bro!");
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