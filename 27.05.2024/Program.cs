using System.Threading.Tasks;

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
                case 1: 
                    Employee e1 = new Employee("Mark", 100);
                    Employee e2 = new Employee("Mike", 200);
                    Employee e3 = new Employee("Mark", 200);
                    Console.WriteLine(e1 == e2);
                    Console.WriteLine(e2 != e3);
                    e3 = e3 - 100;
                    Console.WriteLine(e3 == e1);
                    Console.WriteLine(e1 < e2);
                    break;
                case 2:  
                    Matrix a = new Matrix(5, 5);
                    a.print();
                    Matrix b = new Matrix(5, 5);
                    b.print();
                    (a * b).print();
                    break;
                case 3:
                    City c1 = new City("Mark", 100);
                    City c2 = new City("Mike", 200);
                    City c3 = new City("Mark", 200);
                    Console.WriteLine(c1 == c2);
                    Console.WriteLine(c2 != c3);
                    c3 = c3 - 100;
                    Console.WriteLine(c3 == c1);
                    Console.WriteLine(c1 < c2);
                    break;
                case 4:
                    Card k1 = new Card(707, 100);
                    Card k2 = new Card(670, 200);
                    Card k3 = new Card(034, 200);
                    Console.WriteLine(k1 == k2);
                    Console.WriteLine(k2 != k3);
                    k3 = k3 - 100;
                    Console.WriteLine(k3 == k1);
                    Console.WriteLine(k1 < k2); 
                    break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }
    }
}