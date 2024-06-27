using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Auto : IComparer
    {
        private string color { get; set; }
        private int fuel { get; set; }
        private int capacity { get; set; }
        private SortedList<int, int> fuelConsumption = new SortedList<int, int>();
        private string consumptionType { get; set; }
        public Auto()
        {
            input();
        }
        private void input()
        {
            try {
                Console.WriteLine("New car");

                Console.WriteLine("Color: ");
                color = Console.ReadLine().ToLower();

                Console.WriteLine("Fuel weight: ");
                fuel = int.Parse(Console.ReadLine());
                if (fuel < 0) { throw new ArgumentException("Negative weight of fuel!"); }

                Console.WriteLine("Capacity: ");
                capacity = int.Parse(Console.ReadLine());
                if (capacity < 0) { throw new ArgumentException("Negative capacity!"); }

                Console.WriteLine("Write information of fuel consumption: format \"weight consumption\" only integer. \n After all write \"end\"");
                string ans = Console.ReadLine();
                while (ans.ToLower() != "end")
                {
                    if (int.Parse(ans.Split(' ')[0]) < 0) { throw new ArgumentException("Negative speed!"); }
                    if (int.Parse(ans.Split(' ')[1]) < 0) { throw new ArgumentException("Negative consumption!"); }
                    fuelConsumption.Add(int.Parse(ans.Split(' ')[0]), int.Parse(ans.Split(' ')[1]));
                    ans = Console.ReadLine();
                }

                Console.WriteLine("Type of consumption: ");
                consumptionType = Console.ReadLine().ToLower();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public bool canMoveLoad(int weight, string _color, string _type, int _speed, int len)
        {
            int speed = _speed;
            if (speed < fuelConsumption.Keys.Max())
                return false;
            while (!fuelConsumption.ContainsKey(speed)) { speed++; }
            if ((_color != "no" && _color != color) || (_type != "no" || _type != consumptionType) || fuel < len * fuelConsumption[speed])
                return false;
            return true;
        }

        public static int Compare(Auto? c1, Auto? c2)
        {
            if (c1 == null || c2 == null) { return 0; }
            if ((c1.capacity-c1.fuel) > (c2.capacity - c2.fuel))
                return 1;
            if ((c1.capacity - c1.fuel) < (c2.capacity - c2.fuel))
                return -1;
            else
                return 0;
        }
    }
    internal class Program
    {
        public static SortedList<int, string> inputLoad()
        {
            Console.WriteLine("Input path to file with loads");
            string path = Console.ReadLine();
            SortedList<int, string> loads = new SortedList<int, string>();
            using (FileStream fs = new FileStream(path, FileMode.Open,
                FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    string str;
                    while (!sr.EndOfStream)
                    {
                        str = sr.ReadLine();
                        if (int.Parse(str.Split(' ')[1]) < 0) { throw new ArgumentException("Negative weight!"); }
                        loads.Add(int.Parse(str.Split(' ')[1]), str.Split(' ')[0]);
                    }
                }
            }
            return loads;
        }
        static List<Auto> inputAuto()
        {
            Console.WriteLine("Input cars \n How many?");
            int count = int.Parse(Console.ReadLine());

            if (count < 0) { throw new ArgumentException("Negative count!"); }
            List<Auto> autos = new List<Auto>();
            for (int i = 0; i < count; i++)
            {
                autos.Add(new Auto());
            }
            return autos;
        }

        private static void Task(List<Auto> autos,SortedList<int,string> loads,string color,string type,int len, int speed)
        {
            int consumption = 0;
            autos.Sort();
            int j = autos.Count-1;
            if (speed < 0 || len < 0) throw new ArgumentException("Wrong argument!");
            for (int l= loads.Count-1; l>0;l--)
            {
                //loads to autos and count consumption
            }
             
        }
        static void Main(string[] args)
        {
            List<Auto> auto = inputAuto();

            SortedList<int, string> loads = inputLoad();

            Console.WriteLine("Do you want to choose color? Write color or no");
            string color = Console.ReadLine().ToLower();

            Console.WriteLine("Do you want to type of fuel consumption? Write type or no");
            string type = Console.ReadLine().ToLower();

            Console.WriteLine("Enter length of path:");
            int len = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter length of path:");
            int speed = int.Parse(Console.ReadLine());

            Task(auto, loads, color, type,len,speed);
        }
    }
}