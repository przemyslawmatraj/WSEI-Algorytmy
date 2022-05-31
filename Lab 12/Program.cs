using System;
using System.Collections.Generic;
using System.Linq;

namespace ćwiczenia
{
    class Program
    {
        static void Main(string[] args)
        {
            // tworzymy testy
            int points = 0;
            if (IsPalindrome("a") && IsPalindrome("aaa") && IsPalindrome("") && IsPalindrome("zakaz"))
            {
                Console.WriteLine("Zadanie 1: Dobrze");
                points++;
            }
            if (IsAnagrams("abcd", "dcba") && IsAnagrams("aa", "aa") && !IsAnagrams("AA", "aa") && IsAnagrams("", "") && !IsAnagrams("abc", "abca"))
            {
                Console.WriteLine("Zadanie 2: Dobrze");
                points++;
            }
            if (LongestIndenticalString("aaaa").Equals("aaaa") && LongestIndenticalString("abcddddaaddd").Equals("dddd") && LongestIndenticalString("abcd").Equals("a") && LongestIndenticalString("abbcdd").Equals("bb"))
            {
                Console.WriteLine("Zadanie 3: Dobrze");
                points++;
            }


        }

        // czy input jest palindromem
        public static bool IsPalindrome(string input)
        {
            List<char> word = new List<char>();
            for (int i = input.Length; i > 0; i--)
            {
               word.Add(input[i-1]);
            }
            string joinedName = string.Join("", word);
            return input == joinedName;
        }

        // czy łańcuchy są anagramami
        public static bool IsAnagrams(string a, string b)
        {
            char[] arr1 = a.ToCharArray();
            char[] arr2 = b.ToCharArray();
            Array.Sort(arr1);
            Array.Sort(arr2);
            return Enumerable.SequenceEqual(arr1, arr2);
        }

        // zwróć najdłuższy ffragment złożony z unikalnych znaków wejścia
        public static string LongestIndenticalString(string input)
        {
            input += " "; 
            List<char> chars = new List<char>();
            List<string> results = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {

                if (i == 0)
                {
                    chars.Add(input[i]);
                }else if (input[i - 1] == input[i]) {
                    chars.Add(input[i]);
                } else
                {
                    
                    string result = "";
                    foreach (char c in chars)
                    {
                        result += c.ToString();
                    }
                    results.Add(result);
                    chars.Clear();
                }
                
            }

            var match = results.OrderByDescending(n => n.Length)
                .FirstOrDefault(n => input.Contains(n));

            Console.WriteLine(match);

            if (match == null)
            {
                return "";
            }
            else
            {
                return match;
            }


            
        }
    }
}