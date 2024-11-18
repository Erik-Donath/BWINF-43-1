using Schwierigkeiten.src;

string basePath = AppContext.BaseDirectory;
string path = Path.Combine(basePath, @"res");
string[] cases = Directory.GetFiles(path, "*.txt");


new Algorithm(Parser.Parse(cases[0])).Solve();

new Algorithm(Parser.Parse(cases[1])).Solve();

new Algorithm(Parser.Parse(cases[2])).Solve();

new Algorithm(Parser.Parse(cases[3])).Solve();

new Algorithm(Parser.Parse(cases[4])).Solve();

new Algorithm(Parser.Parse(cases[5])).Solve();
Console.ReadKey();
