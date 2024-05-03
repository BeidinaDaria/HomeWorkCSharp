using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace LessonTasks
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter task number:");
            int taskNumber = int.Parse(Console.ReadLine());
            switch (taskNumber)
            {
                case 1: SolveTask1(); break;
                case 2: SolveTask2(args); break;
                case 3: SolveTask3(); break;
                case 4: SolveTask4(); break;
                case 5: SolveTask5(); break;
                case 6: SolveTask6(); break;
                case 7: SolveTask7(); break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }

        private static void SolveTask1()
        {
            var A = new int[5];
            var B = new double[3, 4];

            var setA = new HashSet<int>();
            Console.WriteLine("Enter 5 values for array:");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
                setA.Add(A[i]);
            }
            int max = A.Max();
            int min = A.Min();
            var setB = new HashSet<double>();
            Random random = new Random();
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = random.Next(min, max) + random.NextDouble();
                    setB.Add(B[i, j]);
                }

            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            var copySetA = setA;
            var copySetB = setB;
            while ((setA.Count() != 0) && (setB.Count() != 0) && (setA.Max() != setB.Max()))
            {
                if (setA.Max() > setB.Max())
                    setA.Remove(setA.Max());
                else setB.Remove(setB.Max());
            }
            if ((setA.Count() != 0) && (setB.Count() != 0))
            {
                Console.WriteLine($"Max: {setA.Max()}");
            }
            else Console.WriteLine("No common max");

            while ((copySetA.Count() != 0) && (copySetB.Count() != 0) && (copySetA.Min() != copySetB.Min()))
            {
                if (copySetA.Min() < copySetB.Min())
                    copySetA.Remove(copySetA.Min());
                else copySetB.Remove(copySetB.Min());
            }
            if ((copySetA.Count() != 0) && (copySetB.Count() != 0))
            {
                Console.WriteLine($"Min: {setA.Min()}");
            }
            else Console.WriteLine("No common min");

            double sum = 0;
            double mult = 1;
            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i];
                mult *= A[i];
            }
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    sum += B[i, j];
                    mult *= B[i, j];
                }
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Multiply: {mult}");

            int sumA = 0;
            sum = 0;
            for (int i = 1; i < A.Length; i += 2)
            {
                sumA += A[i];
            }
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j += 2)
                {
                    sum += B[i,j];
                }
            Console.WriteLine($"Sum of even elements A: {sumA}");
            Console.WriteLine($"Sum of odd columns B: {sum}");
        }

        private static void SolveTask2(string[] args)
        {
            var B = new int[5, 5];

            Random random = new Random();
            int min = 101, minI = 0, minJ = 0;
            int max = -101, maxI = 0, maxJ = 0;
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = random.Next(-100,100);
                    if (B[i, j] > max)
                    {
                        max = B[i, j];
                        maxI = i;
                        maxJ = j;
                    }
                    if (B[i, j] < min)
                    {
                        min = B[i, j];
                        minI = i;
                        minJ = j;
                    }
                }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            int sum = 0;
            if (minI == maxI)
                for (int i = (maxJ < minJ) ? maxJ + 1 : minJ + 1; i < ((maxJ > minJ) ? maxJ : minJ); i++)
                    sum += B[maxI, i];
            else
            {
                if (maxI < minI)
                {
                    for (int i=maxJ+1;i<B.GetLength(1);i++)
                        sum += B[maxI, i];
                    for (int i = 0; i < minJ; i++)
                        sum += B[minI, i];
                }
                else
                {
                    for (int i = minJ + 1; i < B.GetLength(1); i++)
                        sum += B[minI, i];
                    for (int i = 0; i < maxJ; i++)
                        sum += B[maxI, i];
                    for (int i = (maxI < minI) ? maxI + 1 : minI + 1; i < ((maxI > minI) ? maxI : minI); i++)
                        for (int j = 0; j < B.GetLength(1); j++)
                            sum += B[i, j];
                }
            }
            Console.WriteLine($"Sum = {sum}");

        }

        private static void Encrypt(string str, int shift)
        {
            StringBuilder st=new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    if (str[i] + shift > 'Z')
                        st.Append((char)(('A'-1) + shift - ('Z' - str[i])));
                    else if (str[i] + shift < 'A')
                        st.Append((char)(('Z' + 1) - (str[i] - 'A')));
                    else st.Append((char)(str[i] + shift));
                }
                else
                {
                    if (str[i] + shift > 'z')
                        st.Append((char)(('a'-1) + shift - ('z' - str[i])));
                    else if (str[i] + shift < 'a')
                        st.Append((char)(('z' + 1) - (str[i] - 'a')));
                    else st.Append((char)(str[i] + shift));
                }
            }
            Console.WriteLine(st);
        }

        private static void SolveTask3()
        {
            Console.WriteLine("Enter the string: ");
            string str=Console.ReadLine();
            Console.WriteLine("Enter shift:");
            int shift=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter mode (encrypt or decrypt): ");
            string ans=Console.ReadLine();
            if (ans == "encrypt")
                Encrypt(str, shift);
            else
                if (ans == "decrypt")
                Encrypt(str, -shift);
            else Console.WriteLine("Wrong mode");
        }

        private static void SolveTask4()
        {
            Console.WriteLine("Enter numbers of strings and columns of matrix: ");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] B = new int[n, m];
            Random random = new Random();
            Console.WriteLine("Random generated matrix (first operand):");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = random.Next(0, 10);
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Choose operation (enter number): ") ;
            Console.WriteLine("1 - Умножение матрицы на число;\r\n2 - Сложение матриц;\r\n3 - Произведение матриц.");
            int op=int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    {
                        Console.WriteLine("Enter integer number");
                        int num=int.Parse(Console.ReadLine());
                        for (int i = 0; i < B.GetLength(0); i++)
                            for (int j = 0; j < B.GetLength(1); j++)
                                B[i, j] *= num;
                        for (int i = 0; i < B.GetLength(0); i++)
                        {
                            for (int j = 0; j < B.GetLength(1); j++)
                            {
                                Console.Write(B[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                case 2:
                    {
                        int[,] A = new int[n, m];
                        Console.WriteLine("Random generated matrix (second operand):");
                        for (int i = 0; i < A.GetLength(0); i++)
                        {
                            for (int j = 0; j < A.GetLength(1); j++)
                            {
                                A[i, j] = random.Next(0, 100);
                                Console.Write(A[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        for (int i = 0; i < A.GetLength(0); i++)
                        {
                            for (int j = 0; j < A.GetLength(1); j++)
                            {
                                A[i, j]+=B[i,j];
                                Console.Write(A[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                case 3: 
                    {
                        Console.WriteLine("Enter numbers of columns of matrix: ");
                        m = int.Parse(Console.ReadLine());
                        int[,] A = new int[n, m];
                        Console.WriteLine("Random generated matrix (second operand):");
                        for (int i = 0; i < A.GetLength(0); i++)
                        {
                            for (int j = 0; j < A.GetLength(1); j++)
                            {
                                A[i, j] = random.Next(0, 10);
                                Console.Write(A[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        int[,] C = new int[B.GetLength(0), A.GetLength(1)];
                        int sum = 0;
                        for (int i=0;i<C.GetLength(0);i++)
                            for (int j = 0; j < C.GetLength(1); j++)
                            {
                                for (int k = 0; k < B.GetLength(1); k++)
                                    sum += B[i, k] * A[k, j];
                                C[i, j] = sum;
                                sum = 0;
                            }
                        for (int i = 0; i < C.GetLength(0); i++)
                        {
                            for (int j = 0; j < C.GetLength(1); j++)
                            {
                                Console.Write(C[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                default: Console.WriteLine("Wrong number.");break;
            }
        }
        static void Operation(Stack<int> operands, Stack<char> operators)
        {
            int operand2 = operands.Pop();
            int operand1 = operands.Pop();
            char op = operators.Pop();

            int result = 0;
            switch (op)
            {
                case '+':
                    result = operand1 + operand2;
                    break;
                case '-':
                    result = operand1 - operand2;
                    break;
            }

            operands.Push(result);
        }
        private static void SolveTask5()
        {
            Console.WriteLine("Enter arithmetic expression: ");
            string expression = Console.ReadLine();
            Stack<int> operands = new Stack<int>();
            Stack<char> operators = new Stack<char>();
            int operand = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i])) {
                    operand = 0;
                    while ((i<expression.Length)&&(char.IsDigit(expression[i])))
                    {
                        operand = operand * 10 + (expression[i] - '0');
                        i++;
                    }
                    i--;
                    operands.Push(operand);
                }
                else if (expression[i] == '(')
                {
                    operators.Push(expression[i]);
                }
                else if (expression[i] == ')')
                {
                    while ((operators.Count!=0)&&operators.Peek() != '(')
                    {
                        Operation(operands, operators);
                    }
                    operators.Pop();
                }
                else if (expression[i] == '+'|| expression[i] == '-')
                {
                    operators.Push(expression[i]);
                }
            }

            while (operators.Count > 0)
            {
                Operation(operands, operators);
            }

            Console.WriteLine($"Result: {operands.Pop()}");
        }

        private static void SolveTask6()
        {
            Console.WriteLine("Enter text: ");
            string text = Console.ReadLine();
            if (!text.Contains('.'))
            {
                Console.WriteLine(text);
                return;
            }

            StringBuilder st = new StringBuilder();
            st.Append(Char.ToUpper(text[0]));
            for (int i = 1; i < text.Length - 1; i++)
            {
                if (text[i] == '.')
                {
                    st.Append(text[i]);
                    i++;
                    if (text[i]==' ')
                    {
                        st.Append(text[i]);
                        i++;
                    }
                    st.Append(Char.ToUpper(text[i]));
                }
                else st.Append(text[i]);
            }
            st.Append(text[text.Length - 1]);
            Console.WriteLine(st);
        }

        private static int find(string text, string word)
        {
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == word[0])
                {
                    while (i < text.Length && j < word.Length && text[i] == word[j])
                    {
                        i++;
                        j++;
                    }
                    if (j == word.Length)
                        return i - word.Length;
                    else j = 0;
                }
            }
            return -1;
        }

        private static void SolveTask7()
        {
            Console.WriteLine("Enter text: ");
            string text = Console.ReadLine();
            Console.WriteLine("Enter inacceptable word: ");
            string word = Console.ReadLine();
            int j = 0;
            int ind = find(text, word);
            int count = 0;
            StringBuilder res = new StringBuilder();
            while (ind != -1)
            {
                res.Append(text.Substring(j, ind - 1));
                res.Append("***");
                count++;
                j = ind + word.Length;
                ind = find(text.Substring(j), word);
            }
            res.Append(text.Substring(j));
            Console.WriteLine(res);
            Console.WriteLine($"Changes: {count}");
        }
    }
}
