using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternDemo.Strategy
{
    class AdditionStrategy : ICalculationStrategy
    {
        public void Calculate(double numberOne, double numberTwo)
        {
            var result = numberOne + numberTwo;
            Console.WriteLine("The result is: " + result);
        }
    }
}
