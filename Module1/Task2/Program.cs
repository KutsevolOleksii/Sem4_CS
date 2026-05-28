using System;
using System.IO;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger("logPD23.txt");

            publisher.MessageSent += logger.OnMessageReceived;

            Console.WriteLine("=== Програма логування повідомлень ===");
            Console.WriteLine("Введіть текст у консоль 4 рази:");

            for (int i = 1; i <= 4; i++)
            {
                Console.Write($"Рядок {i}: ");
                string userInput = Console.ReadLine() ?? string.Empty;
                publisher.Send(userInput);
            }

            Console.WriteLine("\nВведення завершено! Перевірте лог-файл: logPD23.txt");
        }
    }

    public class MessagePublisher
    {
        public event Action<string>? MessageSent;

        public void Send(string message)
        {
            MessageSent?.Invoke(message);
        }
    }

    public class FileLogger
    {
        private readonly string _logFilePath;

        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void OnMessageReceived(string message)
        {
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logLine = $"[{currentTime}] {message}";

            File.AppendAllText(_logFilePath, logLine + Environment.NewLine, Encoding.UTF8);
        }
    }
}