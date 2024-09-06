using Schwierigkeiten.src;

string basePath = AppDomain.CurrentDomain.BaseDirectory;
string path = Path.Combine(basePath, @"../../../res/");
string[] cases = Directory.GetFiles(path, "*.txt");

Algorithm schwierigkeiten0 = new(Parser.Parse(cases[0]));
schwierigkeiten0.Solve();

Console.WriteLine();

Algorithm schwierigkeiten1 = new(Parser.Parse(cases[1]));
schwierigkeiten1.Solve();