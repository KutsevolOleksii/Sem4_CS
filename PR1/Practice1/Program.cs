using System;
using System.Collections.Generic;

namespace Practice1
{
    class Program
    {
        public delegate double MathOperation(double a, double b);

        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b) => a / b;

        public delegate void NotificationHandler(string message);

        static void SendEmail(string message) => Console.WriteLine($"Email sent: {message}");
        static void SendSMS(string message) => Console.WriteLine($"SMS sent: {message}");

        public delegate bool FilterPredicate(int number);

        static void FilterArray(int[] numbers, FilterPredicate predicate)
        {
            foreach (var n in numbers)
                if (predicate(n))
                    Console.WriteLine(n);
        }

        public class Logger
        {
            public Action<string>? LogHandler;

            public void Log(string message)
            {
                LogHandler?.Invoke(message);
            }
        }

        public delegate bool Validator(string input);

        static Validator GetValidator(int minLength)
        {
            return input => input.Length >= minLength;
        }

        static void Main()
        {
            MathOperation op;

            op = Add;
            Console.WriteLine(op(10, 5));

            op = Subtract;
            Console.WriteLine(op(10, 5));

            op = Multiply;
            Console.WriteLine(op(10, 5));

            op = Divide;
            Console.WriteLine(op(10, 5));

            NotificationHandler handler = SendEmail;
            handler += SendSMS;
            handler("Hello");

            int[] numbers = { 1,2,3,4,5,6,7,8,9,10 };

            Console.WriteLine("Even:");
            FilterArray(numbers, n => n % 2 == 0);

            Console.WriteLine("Greater than 5:");
            FilterArray(numbers, n => n > 5);

            Console.WriteLine("Odd:");
            FilterArray(numbers, n => n % 2 != 0);

            Func<double, double, double> func = Add;
            Console.WriteLine(func(2, 3));

            List<string> students = new List<string> { "Alex", "Anna", "Bob", "Andriy" };
            var filtered = students.FindAll(s => s.StartsWith("A"));

            foreach (var s in filtered)
                Console.WriteLine(s);

            Logger logger = new Logger();

            logger.LogHandler = msg => Console.WriteLine(msg);
            logger.Log("test");

            logger.LogHandler = msg => Console.WriteLine(msg.ToUpper());
            logger.Log("test");

            Validator passwordValidator = GetValidator(8);
            Validator loginValidator = GetValidator(3);

            Console.Write("Enter login: ");
            string login = Console.ReadLine()!;

            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;

            Console.WriteLine(loginValidator(login));
            Console.WriteLine(passwordValidator(password));
        }
    }
}