using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternDemo.Strategy
{
    class LinusStrategy : INameGivingStrategy
    {
        public void NameGivning(string name)
        {
            Console.WriteLine("The libuys is: " + name);
        }
    }
}