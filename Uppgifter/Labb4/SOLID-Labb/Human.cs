using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Labb
{
    class Human
    {
        public Human(string nameIn)
        {
            string name = nameIn;
        }

        public List<Animal> _animalsList = new List<Animal>();

        public void GainOwnershipOfAnimal(Animal animal)
        {
            _animalsList.Add(animal);
        }
    }
}