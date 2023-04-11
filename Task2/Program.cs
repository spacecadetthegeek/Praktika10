using System;

namespace CalculatorWithLogger
{
    public interface ICalculator
    {
        int Sum(int a, int b);
    }

    public class Calculator : ICalculator
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Event: " + message);
            Console.ResetColor();
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + message);
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new Calculator();
            ILogger logger = new Logger();

            while (true)
            {
                Console.WriteLine("Введите 1 число:");
                string input1 = Console.ReadLine();
                int a;

                Console.WriteLine("Введите 2 число:");
                string input2 = Console.ReadLine();
                int b;

                try
                {
                    a = int.Parse(input1);
                    b = int.Parse(input2);
                }
                catch (FormatException)
                {
                    logger.Error("Ошибка");
                    continue;
                }

                int sum = calculator.Sum(a, b);
                Console.WriteLine("Результат: " + sum);
                logger.Event("Сумма " + a + " и " + b + " равна " + sum);
            }
        }
    }
}