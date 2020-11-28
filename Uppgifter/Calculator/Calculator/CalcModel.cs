using System;

namespace Calculator
{
    public class CalcModel
    {
        private int number = 0;
        private string calc;
        
        public int NumberMath {
            get { return number; }
            set { number = value; }
        }
        public string OperatorMath {
            get { return calc; }
            set { calc = value; }
        }

        public string print()
        {
            string tmp = "";
            if (number != 0)
            {
                tmp = number.ToString();
            }
            else if (!(string.IsNullOrEmpty(calc)))
            {
                tmp = OperatorMath;
            }
            return tmp;
        }
    }
}