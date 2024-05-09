using System;

namespace Part3
{
    class Program
    {
        static void Main(string[] args)
        {
          
            NumericalExpression n = new NumericalExpression(9223372036854775807);
            Console.WriteLine(n);
        }
    }
}
