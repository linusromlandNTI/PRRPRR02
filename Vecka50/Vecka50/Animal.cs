using System;

namespace Vecka50
{
    public abstract class Animal
    {
        public Animal()
        {
            Console.WriteLine("New animal in progress, very cool!");
        }
        
        //Properties of animal
        public int NumberOfLimb { get; set; }
        public string Color { get; set; }
        
        //Functions for the Class/What it can do
        public abstract void Breathe();
        public abstract void Rest();
        public abstract void Eat();

    }
}