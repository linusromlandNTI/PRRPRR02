using System;

namespace Metoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add to int? Give me the first one!");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Give me the second one");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(addInt(a, b));
        }
        static int addInt(int a, int b)
        {
            return a + b;
        }
    }
}
