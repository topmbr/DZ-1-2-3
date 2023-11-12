using System;
using System.Diagnostics;
namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Добро пожаловать в игру 'Успел, не успел'!");
            Console.WriteLine("Нажмите любую клавишу, как увидите сигнал.");

            Random random = new Random();
            int delay = random.Next(1000, 5000); // Задержка для сигнала в миллисекундах
            System.Threading.Thread.Sleep(delay);

            Console.WriteLine("Сигнал!");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.ReadKey(); // Ждем, пока пользователь нажмет любую клавишу
            stopwatch.Stop();
            TimeSpan reactionTime = stopwatch.Elapsed;

            Console.WriteLine($"Ваше время реакции: {reactionTime.TotalMilliseconds} миллисекунд.");
            Thread.Sleep(2000);
        }
    }
}