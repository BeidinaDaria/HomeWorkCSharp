using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Task1;
using Task2;

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
                case 2: Task2();  break;
                case 3: Task3.Play p = new Task3.Play();
                    p.play();
                    break;
                case 4:  Task4(); break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }
        public static void Task1()
        {
            try
            {
                Console.WriteLine("Which generator do you want to use? 1.Odd; 2.Even; 3.Simple; 4.Fibonacci.");
                int task = int.Parse(Console.ReadLine());
                switch (task)
                {
                    case 1: Console.WriteLine(OddGenerator.gen()); break;
                    case 2: Console.WriteLine(EvenGenerator.gen()); break;
                    case 3: Console.WriteLine(SimpleGenerator.gen()); break;
                    case 4: Console.WriteLine(FibGenerator.gen()); break;
                    default: throw new ApplicationException("Uncorrect input");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void Task2()
        {
            try
            {
                Console.WriteLine("Which shape do you want to see? 1.Triangle; 2.Rectangle; 3.Square.");
                int task = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the length of the side: ");
                int len = int.Parse(Console.ReadLine());
                switch (task)
                {
                    case 1: Triangle.draw(len); break;
                    case 2: 
                        Console.WriteLine("Enter the length of second side: ");
                        int wid=int.Parse(Console.ReadLine());
                        Rectangle.draw(len, wid);
                        break;
                    case 3: Square.draw(len); break;
                    case 4: Console.WriteLine(FibGenerator.gen()); break;
                    default: throw new ApplicationException("Uncorrect input");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void Task4()
        {
            
            int vowels = 0;
            int consonants = 0;
            int maxWordLength = 0;
            Console.WriteLine("Enter the number of vowels:");
            vowels = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of consonants:");
            consonants = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the maximum word length:");
            maxWordLength = Int32.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            GeneratePseudoText(sb, vowels, consonants, maxWordLength);
            Console.WriteLine(sb.ToString());
        }

        static void GeneratePseudoText(StringBuilder sb, int vowels, int consonants, int maxWordLength)
        {
            Random rnd = new Random();
            while (sb.Length < 1000)
            {
                StringBuilder word = new StringBuilder();
                for (int i = 0; i < rnd.Next(1, maxWordLength + 1); i++)
                {
                    char c = Convert.ToChar((rnd.Next(100) < vowels * 10 ? 'a' : 'A') + (rnd.Next(100) < vowels * 10 ? 1 : 0));
                    if ((i > 0 && rnd.Next(100) < consonants * 10) || i == 0)
                        c = (char)(c + (rnd.Next(100) < consonants * 10 ? 1 : 0));
                    word.Append(c);
                }
                sb.Append(word).Append(' ');
            }
        }
    }
}