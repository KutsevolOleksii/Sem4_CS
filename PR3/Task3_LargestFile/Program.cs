using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string path = @"F:\Ynik\Sem4_CS\Sem4_CS\PR3";

        var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

        var largest = files
            .Select(f => new FileInfo(f))
            .OrderByDescending(f => f.Length)
            .First();

        Console.WriteLine($"Name: {largest.Name}");
        Console.WriteLine($"Size: {largest.Length}");
        Console.WriteLine($"Path: {largest.FullName}");
    }
}