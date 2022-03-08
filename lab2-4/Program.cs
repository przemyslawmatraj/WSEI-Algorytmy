using System;

namespace lab_2
{
    class Program
    {
        public static double pierwiastek(double a, double n, double w, int count = 0)
        {
           if(count==a)
            {
                return w;
            }
            w = (1 / 2) * (pierwiastek(a, n,w) + a / pierwiastek(a, n));
            return w;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(pierwiastek(5, 2));
        }
    }
}
