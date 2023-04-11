using System;

class Calculate
{
    static void Main(string[] args)
    {
        int a = 0, b = 0, result = 0;

        ISum operation = new Addition();

        try
        {
            Reader(out a, out b);
            result = operation.Sum(a, b);

            Console.WriteLine($"Результат: {a} + {b} = {result}");
        }

        catch (FormatException)
        {
            Console.WriteLine("Введено неверное значение!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: ", ex.Message);
        }

    }

    static public void Reader(out int a, out int b)
    {
        Console.WriteLine("Введите a: ");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите b: ");
        b = Convert.ToInt32(Console.ReadLine());
    }
}

public interface ISum
{
    public int Sum(int a, int b);
}

class Addition : ISum
{
    public int Sum(int a, int b)
    {
        return a + b;
    }
}

