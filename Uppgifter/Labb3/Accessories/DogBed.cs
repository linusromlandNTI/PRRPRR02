using System;

namespace Labb3
{
    public class DogBed : Accesories
    {
        public DogBed()
        {
            Color = "idk";
            Price = 125;
        }
        public override void Throw()
        {
            Console.WriteLine("You just threw the dog bed!");
        }

        public override void Destroy()
        {
            Console.WriteLine("You destoyed the Dog Bed!");
        }

        public override void Use()
        {
            Console.WriteLine("You slept in the dog bed!");
        }
    }
}