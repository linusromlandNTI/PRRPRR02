using System;
using System.Linq;

namespace Metoder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = {"ett", "två", "tre", "fyra"};
            foreach (string a in reverseArray(strings))
            {
                Console.WriteLine(a);
            }
        }
        static int addInt(int[] a)
        {
            int sum = 0; 
            foreach(int b in a)
            {
                sum = sum + b;
            }
            return sum;
        }

        static string[] reverseArray(string[] a)
        {
            a.Reverse();
            return a;
        }

        static int[] largeAndSmall(int[] a)
        {
            int[] num = { 0, 0 };
            foreach (int b in a)
            {
                if(num[0] < b)
                {
                    num[0] = b;
                }else if(num[1] > b)
                {
                    num[1] = b;
                }
            }
            return num;
        }
    }
}
