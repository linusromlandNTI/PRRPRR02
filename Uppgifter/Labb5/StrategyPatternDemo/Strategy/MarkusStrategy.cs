using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternDemo.Strategy
{
    class MarkusStrategy : INameGivingStrategy
    {
        public void NameGivning(string name)
        {
            Console.WriteLine("The markus is: " + name);
        }
    }
}