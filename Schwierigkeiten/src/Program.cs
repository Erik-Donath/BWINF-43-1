using Schwierigkeiten.src;

string basePath = AppDomain.CurrentDomain.BaseDirectory;
string path = Path.Combine(basePath, @"../../../res/schwierigkeiten0.txt");
string[] lines = Parser.Parse(path);

Algorithm Aufgabe1 = new(lines);
Aufgabe1.createGraph();