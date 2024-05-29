using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Triangle
    {
        public static void draw(int c)
        {
            try
            {
                if (c <= 0)
                    throw new Exception($"Can't  draw side with length {c}");
                for (int l = 0; l <= c; l++)
                    Console.Write("* ");
                Console.WriteLine();
                int i;
                for (i = 1; i < c; i++)
                {
                    for (int k = 0; k < i; k++)
                        Console.Write(" ");
                    Console.Write("*");
                    for (int k = 0; k < 2*c-2*i-1; k++)
                        Console.Write(" ");
                    Console.Write("*");
                    for (int k = 0; k < i; k++)
                        Console.Write(" ");
                    Console.WriteLine();
                }
                for (int l = 0; l < i; l++)
                    Console.Write(" ");
                Console.WriteLine("*");
            }
            catch (Exception e) { Console.WriteLine(e.Message);  }
        }
    }
    public class Rectangle
    {
        public static void draw(int a,int b)
        {
            try
            {
                if (a <= 0 || b <= 0)
                    throw new Exception($"Can't  draw side with lengths {a} {b}");
                for (int i = 0; i < a; i++)
                    Console.Write("* ");
                Console.WriteLine();
                for (int i = 0; i < b; i++)
                {
                    Console.Write("*");
                    for(int j=1;j<a*2-2;j++)
                        Console.Write(" ");
                    Console.Write("*");
                    Console.WriteLine();
                }
                for (int i = 0; i < a; i++)
                    Console.Write("* ");
                Console.WriteLine();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
    public class Square
    {
        public static void draw(int a)
        {
            try
            {
                if (a <= 0)
                    throw new Exception($"Can't  draw side with lengths {a}");
                for (int i = 0; i < a; i++)
                    Console.Write("* ");
                Console.WriteLine();
                for (int i = 0; i < a-2; i++)
                {
                    Console.Write("*");
                    for (int j = 1; j < a * 2 - 2; j++)
                        Console.Write(" ");
                    Console.Write("*");
                    Console.WriteLine();
                }
                for (int i = 0; i < a; i++)
                    Console.Write("* ");
                Console.WriteLine();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
