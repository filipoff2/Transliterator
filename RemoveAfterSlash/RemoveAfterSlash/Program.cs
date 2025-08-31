using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "ru.dic";
        string outputFile = "output.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Read all lines using UTF-8
        var lines = File.ReadAllLines(inputFile, Encoding.UTF8);

        // Write output using UTF-8
        using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8))
        {
            for (int i = 1; i < lines.Length; i++) // Skip the first line
            {
                string line = lines[i];
                int slashIndex = line.IndexOf('/');
                string word = (slashIndex >= 0 ? line.Substring(0, slashIndex) : line).Trim();

                if (!string.IsNullOrWhiteSpace(word))
                {
                    writer.WriteLine(word);
                }
            }
        }

        Console.WriteLine("Words extracted and saved to output.txt (UTF-8)");
    }
}