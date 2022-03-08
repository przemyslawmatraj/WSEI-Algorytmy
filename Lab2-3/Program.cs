﻿using System;

namespace lab_2
{
    class Program
    {
        public static int Mod(int e, int m, int y = 0)
        {
            if (y < e)
            {
                y += m;
                return Mod(e, m, y);
            } else
            {
                return e - y;
            }
                
            
        }
        public static void Count(int[] x, int index = 0)
        {
            if (index == x.Length)
            {
                return;
            }
            if(Mod(x[index], 3)==0 && Mod(x[index], 5)==0)
            {
                Console.WriteLine("FizzBuzz");
                 Count(x, index + 1); 
            } else if (Mod(x[index], 3) == 0) 
            {
                Console.WriteLine("Fizz");
                 Count(x, index + 1); 
            } else if (Mod(x[index], 5)==0) {
                Console.WriteLine("Buzz");
                 Count(x, index + 1); 
            } else
            {
                Console.WriteLine(x[index] + " ");
                Count(x, index + 1);
            }
            
        }
        static void Main(string[] args)
        {
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            Count(array);
        }
    }
}