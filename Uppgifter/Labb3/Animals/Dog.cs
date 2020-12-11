﻿using System;

namespace Vecka50
{
    public class Dog : Animal
    {
        public Dog()
        {
            NumberOfLimb = 4;
            Color = "idk";
            Price = 25000;
            Console.WriteLine("Created new dog!");
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