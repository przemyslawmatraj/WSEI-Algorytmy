using System;

namespace lab_2
{
    class Program
    {
        public static double Sqrt(double s, double n, double x = 0, int count = 0)
        {
           if (count==0)
            {
                double temp = s / 2;
                return Sqrt(s, n, temp, count + 1);
            }
            else if (count==n)
            {
                return x;
            }
            else
            {
                double temp = 0.5 * (x + s / x);
                return Sqrt(s, n, temp, count + 1);
            }
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Sqrt(10, 10));
        }
    }
}
