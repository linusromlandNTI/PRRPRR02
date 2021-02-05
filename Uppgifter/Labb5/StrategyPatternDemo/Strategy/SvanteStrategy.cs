using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternDemo.Strategy
{
    class SvanteStrategy : INameGivingStrategy
    {
        public void NameGivning(string name)
        {
            Console.WriteLine("The svante is: " + name);
        }
    }
}