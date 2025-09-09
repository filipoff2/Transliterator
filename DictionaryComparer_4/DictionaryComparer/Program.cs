using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        Console.WriteLine("Loading words from files...");
        var words1 = new HashSet<string>(File.ReadAllLines(file1Path));
        var words2 = new HashSet<string>(File.ReadAllLines(file2Path));
        
        Console.WriteLine($"File 1: {words1.Count} words");
        Console.WriteLine($"File 2: {words2.Count} words");

        // For very large files, limit the number of results to prevent excessive output
        const int maxResults = 100000;
        var similarWords = new List<string>();
        
        Console.WriteLine("Building character-based index for optimization...");
        var words2ByLength = words2.GroupBy(w => w.Length).ToDictionary(g => g.Key, g => g.ToList());
        
        int processed = 0;
        int total = words1.Count;
        var startTime = DateTime.Now;
        
        Console.WriteLine("Finding similar words...");
        Console.WriteLine($"Note: Results will be limited to {maxResults:N0} pairs to prevent excessive output.");
        
        foreach (var word1 in words1)
        {
            processed++;
            if (processed % 5000 == 0)
            {
                var elapsed = DateTime.Now - startTime;
                var rate = processed / elapsed.TotalSeconds;
                var eta = TimeSpan.FromSeconds((total - processed) / rate);
                Console.WriteLine($"Processed {processed:N0}/{total:N0} words ({processed * 100.0 / total:F1}%) - Rate: {rate:F0} words/sec - ETA: {eta:hh\\:mm\\:ss}");
            }
            
            // Stop if we've found enough results
            if (similarWords.Count >= maxResults)
            {
                Console.WriteLine($"Reached maximum results limit ({maxResults:N0}). Stopping early.");
                break;
            }
            
            // Only compare with words of similar length (±3 characters)
            for (int len = Math.Max(1, word1.Length - 3); len <= word1.Length + 3; len++)
            {
                if (words2ByLength.TryGetValue(len, out var candidates))
                {
                    foreach (var word2 in candidates)
                    {
                        // Quick character difference check before expensive Levenshtein
                        if (QuickCharacterDiff(word1, word2) > 3)
                            continue;
                        
                        // For same-length words, use faster character-by-character check
                        if (word1.Length == word2.Length)
                        {
                            if (!QuickSimilarityCheck(word1, word2))
                                continue;
                        }
                            
                        int distance = LevenshteinDistance(word1, word2);
                        if (distance >= 1 && distance <= 3)
                        {
                            similarWords.Add($"{word1} ~ {word2} (diff: {distance})");
                            
                            // Stop if we've found enough results
                            if (similarWords.Count >= maxResults)
                                break;
                        }
                    }
                    
                    // Break outer loop if we've reached the limit
                    if (similarWords.Count >= maxResults)
                        break;
                }
            }
        }

        Console.WriteLine($"Found {similarWords.Count} similar word pairs");
        File.WriteAllLines(outputPath, similarWords);
        Console.WriteLine($"Similar words written to {outputPath}");
    }

    // Fast character difference check - returns minimum possible Levenshtein distance
    static int QuickCharacterDiff(string s, string t)
    {
        return Math.Abs(s.Length - t.Length);
    }
    
    // More sophisticated pre-filter using character frequency
    static bool QuickSimilarityCheck(string s, string t)
    {
        if (s.Length != t.Length) return false;
        
        int differences = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != t[i])
            {
                differences++;
                if (differences > 3) return false;
            }
        }
        return differences <= 3;
    }

    static int LevenshteinDistance(string s, string t)
    {
        // Early exit for identical strings
        if (s == t) return 0;
        
        // Early exit for length differences > 3
        if (Math.Abs(s.Length - t.Length) > 3) return int.MaxValue;
        
        int[,] d = new int[s.Length + 1, t.Length + 1];

        for (int i = 0; i <= s.Length; i++)
            d[i, 0] = i;
        for (int j = 0; j <= t.Length; j++)
            d[0, j] = j;

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 1; j <= t.Length; j++)
            {
                int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                d[i, j] = Math.Min(
                    Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                    d[i - 1, j - 1] + cost);
            }
        }

        return d[s.Length, t.Length];
    }
}