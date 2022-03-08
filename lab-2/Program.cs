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
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 3, 5, 7, 9 };
            int sumary = Sum(array);
            Console.WriteLine(sumary);

        }
    }
}
