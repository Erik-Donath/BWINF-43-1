using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schwierigkeiten.src
{
    internal class Algorithm
    {
        // Anzahl der Klausuren
        private readonly int n;
        // Gesamtanzahl an Aufgaben
        private readonly int m;
        // Anzahl an Aufgaben für welche eine gute Anordnung gefunden werden soll
        private readonly int k;
        // Liste aller Klausuren
        private readonly List<string> klausuren;
        // Aufgaben, für die eine gute Anordnung gefunden werden soll
        private readonly string aufgaben;
        
        
        public Algorithm(string[] lines)
        {
            string info = lines[0];
            n = (int)Char.GetNumericValue(info[0]);
            m = (int)Char.GetNumericValue(info[1]);
            k = (int)Char.GetNumericValue(info[2]);
            klausuren = [];
            for (int i = 1; i <= n; i++) 
            {
                klausuren.Add(lines[i]);
            }
            aufgaben = lines[lines.Length-1];
        }

        public void Solve()
        {
            Graph graph = CreateGraph();
            if (graph.ContainsCycle())
                graph.RemoveCycle();
            List<char> liste = graph.TopologicalSort();
            liste.ForEach(x => Console.Write($"{x} < "));
        }

        private Graph CreateGraph()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Graph graph = new();
            for (int i = 0; i < m; i++)
            {
                graph.AddNode(alphabet[i]);
            }
            foreach (string klausur in klausuren)
            {
                for (int i = 0; i < klausur.Length - 1; i++)
                {
                    graph.AddEdge(klausur[i], klausur[i+1]);
                }
            }
            return graph;
        }
    }
}
