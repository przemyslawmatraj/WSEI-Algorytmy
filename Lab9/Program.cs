
using System;
using System.Collections;
using System.Collections.Generic;

namespace lab9_zajęcia
{
    class HashTable: IEnumerable<int>
    {
        public List<int>[] arr = new List<int>[101];
        // dodanie liczby do struktury
        public bool Add(int value)
        {
            int hashCode = HashCode(value);
            if(arr[hashCode] == null)
            {
                arr[hashCode] = new List<int>();
                if(arr[hashCode].Contains(value))
                {
                    arr[hashCode] = new List<int>();
                }
                arr[hashCode].Add(value);
                return false ;
            }
            return true;
        }
        // usunięcie liczby ze struktury
        public bool Remove(int value)
        {
            int hashCode = HashCode(value);
            if (arr[hashCode] == null || !arr[hashCode].Contains(value))
            {
                return false;
                
            }
            return arr[hashCode].Remove(value);
        }
        // czy liczba jest w strukturze
        public bool Contains(int value)
        {
            int hashCode = HashCode(value);
            if (arr[hashCode] != null && arr[hashCode].Contains(value))
            {
                return true;
            }
            return false;
        }
        private int HashCode(int value)
        {
            return value.GetHashCode() % arr.Length;
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach(List<int> list in arr)
            {
               if(list != null)
                {
                    foreach(int val in list)
                    {
                        yield return val;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HashTable table = new HashTable();
            table.Add(4);
            table.Add(3);
            table.Add(6);
            table.Add(104);
            foreach (var item in table)
            {
                Console.WriteLine(item);
            }
        }
    }
}

