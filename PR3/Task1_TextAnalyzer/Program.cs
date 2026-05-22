using System;
using System.IO;

class Program
{
    static void Main()
    {
        int lines = 0;
        int words = 0;
        int chars = 0;

        using (StreamReader sr = new StreamReader("story.txt"))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                lines++;
                words += line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                chars += line.Length;
            }
        }

        using (StreamWriter sw = new StreamWriter("report.txt"))
        {
            sw.WriteLine($"Lines: {lines}");
            sw.WriteLine($"Words: {words}");
            sw.WriteLine($"Chars: {chars}");
        }

        Console.WriteLine("Done");
    }
}