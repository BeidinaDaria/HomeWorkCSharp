using System;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int prev = -1;
            char c = ' ';
            var rand = new Random();
            Func<int>[] delegates = new Func<int>[2];
            delegates[0] = ()=> {
                int ind=rand.Next()%4;

                while(ind==prev) ind=rand.Next()%4;
                prev = ind;
                return ind;
            };
            delegates[1] = () => {
                int ind = rand.Next()/4 % 4;

                while (ind == prev) ind = rand.Next()/4 % 4;
                prev = ind;
                return ind;
            };

            Console.WriteLine("Введите количество строк:");
            int linesCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите символ:");
            c = Console.ReadLine().ToString()[0];

            int index = -1;
            for (int i = 0; i < linesCount; i++)
            {
                index = delegates[rand.Next() % 2]();
                for (int j = 0; j < 4; j++)
                {
                    if (index != j)
                        Console.Write(' ');
                    else Console.Write(c);
                }
                Console.WriteLine();
            }
        } 
    }
}