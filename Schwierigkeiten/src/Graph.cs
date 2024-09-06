using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schwierigkeiten.src
{
    internal class Graph
    {
        private Dictionary<char, List<char>> adjList;

        public Graph()
        {
            adjList = [];
        }

        //List Linear
        //Hashset consitent

        public void AddNode(char node)
        {
            if (!adjList.ContainsKey(node))
            {
                adjList[node] = [];
            }
        }

        public void AddEdge(char from, char to)
        {
            if (!adjList[from].Contains(to))
                adjList[from].Add(to);
        }

        public void RemoveEdge(char from, char to)
        {
            adjList[from].Remove(to);
        }

        public void RemoveCycle()
        {
            while (ContainsCycle())
            {
                foreach (var node in adjList.Keys.ToList())
                {
                    foreach (var neighbor in adjList[node].ToList())
                    {
                        // Temporär die Kante entfernen
                        adjList[node].Remove(neighbor);

                        // Überprüfen, ob es noch einen Zyklus gibt
                        if (!ContainsCycle() && adjList[neighbor].Count != 0)
                        {
                            return; // Zyklus entfernt
                        }

                        // Kante wieder hinzufügen, wenn immer noch Zyklen vorhanden sind
                        adjList[node].Add(neighbor);
                    }
                }
            }
        }

        public bool ContainsCycle()
        {
            HashSet<char> visited = [];
            HashSet<char> stack = [];
            foreach (var node in adjList.Keys)
            {
                if (FindCycle(node, visited, stack))
                    return true;
            }
            return false;
        }

        private bool FindCycle(char node, HashSet<char> visited, HashSet<char> stack)
        {
            if (stack.Contains(node))
                return true; // Zyklus gefunden

            if (visited.Contains(node))
                return false; // Kein Zyklus hier

            visited.Add(node);
            stack.Add(node);

            if (adjList.TryGetValue(node, out List<char>? value))
            {
                foreach (char neighbor in value)
                {
                    if (FindCycle(neighbor, visited, stack)) 
                        return true;
                }
            }

            stack.Remove(node);
            return false;
        }

        public List<char> TopologicalSort()
        {
            HashSet<char> visited = [];
            Stack<char> resultStack = [];

            foreach (var node in adjList.Keys)
            {
                if (!visited.Contains(node))
                {
                    DFS(node, visited, resultStack);
                }
            }

            return resultStack.ToList(); // Rückgabe der topologisch sortierten Liste
        }

        private void DFS(char node, HashSet<char> visited, Stack<char> resultStack)
        {
            visited.Add(node);

            if (adjList.TryGetValue(node, out List<char>? value))
            {
                foreach (var neighbor in value)
                {
                    if (!visited.Contains(neighbor))
                    {
                        DFS(neighbor, visited, resultStack);
                    }
                }
            }

            resultStack.Push(node);
        }

        // debugging
        public void Anzeigen()
        {
            foreach (var knoten in adjList)
            {
                Console.Write(knoten.Key + " < ");

                foreach (var nachbar in knoten.Value)
                {
                    Console.Write(nachbar + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

