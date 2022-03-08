using System;

namespace lab_2
{
    class Program
    {
        public static int Count(int[] x, int e = 0, int index = 0, int count = 0)
        {
            if (index == x.Length)
            {
                return count;
            }
            if(x[index]==e)
            {
                count++;
            }
            return Count(x, e, index + 1, count);
        }
        static void Main(string[] args)
        {
            int[] array = new int[] { 4,4,6,7,4,5,23,7 };
            Console.WriteLine(Count(array, 4));
        }
    }
}
