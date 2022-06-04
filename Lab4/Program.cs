using System;
using System.Linq;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 5, 8, 2, 9, 2, 1 };
            SortFirstMethod(data);
            SortSecondMethod(data);
        }

        public static void SortFirstMethod(int[] data)
        {
            int numbersCount = data.Length;
            int[] result = new int[data.Length];

            for (int i = 0; i < numbersCount; i++)
            {
                int smallestNumber = data.Min();
                result[i] = smallestNumber;
                int numIndexToRemove = Array.IndexOf(data, smallestNumber);
                data = data.Where((val, idx) => idx != numIndexToRemove).ToArray();
            }
            foreach (int oneNumber in result)
            {
                Console.WriteLine(oneNumber);
            }
        }
        public static void SortSecondMethod(int[] data)
        {
            int numbersCount = data.Length;
            int[] result = new int[data.Length];

            for (int i = 0; i < numbersCount; i++)
            {
                int smallestNumber = data.Max();
                result[i] = smallestNumber;
                int numIndexToRemove = Array.IndexOf(data, smallestNumber);
                data = data.Where((val, idx) => idx != numIndexToRemove).ToArray();
            }
            foreach (int oneNumber in result)
            {
                Console.WriteLine(oneNumber);
            }
        }
    }
}