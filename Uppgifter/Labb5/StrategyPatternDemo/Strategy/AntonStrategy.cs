using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternDemo.Strategy
{
    class PowerOfStrategy : ICalculationStrategy
    {
        public void NameGivning(double numberOne, double numberTwo)
        {
            var result = Convert.ToInt32(numberOne) ^ Convert.ToInt32(numberTwo);
            Console.WriteLine("The result is: " + result);
        }
    }
}
