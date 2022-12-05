using System;
using System.Collections.Generic;

namespace _12
{
    abstract class Currency
    {
        protected double amount;
        protected string name;
        public Currency(double amount, string name)
        {
            this.amount = amount;
            this.name = name;
        }

        // Функция перевода для перевода в рубли
        public virtual double Translation()
        {
            //Переопределение этой функции в производных классах.
            throw new NotImplementedException();
        }

        // Переопределение метода Equals
        public override bool Equals(object obj)
        {
            var currency = obj as Currency;
            return currency != null && amount == currency.amount && name == currency.name;
        }

        // Переопределение метода ToString
        public override string ToString()
        {
            return $"{name}: {amount}";
        }
    }

    class Dollar : Currency
    {
        // Конструктор
        public Dollar(double amount) : base(amount, "Dollar")
        {
            // проверка действительности значения
            if (amount <= 0)
                throw new ArgumentException("Invalid amount");
        }

        // Функция перевода в рубли
        public override double Translation()
        {
            return amount * 73.5;
        }

    }

    class Euro : Currency
    {
        // Конструктор
        public Euro(double amount) : base(amount, "Euro")
        {
            // проверка действительности значения
            if (amount <= 0)
                throw new ArgumentException("Invalid amount");
        }
        // Функция перевода в рубли
        public override double Translation()
        {
            return amount * 87.1;
        }
    }

    class Yuan : Currency
    {
        // Конструктор
        public Yuan(double amount) : base(amount, "Yuan")
        {
            // проверка действительности значения
            if (amount <= 0)
                throw new ArgumentException("Invalid amount");
        }
        // Функция перевода в рубли
        public override double Translation()
        {
            return amount * 10.5;
        }
    }

    class Program
    {
        // Список для хранения созданных объектов
        static List<Currency> currencies = new List<Currency>();
        static void Main(string[] args)
        {
            bool running = true;

            // Автоматическое создание трёх объектов каждого класса
            currencies.Add(new Dollar(10));
            currencies.Add(new Dollar(20));
            currencies.Add(new Dollar(33));
            currencies.Add(new Euro(330));
            currencies.Add(new Euro(130));
            currencies.Add(new Euro(105));
            currencies.Add(new Yuan(101));
            currencies.Add(new Yuan(5));
            currencies.Add(new Yuan(67));

            while (true)
            {
                Console.WriteLine("1. Использовать пересчет валюты");
                Console.WriteLine("2. Создание объекта валюты");
                Console.WriteLine("3. Отображение созданных объектов");
                Console.WriteLine("4. Удалить созданный объект");
                Console.WriteLine("5. Выход");

                Console.Write("Введите номер опции: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите сумму в валюте: ");
                        double amount = double.Parse(Console.ReadLine());
                        Console.Write("Введите тип валюты (Dollar, Euro, or Yuan): ");
                        string type = Console.ReadLine();
                        if (type == "Dollar")
                        {
                            var dollar = new Dollar(amount);
                            Console.WriteLine($"{amount} {type} это {dollar.Translation()} рублей");
                        }
                        else if (type == "Euro")
                        {
                            var euro = new Euro(amount);
                            Console.WriteLine($"{amount} {type} это {euro.Translation()} рублей");
                        }
                        else if (type == "Yuan")
                        {
                            var yuan = new Yuan(amount);
                            Console.WriteLine($"{amount} {type} это {yuan.Translation()} рублей");
                        }
                        else
                        {
                            Console.WriteLine("Неверный тип валюты");
                        }
                        break;
                    case 2:
                        Console.Write("Введите значение валюты: ");
                        double value = double.Parse(Console.ReadLine());

                        Console.Write("Введите тип валюты (Dollar, Euro, Yuan): ");
                        string type1 = Console.ReadLine();

                        if (type1 == "Dollar")
                        {
                            currencies.Add(new Dollar(value));
                        }
                        else if (type1 == "Euro")
                        {
                            currencies.Add(new Euro(value));
                        }
                        else if (type1 == "Yuan")
                        {
                            currencies.Add(new Yuan(value));
                        }
                        else
                        {
                            Console.WriteLine("Неверный тип валюты");
                        }
                        break;
                    case 3:
                        foreach (var currency in currencies)
                        {
                            Console.WriteLine(currency);
                        }
                        break;
                    case 4:
                        Console.Write("Введите индекс объекта для удаления: ");
                        int index = int.Parse(Console.ReadLine());

                        if (index < 0 || index >= currencies.Count)
                        {
                            Console.WriteLine("Неверный индекс");
                        }
                        else
                        {
                            currencies.RemoveAt(index);
                        }
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Неверная операция");
                        break;
                }
            }
        }
    }
}