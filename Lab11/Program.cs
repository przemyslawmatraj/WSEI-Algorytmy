using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    interface IGraph
    {
        //czy powiodlo sie czy nie
        bool AddDirectEdge(int source, int target, int weight);
        bool AddUndirectEdge(int source, int target, int weight);
        public void LevelTraversal(int source, Action<int> action);
    }
    class AdMatrix: IGraph
    {
        private int[,] _matrix;

        public AdMatrix(int size)
        {
            _matrix = new int[size, size];
        }

        public bool AddDirectEdge(int source, int target, int weight)
        {
            //kod sprawdzajacy source i target i zwracajacy false dla niepoprawnych source i target
            _matrix[source, target] = weight;
            return true;
        }

        public bool AddUndirectEdge(int source, int target, int weight)
        {

            return AddDirectEdge(source, target, weight) && AddDirectEdge(target, source, weight);
        }

        public void LevelTraversal(int source, Action<int> action)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < _matrix.GetLength(0); row++)
            {
                sb.Append($"wierzchołek {row} połączony z: ");
                for (int col = 0; col < _matrix.GetLength(1); col++)
                {
                    if (_matrix[row, col] != 0)
                    {
                        sb.Append(col + " ");
                    }
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }

    record Edge
    {
        public int Node { get; set; }
        public double Weight { get; set; }

    }

    class AdList : IGraph
    {
        Dictionary<int, HashSet<Edge>> _edges = new Dictionary<int, HashSet<Edge>>();

        public bool AddDirectEdge(int source, int target, int weight)
        {
            if (!_edges.ContainsKey(source))
            {
                _edges.Add(source, new HashSet<Edge>());
            };
            if (!_edges.ContainsKey(target))
            {
                _edges.Add(target, new HashSet<Edge>());
            };
            _edges[source].Add(new Edge() { Node = target, Weight = weight });
            return true;
        }

        public bool AddUndirectEdge(int source, int target, int weight)
        {
            return AddDirectEdge(source, target, weight) && AddDirectEdge(target, source, weight);
        }

        public void LevelTraversal(int source, Action<int> action)
        {
            Queue<int> q = new Queue<int>();
            ISet<int> visited = new HashSet<int>();
            q.Enqueue(source);
            while (q.Count > 0)
            {
                int node = q.Dequeue();
                if(visited.Contains(node))
                {
                    continue;
                }
                action.Invoke(node);
                visited.Add(node);
                HashSet<Edge> children = _edges[node];
                foreach (Edge edge in children)
                {
                    if (!visited.Contains(edge.Node))
                    {

                    q.Enqueue(edge.Node);
                    }
                }
            }
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            IGraph graph = new AdList();
            graph.AddDirectEdge(0, 1, 1);
            graph.AddDirectEdge(1, 3, 1);
            graph.AddDirectEdge(2, 3, 1);
            graph.AddDirectEdge(3, 0, 1);
            graph.AddDirectEdge(0, 2, 1);
            graph.AddDirectEdge(3, 2, 1);
            //Console.WriteLine(graph);
            graph.LevelTraversal(0, n => Console.WriteLine(n));
        }
    }
}
