namespace Calculator
{
    public class CalcModel
    {
        private int number;
        private char calc;
        
        public int NumberMath {
            get { return number; }
            set { number = value; }
        }
        public char OperatorMath {
            get { return calc; }
            set { calc = value; }
        }

        public string print()
        {
            string cooling = "";
            if (NumberMath != null)
            {
                cooling = NumberMath.ToString();
            }
            else if (OperatorMath != null)
            {
                cooling = OperatorMath.ToString();
            }

            return cooling;
        }
    }
}