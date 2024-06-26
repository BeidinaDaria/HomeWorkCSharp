using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberGenerators;
using static NumberGenerators.NumberGenerators;

namespace NumberGenerators
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter task number:");
            int taskNumber = int.Parse(Console.ReadLine());
            switch (taskNumber)
            {
                case 1: SolveTask1(); break;
                case 2: SolveTask2(); break;
                case 3: SolveTask3(); break;
                case 4: SolveTask4(); break;
                default: Console.WriteLine("Unknown task"); break;
            }
            Console.ReadKey();
        }
        private static void SolveTask1()
        {
            try
            {
                SolveTask1Handled();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ooops.. Something went wrong:");
                Console.WriteLine(ex.Message);
            }
        }

        private static int inputCount()
        {
            Console.WriteLine("Enter count of numbers to generate:");
            int countToGenerate = int.Parse(Console.ReadLine());
            return countToGenerate;
        }
        private static string inputGen()
        {
            Console.WriteLine("Choose one of supported number generators: odd, even, single");
            string generatorName = Console.ReadLine();
            return generatorName;
        }
        private static NumberGenerators getGen(string name)
        {
            NumberGenerators numberGenerator;
            switch (name)
            {
                case "odd":
                    numberGenerator = new OddNumberGenerators();
                    break;
                case "even":
                    numberGenerator = new EvenNumberGenerators();
                    break;
                case "single":
                    numberGenerator = NumberGenerators.SingleRandomNumber.Instance;
                    break;
                default:
                    throw new ApplicationException($"Unknown generator: {name}");
            }
            return numberGenerator;
        }
        private static void gen(NumberGenerators generator,int count)
        {
            for (int i = 0; i < count;i++)
            {
                Console.Write(NumberGeneratorExtensions.toNumberGenerator(count));
                Console.Write(' ');
            }
            Console.WriteLine();
        }
        private static void SolveTask1Handled()
        {
            int countToGenerate = inputCount();
            
            string generatorName = inputGen();

            NumberGenerators numberGenerator=getGen(generatorName);

            gen(numberGenerator, countToGenerate);
            
        }
        private static void SolveTask2()
        {

        }
        private static void SolveTask3()
        {

        }
        private static void SolveTask4()
        {

        }
    }
}