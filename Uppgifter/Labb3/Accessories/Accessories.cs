using System;

namespace Vecka50
{
    public abstract class Accesories
    {
        //Properties of animal
        public int Price { get; set; }
        public string Color { get; set; }
        
        //Functions for the Class/What it can do
        public abstract void Use();
        
        public abstract void Destroy();
        
        public abstract void Throw();
    }
}