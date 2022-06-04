using System;

namespace Lab3_Exercise
{
    public class Program
    {
        static int fibonnaci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            return fibonnaci(n - 1) + fibonnaci(n - 2);
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(fibonnaci(n));
        }
    }
}
