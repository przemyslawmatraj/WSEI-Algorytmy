﻿using System.Threading.Channels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_10_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Node<File> filesRoot = new Node<File>() { Value = new File("C", 0), Children = new List<Node<File>>() };

            FileSystem files = new FileSystem() { Root = filesRoot };
            files.Root.Children.Add(new Node<File>()
            {
                Value = new File("home", 0)
            });
            Node<File> directoryA = new Node<File>()
            {
                Value = new File("game", 0),
                Children = new List<Node<File>>()
                {
                    new Node<File>() {Value = new File("config.cfg", 1478)},
                    new Node<File>() {Value = new File("data.bin", 1229000)},
                    new Node<File>() {Value = new File("graphics.bin", 57290)},
                    new Node<File>() {Value = new File("inputs.bin", 7829000)},
                }
            };
            Node<File> directoryB = new Node<File>()
            {
                Value = new File("app", 0),
                Children = new List<Node<File>>()
                {
                    new Node<File>() {Value = new File("config.cfg", 1478), Children = null},
                    new Node<File>() {Value = new File("data.bin", 1229000), Children =  null},
                    new Node<File>() {Value = new File("graphics.bin", 57290)},
                    new Node<File>() {Value = new File("inputs.bin", 7829000)},
                }
            };
            files.Root.Children.Add(directoryA);
            files.Root.Children.Add(directoryB);
            try
            {
                int count = 0;
                files.PreorderTraversal(n =>
                {
                    count += 1;
                });
                if (count == 12)
                {
                    Console.WriteLine("Zadanie 1: 1");
                }
                else
                {
                    Console.WriteLine("Zadanie 1: 0");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Zadanie 1: 0");
            }
            try
            {
                int count = 0;
                files.PostorderTraversal(n => count += 1);
                if (count == 12)
                {
                    Console.WriteLine("Zadanie 2: 1");
                }
                else
                {
                    Console.WriteLine("Zadanie 2: 0");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Zadanie 2: 0");
            }
            try
            {
                if (files.GetSize() == 18233536)
                {
                    Console.WriteLine("Zadanie 3: 1");
                }
                else
                {
                    Console.WriteLine("Zadanie 3: 0");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Zadanie 3: 0");
            }

            try
            {
                var result = files.GetAbsolutePaths();
                if (result.Count == 9 && result.Contains("C:home") && result.Contains("C:game:graphics.bin") && result.Contains("C:app:inputs.bin"))
                {
                    Console.WriteLine("Zadanie 4: 1");
                }
                else
                {
                    Console.WriteLine("Zadanie 4: 0");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Zadanie 4: 0");
            }
        }

    }

    public class Node<T>
    {
        public T Value { get; init; }
        public List<Node<T>> Children { get; init; }
    }

    public class Tree<T>
    {
        public Node<T> Root { get; set; }


        //Zadanie 1
        //Zaimplementuj metodę przechodzenia po drzewie metodą pre-order
        public void PreorderTraversal(Action<Node<T>> action)
        {
            if (Root == null)
            {
                throw new Exception("Tree is empty");
            }
            action(Root);
            if (Root.Children != null || Root.Children.Count > 0)
            {
                foreach (var child in Root.Children)
                {
                    PreorderTraversal(action);
                }
            }
        }



        //Zadanie 2
        //Zaimplementuj metodę prechodzenia po drzewie metodą post-order
        public void PostorderTraversal(Action<Node<T>> action)
        {
            if (Root == null)
            {
                throw new Exception("Tree is empty");
            }
            if (Root.Children != null)
            {
                foreach (var child in Root.Children)
                {
                    PostorderTraversal(action);
                }
            }
            action(Root);
        }

        public List<T[]> GetPaths()
        {
            Stack<T> stack = new Stack<T>();
            List<T[]> paths = new List<T[]>();
            GetPathsInternal(Root, stack, paths);
            return paths;
        }

        private void GetPathsInternal(Node<T> node, Stack<T> stack, List<T[]> paths)
        {
            if (node == null)
            {
                return;
            }

            stack.Push(node.Value);
            if (IsLeaf(node))
            {
                paths.Add(stack.ToArray());
                stack.Pop();
                return;
            }

            foreach (var n in node.Children)
            {
                GetPathsInternal(n, stack, paths);
            }

            stack.Pop();

            bool IsLeaf(Node<T> node)
            {
                return node.Children == null || node.Children.Count == 0;
            }
        }
    }

    public record File(string Name, int Size);

    public class FileSystem : Tree<File>
    {
        //drzewo zawiera rekordy, z nazwą pliku i jego rozmiarem,
        //jeśli rozmiar jest równy 0 i posiada dzieci to rekord jest katalogiem
        //jeśli rozmiar jest większy od 0 i nie posiada dzieci to element jest plikiem

        //Zadanie 3
        //Zaimplementuj metodę, która obliczy rozmiar wszystkich plików w drzewie plików.
        //Wykorzystaj jedną z metod przeglądania drzewa z klasy Tree
        public int GetSize()
        {
            int size = 0;
            PreorderTraversal(n =>
            {
                if (n.Value.Size > 0)
                {
                    size += n.Value.Size;
                }
            });
            return size;
        }


        // Zadanie 4
        // Zaimplementuj metodę, która zwróci listę ścieżek w postaci łańcucha do każdego liścia w drzewie
        // do oddzielania kolejnych elementów drzewa zastosuj znak ':' np. :katalogX:katalogY:plikZ
        // Wykorzystaj metodę GetPath, która zwraca ściezki w postaci tablicy rekordów File.
        // Pamiętaj, że GetPath zwraca elementy ściezki w odwróconej kolejności!
        public List<string> GetAbsolutePaths()
        {
            List<List<File[]>> paths = new List<List<File[]>>();
            PreorderTraversal(n =>
            {
                paths.Add(GetPaths());
            });
            return null;

        }
    }
}