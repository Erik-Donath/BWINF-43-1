using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schwierigkeiten.src
{
    internal class Graph
    {
        private Dictionary<char, List<char>> adjazenzListe;

        public Graph()
        {
            adjazenzListe = [];
        }

        public void AddNode(char node)
        {
            if (!adjazenzListe.ContainsKey(node))
            {
                adjazenzListe[node] = [];
            }
        }

        public void AddEdge(char from, char to)
        {
            if (!adjazenzListe[from].Contains(to))
                adjazenzListe[from].Add(to);
        }

        public void Anzeigen()
        {
            foreach (var knoten in adjazenzListe)
            {
                Console.Write(knoten.Key + " -> ");

                foreach (var nachbar in knoten.Value)
                {
                    Console.Write(nachbar + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

