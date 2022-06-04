using System;

namespace lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 11, 8, 3, 2, 6, 4, 1 };
            MergeSortInPLace.Sort(arr);
            string[] arr2 = { "testa", "testb", "testc" };
            StringMergeSort.Sort(arr2);
        }
    }
    public class StringMergeSort
    {
        public static string[] Sort(string[] arr)
        {
            return StringSortArray(arr, 0, arr.Length - 1);
        }
        private static string[] StringSortArray(string[] arr, int left, int right)
        {
            if (left == right)
            {
                return new[] { arr[left] };
            }
            if (left + 1 == right)
            {
                Console.WriteLine();
                if (String.Compare(arr[left], arr[right]) < 0)
                {
                    return new[] { arr[left], arr[right] };
                }
                else
                {
                    return new[] { arr[right], arr[left] };
                }
            }
            var middle = (left + right) / 2;
            var leftArr = StringSortArray(arr, left, middle);
            var rightArr = StringSortArray(arr, middle + 1, right);
            var result = StringMerge(leftArr, rightArr);
            return result;
        }

        private static string[] StringMerge(string[] arr1, string[] arr2)
        {
            var result = new string[arr1.Length + arr2.Length];
            for (int i = 0, j = 0, k = 0; i < result.Length; i++)
            {
                if (j < arr1.Length && k < arr2.Length)
                {
                    Console.WriteLine(arr1[j]);
                    Console.WriteLine(arr2[k]);

                    if (String.Compare(arr1[j], arr2[k]) < 0)
                    {
                        result[i] = arr1[j++];
                    }
                    else
                    {
                        result[i] = arr2[k++];
                    }

                }
                if (j < arr1.Length)
                {
                    result[i] = arr1[j++];
                    continue;
                }
                if (k < arr2.Length)
                {
                    result[i] = arr2[k++];
                }
            }
            return result;
        }
    }
    public class MergeSortInPLace
    {
        public static void Sort(int[] arr)
        {
            SortArray(arr, 0, arr.Length - 1);
        }
        private static void SortArray(int[] arr, int left, int right)
        {
            if (left == right)
            {
                return;
            }
            if (left + 1 == right)
            {
                if (arr[left] > arr[right])
                {
                    (arr[left], arr[right]) = (arr[right], arr[left]);
                }
            }
            var middle = (left + right) / 2;
            SortArray(arr, left, middle);
            SortArray(arr, middle + 1, right);
            Merge(arr, left, middle, right);
        }
        private static void Merge(int[] arr, int left, int middle, int right)
        {
            Console.WriteLine(left);
            Console.WriteLine(arr[left]);
            Console.WriteLine(middle);
            Console.WriteLine(arr[middle]);
            Console.WriteLine(right);
            Console.WriteLine(arr[right]);
        }
        class StringHexPositionSort
        {
            private void Init()
            {
                throw new NotImplementedException();
            }

            private void Dequeue(string[] arr)
            {
                throw new NotImplementedException();

            }
            private int ExtractDigit(string str, uint position)
            {
                throw new NotImplementedException();
            }
            private void Enqueue(string[] arr, uint position)
            {

                throw new NotImplementedException();
            }
            public void Sort(string[] arr, int d)
            {
                Init();
                for (uint position = 0; position < d; position++)
                {
                    Enqueue(arr, position);
                    Dequeue(arr);
                }
            }
        }
    }
}