using System;

namespace Vecka50
{
    public class Goose : Animal
    {
        public Goose()
        {
            NumberOfLimb = 2;
            Color = "idk";
            Price = 150;
            Console.WriteLine("Created new Goose!");
        }
        public override void Breathe()
        {
            Console.WriteLine("The goose is breathing vry deep!");
        }

        public override void Rest()
        {
            Console.WriteLine("The goose is now resting, Sch!");
        }

        public override void Eat()
        {
            Console.WriteLine("The goose is eating!");
        }
    }
}