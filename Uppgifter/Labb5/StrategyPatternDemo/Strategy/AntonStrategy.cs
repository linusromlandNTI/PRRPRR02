using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternDemo.Strategy
{
    class AntonStrategy : INameGivingStrategy
    {
        public void NameGivning(string name)
        {
            Console.WriteLine("The anton is: " + name);
        }
    }
}
