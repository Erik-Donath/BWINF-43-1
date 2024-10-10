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

        public void RemoveCycle()
        {
            // Suche nach einem Zyklus und entferne eine Kante, die keine Brücke ist
            foreach (var node in adjList.Keys)
            {
                var visited = new HashSet<char>();
                var stack = new Stack<char>();
                var resultStack = new Stack<char>();

                if (FindCycle(node, '\0', visited, stack))
                {
                    var cycleNodes = stack.ToList();

                    for (int i = 0; i < cycleNodes.Count - 1; i++)
                    {
                        char u = cycleNodes[i];
                        char v = cycleNodes[i + 1];

                        // Überprüfen, ob (u, v) eine Brücke ist
                        if (!IsBridge(u, v, [], resultStack))
                        {
                            adjList[u].Remove(v);
                            adjList[v].Remove(u);
                            return;
                        }
                    }
                }
            }
        }

        // Hilfsfunktion zur Zyklenerkennung mit DFS
        private bool FindCycle(char current, char parent, HashSet<char> visited, Stack<char> stack)
        {
            visited.Add(current);
            stack.Push(current);

            foreach (var neighbor in adjList[current])
            {
                if (neighbor == parent)
                    continue;

                if (visited.Contains(neighbor))
                {
                    stack.Push(neighbor);
                    return true;
                }

                if (FindCycle(neighbor, current, visited, stack))
                {
                    return true;
                }
            }

            stack.Pop();
            return false;
        }

        // Funktion zur Überprüfung, ob eine Kante eine Brücke ist
        private bool IsBridge(char u, char v, HashSet<char> visited, Stack<char> resultStack)
        {
            // Entferne die Kante temporär
            adjList[u].Remove(v);
            adjList[v].Remove(u);

            // Überprüfen, ob u und v noch im selben Teil des Graphen sind
            DFS(u, visited, resultStack);

            // Füge die Kante wieder hinzu
            adjList[u].Add(v);
            adjList[v].Add(u);

            // Überprüfen, ob beide Knoten noch in derselben Komponente sind
            return !visited.Contains(v);
        }

        // DFS-Funktion zur Überprüfung der Erreichbarkeit oder für topologischen Sort
        private void DFS(char node, HashSet<char> visited, Stack<char> resultStack)
        {
            visited.Add(node);

            foreach (var neighbor in adjList[node])
            {
                if (!visited.Contains(neighbor))
                {
                    DFS(neighbor, visited, resultStack);
                }
            }

            // Fügt den Knoten dem resultStack hinzu, um später den topologischen Sort zu haben
            resultStack.Push(node);
        }

    }
}

