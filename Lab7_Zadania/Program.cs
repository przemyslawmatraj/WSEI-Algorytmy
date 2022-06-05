using System;
using System.Collections.Generic;

namespace lab_7
{

    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }

    // ✅ Zadanie 2 Zaimplementuj własną klasę kolejki dowiązaniowej z węzłami klasy Node<T> i metodami Enqueue i Dequeue

    class MyQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        public void Enqueue(T value)
        {
            var node = new Node<T> { Value = value };
            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }
        }
        public T Dequeue()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            var value = _head.Value;
            _head = _head.Next;
            return value;
        }
    }



    class Stack<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public void Push(T value)
        {
            Node<T> newNode = new Node<T> { Value = value, Next = _head };
            _head = newNode;
        }
        public bool isEmpty()
        {
            return _head == null;
        }

        public T Pop()
        {
            if (isEmpty())
            {
                throw new Exception("Stack is empty");
            }
            T result = _head.Value;
            _head = _head.Next;
            return result;
        }

        public void Insert(T value)
        {
            Node<T> node = new Node<T> { Value = value };
            if (isEmpty())
            {
                _head = node;
                _tail = _head;
                return;
            }
            _tail.Next = node;
            _tail = node;
        }
        public T Remove()
        {
            if (isEmpty())
            {
                throw new Exception("Queue is empty");
            }
            T result = _head.Value;
            _head = _head.Next;
            return result;
        }

        // ✅ ZADANIE 3 - W klasie Stack<T> z instrukcji dopisz metodę Reverse, która odwraca elementy na stosie.


        public void Reverse()
        {
            Node<T> previous = null;
            Node<T> current = _head;
            Node<T> next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            _head = previous;
        }

    }

    // ✅ Zadanie 6 - Zaimplementuj własną klasę MyLinkedList<T>, która oprócz typowych metod dla listy jednokierunkowej umożliwia przejście od końca do początku.

    class MyLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        public void Add(T value)
        {
            var node = new Node<T> { Value = value };
            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }
        }
        public T Remove()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            var value = _head.Value;
            _head = _head.Next;
            return value;
        }
        public T GetFirst()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            return _head.Value;
        }
        public T GetLast()
        {
            if (_tail == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            return _tail.Value;
        }
        public void Reverse()
        {
            Node<T> previous = null;
            Node<T> current = _head;
            Node<T> next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            _head = previous;
        }
        public void FromEndToStart()
        {
            this.Reverse();
            while (_head != null)
            {
                Console.WriteLine(_head.Value);
                _head = _head.Next;
            }
            this.Reverse();
        }
        // ✅ Zadanie 7 - Wskutek błędnej implementacji w pewnej liście następuje czasami przypisanie do pola Next ogona
        //referencji do głowy, co powoduje powstanie listy cyklicznej. Napisz algorytm w postaci metody, który
        //zwraca true, gdy przekazana lista jest cykliczna.
        public bool DetectLoop()
        {
            Node<T> current = _head;
            Node<T> next = _head;
            while (next != null && next.Next != null)
            {
                current = current.Next;
                next = next.Next.Next;
                if (current == next)
                {
                    return true;
                }
            }
            return false;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Node<string> node = new Node<string> { Value = "adam" };
            node.Next = new Node<string> { Value = "ewa" };
            node.Next.Next = new Node<string> { Value = "jacek" };
            Node<string> head = node;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

            Stack<string> stack = new Stack<string>();

            stack.Push("Adam");
            stack.Push("Ewa");
            stack.Push("Karol");

            while (!stack.isEmpty())
            {
                Console.WriteLine(stack.Pop());
            }

        }
    }
}
