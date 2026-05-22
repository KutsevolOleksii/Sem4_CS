using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string path = args.Length > 0 ? args[0] : @"F:\Ynik\Sem4_CS\Sem4_CS\PR3\Task4_CacheCleaner";

        var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        var dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

        long totalSize = files.Sum(f => new FileInfo(f).Length);

        var largest = files
            .Select(f => new FileInfo(f))
            .OrderByDescending(f => f.Length)
            .First();

        Console.WriteLine($"Folders: {dirs.Length}");
        Console.WriteLine($"Files: {files.Length}");
        Console.WriteLine($"Total size: {totalSize / (1024 * 1024)} MB");
        Console.WriteLine($"Largest file: {largest.Name}");
    }
}