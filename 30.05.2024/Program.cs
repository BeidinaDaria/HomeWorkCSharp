using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage[] storages = {new Flash("USB","Odeon",130,2048),
                new DVD("Sony", "DVP-SR760HP",2,385),
                new HDD("Seagate","BarraGuda",500,32,500*1024)
            };
            float[] files = { (float)2.3, 46, 1054, 34, 20 };
            int num;
            Console.WriteLine("Enter task number:");
            int taskNumber = int.Parse(Console.ReadLine());
            switch (taskNumber)
            {
                case 1:Task1(storages);break;
                case 2:
                    Console.WriteLine("Введите номер носителя от 1 до 3");
                    num = int.Parse(Console.ReadLine());
                    Task2(storages[num], files);
                    break;
                case 3:
                    Console.WriteLine("Введите номер носителя от 1 до 3");
                    num = int.Parse(Console.ReadLine());
                    Task3(storages[num], files);
                    break;
                case 4:
                    Console.WriteLine("Введите номер носителя от 1 до 3");
                    num = int.Parse(Console.ReadLine());
                    Task4(storages[num-1], files);
                    break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }
        static void Task1(Storage[] storages)
        {
            float sum = 0;
            for (int i = 0; i < storages.Length; i++)
            {
                sum += storages[i].getMemoryCapacity();
            }
            Console.WriteLine($"У нас есть {sum} памяти.");
        }
        static void Task2(Storage storage, float[] files)
        {
            if (storage.copyFiles(files))
                Console.Write("Files were successfully copied to ");
            else Console.Write("Files can't be copied to ");
            storage.toString();
        }
        static void Task3(Storage storage, float[] files)
        {
            Console.WriteLine($"Для копирования потребуется {files.Sum() / storage.getSpeed()} секунд");
        }
        static void Task4(Storage st, float[] files) {

            Console.WriteLine($"Для копирования потребуется еще {Math.Ceiling(files.Sum() / st.getMemoryCapacity())-1} таких носителей");
        }
    }
}