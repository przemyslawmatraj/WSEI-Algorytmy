using System;

namespace lab_3
{
    public class CashRegister
    {
        static readonly int ONE = 0;
        static readonly int TWO = 1;
        static readonly int FIVE = 2;

        private readonly int[] _coins = new int[3];

        public CashRegister(int[] coins)
        {
            this._coins = coins;
        }

        private int getAmount(int[] coins)
        {
            
            return coins[ONE] + coins[TWO] * 2 + coins[FIVE] * 5;
        }

        int[] Payment(int[] income, int amount)
        {
            if (amount > getAmount(income)) {
                return new int[] { };
            }
            // pozostałe warunki uniemozliwiajace obliczenie reszty jak ujemne amount, ujemna liczba monet itd.
                throw new NotImplementedException();
            int rest = getRemainder(income, amount);
            registerCash(income);
            return calcRest(rest);
        }
        private int getRemainder(int[] income, int amount)
        {
            return getAmount(income) - amount;
        }
        public int[] calcRest(int rest)
        {
            // obliczanie liczby monet skladajacych sie na reszte
            //obliczenie piatek, dwojek, jedynek
            // jesli brakuje ktorys z nich to wydawac inne/mniejsze nominaly
            throw new NotImplementedException();
        }
        public void registerCash(int[] income)
        {
            for (int i = 0; i < _coins.Length; i++)
            {
                _coins[i] += income[i];
            }
        }
    }
    static class SinTable
    {
        static private double[] sinTable;
        static SinTable()
        {
            sinTable = new double[360];
            // wypelni tablice od 0 do 360
            for (int i = 0; i < sinTable.Length; i++)
            {
                sinTable[i] = Math.Sin(i * Math.PI / 180);
            };
        }

        public static double Sin(int deg)
        {
            if (deg >= 0)
            {
                return sinTable[deg % 360];
            } else
            {
                return -sinTable[(-deg) % 360];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fibonacci(42));
            Console.WriteLine(SinTable.Sin(90));
        }

        public static long fibonacci(int n)
        {
            long[] mem = new long[n];
            Array.Fill<long>(mem, -1);
            return fib(n, mem);
        }
        private static long fib(int n, long[] mem)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }
            else if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            if(mem[n-1] == -1)
            {
                mem[n - 1] = fib(n - 1, mem);
            }
            if(mem[n-2] == -1)
            {
                mem[n - 2] = fib(n - 2, mem);
            }
            return mem[n - 1] + mem[n - 2];
        }
    }
}
