using System;
using System.Collections.Generic;

namespace Vecka50
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            Dog dog = new Dog();
            dog.Color = "HotPink";
            Goose goose = new Goose();
            goose.Color = "White";
            
            animals.AddRange(new Animal[]{dog, goose});

            foreach (var animal in animals)
            {
                Console.WriteLine();
                animal.Breathe();
                animal.Eat();
                animal.Rest();
                if (animal is Goose tempGoose)
                {
                    tempGoose.Swim();
                }
                Console.WriteLine("color: " + animal.Color);
                Console.WriteLine("NumberOfLimb: " + animal.NumberOfLimb);
            }
        }
    }
}