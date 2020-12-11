using System;

namespace Vecka50
{
    public abstract class Animal
    {
        //Properties of animal
        public int NumberOfLimb { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        
        public string Name { get; set; }
        
        //Functions for the Class/What it can do
        public abstract void Breathe();
        public abstract void Rest();
        public abstract void Eat();
    }
}