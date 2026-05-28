using System;
using System.IO;
using System.Collections.Generic;

namespace Task1
{
    // 1. Створюємо делегат TextOperation для операцій над текстом
    public delegate string TextOperation(string text);

    class Program
    {
        static void Main(string[] args)
        {
            // Шляхи до файлів (число 3 підставлено замість PD2X)
            string inputFile = "textPD23.txt";
            string outputFile = "resultPD23.txt";

            // Перевірка: якщо вхідного файлу немає, створимо його з тестовим текстом
            if (!File.Exists(inputFile))
            {
                File.WriteAllLines(inputFile, new string[] {
                    "Hello world from C#",
                    "Programming with delegates is powerful",
                    "Visual Studio Code is simple and fast"
                });
                Console.WriteLine($"Створено тестовий файл {inputFile}, оскільки його не було.");
            }

            // Очищаємо результуючий файл перед початком роботи програми
            File.WriteAllText(outputFile, string.Empty);

            // 3. Викликаємо метод ProcessFile 3 рази з різними операціями
            Console.WriteLine("Виконується операція 1: UPPERCASE...");
            ProcessFile(inputFile, outputFile, ToUpperCase);

            Console.WriteLine("Виконується операція 2: Кількість символів...");
            ProcessFile(inputFile, outputFile, CountCharacters);

            Console.WriteLine("Виконується операція 3: Кількість слів...");
            ProcessFile(inputFile, outputFile, CountWords);

            Console.WriteLine($"\nУсі операції виконано успішно! Перевірте файл: {outputFile}");
        }

        // 2. Написання методу ProcessFile за умовою завдання
        public static void ProcessFile(string inputPath, string outputPath, TextOperation operation)
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Помилка: Вхідний файл не знайдено!");
                return;
            }

            // Читаємо весь текст з файлу (построково)
            string[] lines = File.ReadAllLines(inputPath);
            List<string> processedLines = new List<string>();

            // Виконуємо над кожним рядком передану операцію
            foreach (string line in lines)
            {
                processedLines.Add(operation(line));
            }

            // Дописуємо (Append) результат у результуючий файл
            File.AppendAllLines(outputPath, processedLines);
            
            // Додаємо пустий рядок-розділювач між блоками різних операцій для краси
            File.AppendAllText(outputPath, Environment.NewLine); 
        }

        // --- Реалізація 3-х операцій відповідно до умов завдання ---

        // Операція 1: перевести рядок у UPPERCASE
        public static string ToUpperCase(string text)
        {
            return text.ToUpper();
        }

        // Операція 2: порахувати кількість символів в рядку
        public static string CountCharacters(string text)
        {
            return $"[Символів: {text.Length}] для рядка: \"{text}\"";
        }

        // Операція 3: порахувати кількість слів в рядку
        public static string CountWords(string text)
        {
            // Розбиваємо рядок за пробілами, видаляючи пусті елементи
            string[] words = text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return $"[Слів: {words.Length}] для рядка: \"{text}\"";
        }
    }
}