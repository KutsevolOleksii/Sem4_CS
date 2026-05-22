using System;
using System.IO;

class Program
{
    static int count = 0;
    static long total = 0;

    static void Main()
    {
        string path = @"C:\Test"; // ← ОБОВʼЯЗКОВО

        var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            FileInfo info = new FileInfo(file);
            total += info.Length;
            info.Delete();
            count++;
        }

        Console.WriteLine($"Deleted: {count}");
        Console.WriteLine($"Freed: {total} bytes");
    }

    static void CleanRecursive(string path)
    {
        foreach (var file in Directory.GetFiles(path))
        {
            FileInfo info = new FileInfo(file);
            total += info.Length;
            info.Delete();
            count++;
        }

        foreach (var dir in Directory.GetDirectories(path))
        {
            CleanRecursive(dir);
        }
    }
}