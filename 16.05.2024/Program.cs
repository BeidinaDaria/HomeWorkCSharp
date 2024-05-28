using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter task number:");
            int taskNumber = int.Parse(Console.ReadLine());
            switch (taskNumber)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3:
                    Console.WriteLine("Введите номер паспорта: ");
                    string number = Console.ReadLine();
                    Console.WriteLine("Введите Ваше ФИО: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите дату выдачи в формате dd-mm-yyyy: ");
                    string date = Console.ReadLine();
                    ForeignID id = new ForeignID(number, name, date);
                    id.show();
                    break;
                case 4: Task4(); break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }

        static void Task1()
        {
            Console.WriteLine("Выберите направление перевода:");
            Console.WriteLine("1. Из десятичной в двоичную");
            Console.WriteLine("2. Из двоичной в десятичную");
            Console.WriteLine("3. Из восьмеричной в десятичную");
            Console.WriteLine("4. Из десятичной в восьмеричную");
            Console.WriteLine("5. Из шестнадцатеричной в десятичную");
            Console.WriteLine("6. Из десятичной в шестнадцатеричную");
            string input = Console.ReadLine();
            int direction;
            try
            {
                if (!int.TryParse(input, out direction))
                {
                    throw new ArgumentException("Неверный ввод.");
                }
                switch (direction)
                {
                    case 1:
                        ConvertDecimalToBinary();
                        break;
                    case 2:
                        ConvertBinaryToDecimal();
                        break;
                    case 3:
                        ConvertOctalToDecimal();
                        break;
                    case 4:
                        ConvertDecimalToOctal();
                        break;
                    case 5:
                        ConvertHexadecimalToDecimal();
                        break;
                    case 6:
                        ConvertDecimalToHexadecimal();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        }
        static void ConvertDecimalToBinary()
        {
            try
            {
                Console.Write("Введите десятичное число: ");
                string decimalNumber = Console.ReadLine();
                int number;
                if (!int.TryParse(decimalNumber, out number))
                {
                    throw new ArgumentException("Неверный ввод.");
                }
                string binaryNumber = Convert.ToString(number, 2).PadLeft(8, '0');
                Console.WriteLine($"Двоичное представление: {binaryNumber}");
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        }
        static void ConvertBinaryToDecimal()
        {
            try
            {
                Console.Write("Введите двоичное число: ");
                string binaryNumber = Console.ReadLine();
                int number;
                if (!int.TryParse(binaryNumber, out number))
                {
                    throw new ArgumentException("Неверный ввод.");
                }
                int decimalNumber = Convert.ToInt32(binaryNumber, 2);
                Console.WriteLine($"Десятичное представление: {decimalNumber}");
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        }
        static void ConvertOctalToDecimal()
        {
            try
            {
                Console.Write("Введите восьмеричное число: ");
                string octalNumber = Console.ReadLine();
                int number;
                if (!int.TryParse(octalNumber, out number))
                {
                    throw new ArgumentException("Неверный ввод.");
                }
                int decimalNumber = Convert.ToInt32(octalNumber, 8);
                Console.WriteLine($"Десятичное представление: {decimalNumber}");
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        }
        static void ConvertDecimalToOctal()
        {
            try
            {
                Console.Write("Введите десятичное число: ");
                string decimalNumber = Console.ReadLine();
                int number;
                if (!int.TryParse(decimalNumber, out number))
                {
                    throw new ArgumentException("Неверный ввод.");
                }
                string octalNumber = Convert.ToString(number, 8).PadLeft(8, '0');
                Console.WriteLine($"Восьмеричное представление: {octalNumber}");
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        }
        static void ConvertHexadecimalToDecimal()
        {
            try
            {
                Console.Write("Введите шестнадцатеричное число: ");
                string hexadecimalNumber = Console.ReadLine().ToLower();
                for (int i = 0; i < hexadecimalNumber.Length; i++)
                    if (!char.IsLetterOrDigit(hexadecimalNumber[i]))
                    {
                        throw new ArgumentException("Неверный ввод.");
                    }

                int decimalNumber = Convert.ToInt32(hexadecimalNumber, 16);
                Console.WriteLine($"Десятичное представление: {decimalNumber}");

            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        }
        static void ConvertDecimalToHexadecimal()
        {
            try
            {
                Console.Write("Введите десятичное число: ");
                string decimalNumber = Console.ReadLine();
                int number;
                if (!int.TryParse(decimalNumber, out number))
                {
                    throw new ArgumentException("Неверный ввод.");
                }

                string hexadecimalNumber = Convert.ToString(number, 16).PadLeft(16, '0');
                Console.WriteLine($"Шестнадцатеричное представление: {hexadecimalNumber}");
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        }

        static void Task2()
        {
            try
            {
                Console.WriteLine("Выберите цифру:");
                string input = Console.ReadKey().Key.ToString();
                int direction;
                if (input.Length != 2)
                {
                    throw new IndexOutOfRangeException(input);
                }
                if (!int.TryParse(input[1].ToString(), out direction))
                {
                    throw new ArgumentException("Неверный ввод.");
                }
                Console.WriteLine();

                switch (direction)
                {
                    case 1:
                        Console.WriteLine("one");
                        break;
                    case 2:
                        Console.WriteLine("two");
                        break;
                    case 3:
                        Console.WriteLine("three");
                        break;
                    case 4:
                        Console.WriteLine("four");
                        break;
                    case 5:
                        Console.WriteLine("five");
                        break;
                    case 6:
                        Console.WriteLine("six");
                        break;
                    case 7:
                        Console.WriteLine("seven");
                        break;
                    case 8:
                        Console.WriteLine("eight");
                        break;
                    case 9:
                        Console.WriteLine("nine");
                        break;
                    case 0:
                        Console.WriteLine("zero");
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
            }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            catch (IndexOutOfRangeException ex) { Console.WriteLine(ex.Message); }
        }

        class ForeignID
        {
            private string? number { get; }
            private string? name { get; }
            private DateOnly? date { get; }
            public ForeignID(string number, string name, string date)
            {
                try
                {
                    for (int i = 0; i < number.Length; i++)
                        if (!char.IsDigit(number[i]) && number[i] != ' ')
                        {
                            throw new ArgumentException("Неверный ввод номера.");
                        }
                    for (int i = 0; i < name.Length; i++)
                        if (!char.IsLetter(name[i]) && name[i] != ' ')
                        {
                            throw new ArgumentException("Неверный ввод ФИО.");
                        }
                    Regex regex = new Regex(@"^\d{2}-\d{2}-\d{4}$");
                    MatchCollection matches = regex.Matches(date);
                    if (matches.Count > 0)
                    {
                        this.date = DateOnly.Parse(matches[0].Value);
                        this.number = number;
                        this.name = name;
                    }
                    else
                    {
                        throw new ArgumentException("Неверный ввод даты.");
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            public void show()
            {
                Console.WriteLine($"Гражданин {name} имеет паспорт номер {number}, выданный {date}");
            }
        }

        static void Task4()
        {
            try
            {
                Console.WriteLine("Введите логическое выражение вида number operation(<, >, <=, >=, ==, !=) number");
                string expression = Console.ReadLine();
                Regex regex = new Regex(@"(\d+?) ([<, >, <=, >=, ==, !=]+) (\d+?)");
                MatchCollection matches = regex.Matches(expression);
                if (matches.Count > 0)
                {
                    string[] strs = expression.Split(' ');
                    switch (strs[1])
                    {
                        case "<":
                            Console.WriteLine($"Result: {int.Parse(strs[0]) < int.Parse(strs[2])}");
                            break;
                        case ">":
                            Console.WriteLine($"Result: {int.Parse(strs[0]) > int.Parse(strs[2])}");
                            break;
                        case "<=":
                            Console.WriteLine($"Result: {int.Parse(strs[0]) <= int.Parse(strs[2])}");
                            break;
                        case ">=":
                            Console.WriteLine($"Result: {int.Parse(strs[0]) >= int.Parse(strs[2])}");
                            break;
                        case "==":
                            Console.WriteLine($"Result: {int.Parse(strs[0]) == int.Parse(strs[2])}");
                            break;
                        case "!=":
                            Console.WriteLine($"Result: {int.Parse(strs[0]) != int.Parse(strs[2])}");
                            break;
                        default: break;
                    }
                }
                else throw new ArgumentException("Некорректный ввод");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
    }
}