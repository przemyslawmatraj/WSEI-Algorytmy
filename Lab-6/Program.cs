using System;

namespace Lab_6
{
    class IntQueue
    {
        public static readonly int Capacity = 5;
        private int[] _arr = new int[Capacity];
        private int last = -1; //indeks ostatnio wstawionej wartosci do tablicy
        private int first = -1;
        public bool Insert(int item)
        {
            //patrzymy czy zmiesci sie jeszcze w tablicy
            if (last >= Capacity - 1)
            {
                return false;
            }
            _arr[++last] = item;
            if (first == -1)
            {
                first = last;
            }
            return true;
        }
        public int Remove()
        {
            if (first == -1)
            {
                throw new Exception();
            }
            if (first >= Capacity - 1)
            {
                int result = _arr[first];
                first = -1;
                return result;
            }
            return _arr[first++];
        }
        public int Count()
        {
            if (first == -1)
            {
                return 0;
            }
            return last - first + 1;
        }
    }

    class PriorityQueue
    {
        public static readonly int Capacity = 10;
        public int[] _arr = new int[Capacity];
        private int last = -1;

        private int left(int parent)
        {
            return parent * 2 + 1;
        }

        private int right(int parent)
        {
            return parent * 2 + 1;
        }

        private int parent(int child)
        {
            return (child - 1) / 2;
        }

        public bool Insert(int item) {
            if(last == Capacity - 1)
            {
                //utworzyc wieksza tablice copy
                //skopiowac z arr do copy
                //przypisać copy do _arr
                return false;
            }
            _arr[++last] = item;
            RebuildUp(last);
            return false;
        }

        public void RebuildUp(int child)
        {
            while (child !=0) //child to indeks komorki ktory obserwujemy
            {
                int p = parent(child);
                if (_arr[p] < _arr[child])
                {
                   //(_arr[p], _arr[child]) = (_arr[child], _arr[p]);
                   int temp = _arr[p];
                    _arr[p] = _arr[child];
                    _arr[child] = temp;
                  child = p;
                } else
                {
                    break;
                }
            }
        }
        public void RebuildDown()
        {
            int node = 0; //bo jest na samej górze
            while(node <= last)
            {
                int leftValue = _arr[left(node)];
                int rightValue = _arr[right(node)];
                if (_arr[node] >= leftValue && _arr[node] >= rightValue)
                {
                    break;
                }
                if(leftValue > rightValue)
                {
                    //zamień wartość z node z leftValue
                    node = left(node);
                } else
                {
                    //zamień wartość z node z rightValue
                    node = right(node);
                }
                //zrob swapy u góry, odwolaj sie do tablicy gdzie jest leftvalue 
                //sprawdz czy popraweni dziala usuwanie
                //mozecie posortowac
            }
        }

    public int Remove() 
        {
            //warunki czy mozna usunac
            //zachowanie dla pustej kolejki
            int removed = _arr[0];
            _arr[0] = _arr[last--];
            RebuildDown();
            return removed;

        }
    public int Count() {
        return last +1;
    }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IntQueue queue = new IntQueue();
            queue.Insert(5);
            queue.Insert(8);
            queue.Insert(10);
            if(queue.Count() == 3)
            {
                Console.WriteLine("OK");
            }
            int removed = queue.Remove();
            if(removed == 5)
            {
                Console.WriteLine("OK");
            }
            if(queue.Count() == 2)
            {
                Console.WriteLine("OK");
            }
            queue.Insert(3);
            queue.Insert(6);
            queue.Insert(9);
            Console.WriteLine(queue.Count());
            Console.WriteLine("Zad 2:");
            PriorityQueue priorityQueue = new PriorityQueue();
            priorityQueue.Insert(4);
            priorityQueue.Insert(7);
            priorityQueue.Insert(9);
            priorityQueue.Insert(14);
            foreach (int item in priorityQueue._arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
