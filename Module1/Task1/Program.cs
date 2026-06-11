using System;
using System.IO;
using System.Collections.Generic;

namespace Task1
{
    public delegate string TextOperation(string text);

    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "textPD23.txt";
            string outputFile = "resultPD23.txt";

            if (!File.Exists(inputFile))
            {
                File.WriteAllLines(inputFile, new string[] {
                    "Hello world from C#",
                    "Programming with delegates is powerful",
                    "Visual Studio Code is simple and fast"
                });
                Console.WriteLine($"Створено тестовий файл {inputFile}, оскільки його не було.");
            }

            File.WriteAllText(outputFile, string.Empty);

            Console.WriteLine("Виконується операція 1: UPPERCASE...");
            ProcessFile(inputFile, outputFile, ToUpperCase);

            Console.WriteLine("Виконується операція 2: Кількість символів...");
            ProcessFile(inputFile, outputFile, CountCharacters);

            Console.WriteLine("Виконується операція 3: Кількість слів...");
            ProcessFile(inputFile, outputFile, CountWords);

            Console.WriteLine($"\nУсі операції виконано успішно! Перевірте файл: {outputFile}");
        }

        public static void ProcessFile(string inputPath, string outputPath, TextOperation operation)
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Помилка: Вхідний файл не знайдено!");
                return;
            }

            string[] lines = File.ReadAllLines(inputPath);
            List<string> processedLines = new List<string>();

            foreach (string line in lines)
            {
                processedLines.Add(operation(line));
            }

            File.AppendAllLines(outputPath, processedLines);
            
            File.AppendAllText(outputPath, Environment.NewLine); 
        }

        public static string ToUpperCase(string text)
        {
            return text.ToUpper();
        }

        public static string CountCharacters(string text)
        {
            return $"[Символів: {text.Length}] для рядка: \"{text}\"";
        }

        public static string CountWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return $"[Слів: {words.Length}] для рядка: \"{text}\"";
        }
    }
}
