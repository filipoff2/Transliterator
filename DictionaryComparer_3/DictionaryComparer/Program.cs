using System;
using System.Collections.Generic;
using System.IO;

class Program
{

    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: DictionaryComparer <file1.txt> <file2.txt> <output.txt>");
            return;
        }

        string file1Path = args[0];
        string file2Path = args[1];
        string outputPath = args[2];

        if (!File.Exists(file1Path) || !File.Exists(file2Path))
        {
            Console.WriteLine("One or both input files do not exist.");
            return;
        }

        var words1 = new HashSet<string>(File.ReadAllLines(file1Path));
        var words2 = new HashSet<string>(File.ReadAllLines(file2Path));

        words1.IntersectWith(words2);

        File.WriteAllLines(outputPath, words1);

        Console.WriteLine($"Common words written to {outputPath}");
    }
}