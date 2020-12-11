using System;

namespace Labb3
{
    public abstract class Accesories: Product
    {
        //Properties of Accesories
        public int Weight { get; set; }
        public string Color { get; set; }
        
        //Functions for the Class/What it can do
        public abstract void Use();
        
        public abstract void Destroy();
        
        public abstract void Throw();
    }
}