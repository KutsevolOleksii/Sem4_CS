using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5(args);
    }

    static void Task1()
    {
        string path = "story.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Hello world\nThis is a test file");
        }

        int lines = 0;
        int words = 0;
        int chars = 0;

        using (StreamReader sr = new StreamReader(path))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                lines++;
                words += line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                chars += line.Length;
            }
        }

        string report = $"Lines: {lines}\nWords: {words}\nChars: {chars}";
        File.WriteAllText("report.txt", report);

        Console.WriteLine("Task1 done");
    }

    static void Task2()
    {
        string path = Directory.GetCurrentDirectory();

        Console.WriteLine("\nFolders:");
        foreach (var dir in Directory.GetDirectories(path))
        {
            Console.WriteLine(dir);
        }

        Console.WriteLine("\nFiles:");
        foreach (var file in Directory.GetFiles(path))
        {
            FileInfo info = new FileInfo(file);
            Console.WriteLine($"{info.Name} | {info.Length} bytes | {info.CreationTime}");
        }
    }

    static void Task3()
    {
        string path = Directory.GetCurrentDirectory();

        var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

        string largestFile = "";
        long maxSize = 0;

        foreach (var file in files)
        {
            FileInfo info = new FileInfo(file);
            if (info.Length > maxSize)
            {
                maxSize = info.Length;
                largestFile = file;
            }
        }

        Console.WriteLine("\nTask3 done");
        Console.WriteLine($"Name: {Path.GetFileName(largestFile)}");
        Console.WriteLine($"Size: {maxSize}");
        Console.WriteLine($"Path: {largestFile}");
    }

    static void Task4()
    {
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() },
            WriteIndented = true
        };

        if (!File.Exists("order.json"))
        {
            var order = new Order
            {
                Id = 1,
                Status = OrderStatus.Completed
            };

            var json = JsonSerializer.Serialize(order, options);
            File.WriteAllText("order.json", json);
        }

        try
        {
            var read = File.ReadAllText("order.json");
            var obj = JsonSerializer.Deserialize<Order>(read, options);

            Console.WriteLine($"\nTask4: {obj!.Status}");
        }
        catch
        {
            File.Delete("order.json");
            Console.WriteLine("\nTask4: JSON error, file reset");
        }
    }

    static void Task5(string[] args)
    {
        string path = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();

        var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        var dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

        long totalSize = files.Sum(f => new FileInfo(f).Length);

        string largestFile = "";
        long maxSize = 0;

        foreach (var file in files)
        {
            FileInfo info = new FileInfo(file);
            if (info.Length > maxSize)
            {
                maxSize = info.Length;
                largestFile = file;
            }
        }

        Console.WriteLine("\nTask5:");
        Console.WriteLine($"Folders: {dirs.Length}");
        Console.WriteLine($"Files: {files.Length}");
        Console.WriteLine($"Total size: {totalSize / 1024.0 / 1024.0:F2} MB");
        Console.WriteLine($"Largest file: {Path.GetFileName(largestFile)}");
    }
}

class Order
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}

enum OrderStatus
{
    New,
    Processing,
    Completed
}