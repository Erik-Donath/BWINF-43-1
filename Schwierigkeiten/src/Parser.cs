using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schwierigkeiten.src
{
    internal static class Parser
    {
        public static string[] Parse(string path)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].Replace(" ", "");
                    lines[i] = lines[i].Replace("<", "");
                }
                return lines;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return new string[0];
            }
        }
    }
}
