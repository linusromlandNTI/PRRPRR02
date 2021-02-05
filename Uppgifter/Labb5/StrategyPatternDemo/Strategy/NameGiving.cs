using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPatternDemo
{
    class Calculation
    {
        private INameGivingStrategy _strategy;

        // Constructor

        public Calculation(INameGivingStrategy strategy)
        {
            _strategy = strategy;
        }

        public void CalculationInterface(string name)
        {
            _strategy.NameGivning(name);
        }
    }
}
