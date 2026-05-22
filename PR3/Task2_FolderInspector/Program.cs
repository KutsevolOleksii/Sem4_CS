using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = @"F:\Ynik\Sem4_CS\Sem4_CS\PR3";

        var files = Directory.GetFiles(path);
        var dirs = Directory.GetDirectories(path);

        Console.WriteLine("Folders:");
        foreach (var d in dirs)
            Console.WriteLine(d);

        Console.WriteLine("\nFiles:");
        foreach (var f in files)
        {
            FileInfo info = new FileInfo(f);
            Console.WriteLine($"{info.Name} | {info.Length} bytes | {info.CreationTime}");
        }
    }
}