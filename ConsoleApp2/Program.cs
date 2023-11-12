using System;
using System.IO;
using System.Threading;
namespace ConsoleApp2
{
    class Bank
    {
        private int _money;
        private string _name ;
        private int _percent;
        private readonly object _lock = new object();

        public int Money
        {
            get => _money;
            set
            {
                lock (_lock)
                {
                    if (_money != value)
                    {
                        _money = value;
                        ThreadPool.QueueUserWorkItem(WriteToFile);
                    }
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                lock (_lock)
                {
                    if (_name != value)
                    {
                        _name = value;
                        ThreadPool.QueueUserWorkItem(WriteToFile);
                    }
                }
            }
        }

        public int Percent
        {
            get => _percent;
            set
            {
                lock (_lock)
                {
                    if (_percent != value)
                    {
                        _percent = value;
                        ThreadPool.QueueUserWorkItem(WriteToFile);
                    }
                }
            }
        }

        private void WriteToFile(object state)
        {
            lock (_lock)
            {
                string data = $"Name: {_name}, Money: {_money}, Percent: {_percent}%";
                string filePath = "bank_log.txt";

                try
                {
                    using (StreamWriter writer = File.AppendText(filePath))
                    {
                        writer.WriteLine($"{DateTime.Now}: {data}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to write to file: {e.Message}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.Name = "MyBank";
            bank.Money = 10000;
            bank.Percent = 5;

            // Меняем значения
            bank.Money = 15000;
            bank.Percent = 6;

            // Добавляем задержку для записи в файл
            Thread.Sleep(2000);

            // Чтение лога банка
            Console.WriteLine("Bank log:");
            string logFile = "bank_log.txt";
            if (File.Exists(logFile))
            {
                string[] lines = File.ReadAllLines(logFile);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Log file not found or empty.");
            }
        }
    }

}