﻿using System;

namespace Labb3
{
    public class GooseHat: Accesories
    {
        public GooseHat()
        {
            Color = "idk";
            Price = 833;
        }
        public override void Throw()
                {
                    Console.WriteLine("You just threw the goosehat!");
                }

        public override void Destroy()
                {
                    Console.WriteLine("You destoyed the goosehat!");
                }

        public override void Use()
                {
                    Console.WriteLine("You put on the hat made of goose!!");
                }
    }
}