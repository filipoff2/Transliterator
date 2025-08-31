using System;
using System.IO;

namespace TransliteratorCli
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: TransliteratorCli <input.txt> <output.txt>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            string inputText = File.ReadAllText(inputPath);
            var engine = new TransliteratorApp.TransliterationEngine();
            string outputText = engine.ToCyrillic(inputText);
            File.WriteAllText(outputPath, outputText);

            Console.WriteLine($"Transliteration complete. Output saved to: {outputPath}");
        }
    }
}