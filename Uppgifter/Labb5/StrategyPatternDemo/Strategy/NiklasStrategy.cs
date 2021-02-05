using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternDemo.Strategy
{
    class NiklasStrategy : INameGivingStrategy
    {
        public void NameGivning(string name)
        {
            Console.WriteLine("The niklass is: " + name);
        }
    }
}