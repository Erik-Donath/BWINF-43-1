using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schwierigkeiten.src
{
    internal class Algorithm
    {
        /*
         * 0 = Anzahl der Klausuren
         * 1 = Gesamtanzahl an Aufgaben
         * 2 = Anzahl an Aufgaben für welche eine gute Anordnung gefunden werden soll
         */
        private readonly int[] info;
        // Liste aller Klausuren
        private readonly List<string> klausuren;
        // Aufgaben, für die eine gute Anordnung gefunden werden soll
        private readonly string aufgaben;
        
        
        public Algorithm(string[] lines)
        {
            string infoLine = lines[0];
            info = infoLine
                .Split(new[] { ' ' })
                .Select(int.Parse)
                .ToArray();
            klausuren = [];
            for (int i = 1; i <= info[0]; i++) 
            {
                klausuren.Add(removeClutter(lines[i]));
            }
            aufgaben = removeClutter(lines[lines.Length - 1]);
        }

        private string removeClutter(string line)
        {
            string newLine = line;
            newLine = newLine.Replace(" ", "");
            newLine = newLine.Replace("<", "");
            return newLine;
        }

        public void Solve()
        {
            Graph graph = CreateGraph();
            graph.RemoveCycle();
            List<char> liste = graph.TopologicalSort();
            //liste.ForEach(x => Console.Write($"{x} <"));
            string ergebnis = "";
            for (int i = 0; i < liste.Count; i++) 
            {
                for (int j = 0; j < info[2]; j++)
                {
                    if (aufgaben[j] == liste[i])
                    {
                        ergebnis += liste[i];
                        break;
                    }
                }
            }
            Console.WriteLine(ergebnis + "\n");
        }

        private Graph CreateGraph()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Graph graph = new();
            for (int i = 0; i < info[1]; i++)
            {
                graph.AddNode(alphabet[i]);
                //Console.WriteLine(alphabet[i]+ " :node created");
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
