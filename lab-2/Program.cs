using System;

namespace lab_2
{
    class Program
    {
        public static int Sum(int[] x, int sum = 0, int index = 0)
        {
            if(index == x.Length)
            {
                return sum;
            }

            sum += x[index];
            return Sum(x, sum, index+1);
        }
        public static int Count(int[] x, int e = 0, int index = 0, int count = 0)
        {
            if (index == x.Length)
            {
                return count;
            }
            if (x[index] == e)
            {
                count++;
            }
            return Count(x, e, index + 1, count);
        }
        public static int Mod(int e, int m, int y = 0)
        {
            if (y < e)
            {
                y += m;
                return Mod(e, m, y);
            }
            else
            {
                return e - y;
            }


        }
        public static void ModArr(int[] x, int index = 0)
        {
            if (index == x.Length)
            {
                return;
            }
            if (Mod(x[index], 3) == 0 && Mod(x[index], 5) == 0)
            {
                Console.WriteLine("FizzBuzz");
                ModArr(x, index + 1);
            }
            else if (Mod(x[index], 3) == 0)
            {
                Console.WriteLine("Fizz");
                ModArr(x, index + 1);
            }
            else if (Mod(x[index], 5) == 0)
            {
                Console.WriteLine("Buzz");
                ModArr(x, index + 1);
            }
            else
            {
                Console.WriteLine(x[index] + " ");
                ModArr(x, index + 1);
            }

        }
        public static double Sqrt(double s, double n, double x = 0, int count = 0)
        {
            if (count == 0)
            {
                double temp = s / 2;
                return Sqrt(s, n, temp, count + 1);
            }
            else if (count == n+2)
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
            Console.WriteLine("----------Zadanie 1----------");

            int[] array = new int[] { 1, 3, 5, 7, 9 };
            int sumary = Sum(array);
            Console.WriteLine(sumary);

            Console.WriteLine("----------Zadanie 2----------");

            int[] array2 = new int[] { 4, 4, 6, 7, 4, 5, 23, 7 };
            Console.WriteLine(Count(array2, 4));

            Console.WriteLine("----------Zadanie 3----------");

            int[] array3 = new int[100];
            for (int i = 0; i < array3.Length; i++)
            {
                array3[i] = i+1;
            }
            ModArr(array3);

            Console.WriteLine("----------Zadanie 4----------");

            Console.WriteLine(Sqrt(5, 2));
        }
    }
}
