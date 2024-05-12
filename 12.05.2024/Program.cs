using System.Linq.Expressions;
using System.Threading;
namespace ConsoleApp1
{
    class WebSite
    {
        string? name { get; set; }
        string? path { get; set; }
        string? desc { get; set; }
        string? ip { get; set; }
        public WebSite()
        {
            Console.WriteLine("Enter the name of webSite: ");
            name=Console.ReadLine();
            Console.WriteLine("Enter the path to webSite: ");
            path = Console.ReadLine();
            Console.WriteLine("Enter the description of webSite: ");
            desc = Console.ReadLine();
            Console.WriteLine("Enter the ip-address of webSite: ");
            ip = Console.ReadLine();
        }
        public void Print()
        {
            Console.WriteLine(name+' '+path);
            Console.WriteLine(desc);
            Console.WriteLine("Ip: "+ip);
        }
    };
    class Journal
    {
        string? name { get; set; }
        int yearOfFound { get; set; }
        string? desc { get; set; }
        string? phoneNumber {  get; set; }
        string? email { get; set; }
        public Journal()
        {
            try { 
                Console.WriteLine("Enter the name of journal: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter the year of founding: ");
                yearOfFound = int.Parse(Console.ReadLine());
                if (yearOfFound < 0) throw new FormatException("Uncorrect year!");
                Console.WriteLine("Enter the description of journal: ");
                desc = Console.ReadLine();
                Console.WriteLine("Enter the phone number of journal: ");
                phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter the email-address of journal: ");
                email = Console.ReadLine();
            }
            catch(Exception ex){ Console.WriteLine(ex.Message); }
        }
        public void Print()
        {
            Console.WriteLine(name + ' ' + yearOfFound);
            Console.WriteLine(desc);
            Console.WriteLine("Contacts: " + phoneNumber +", "+email);
        }
    };
    class Shop
    {
        string? name { get; set; }
        string? address { get; set; }
        string? desc { get; set; }
        string? phoneNumber { get; set; }
        string? email { get; set; }
        public Shop()
        {
            Console.WriteLine("Enter the name of shop: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter the address of shop: ");
            address = Console.ReadLine();
            Console.WriteLine("Enter the profile of shop: ");
            desc = Console.ReadLine();
            Console.WriteLine("Enter the phone number of shop: ");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter the email-address of shop: ");
            email = Console.ReadLine();
        }
        public void Print()
        {
            Console.WriteLine(name + " (" + desc+")");
            Console.WriteLine(address);
            Console.WriteLine("Contacts: " + phoneNumber + ", " + email);
        }
    };

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
                case 3: Task3(); break;
                case 4:
                    WebSite web = new WebSite();
                    web.Print();
                    break;
                case 5:
                    Journal j = new Journal();
                    j.Print(); 
                    break;
                case 6:
                    Shop shop = new Shop();
                    shop.Print();
                    break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }

        static void Task1()
        {
            try
            {
                Console.WriteLine("Enter the length of square:");
                int l = int.Parse(Console.ReadLine());

                if (l < 0) throw new FormatException("Wrong input");
                Console.WriteLine("Enter the char:");
                char c = (char)Console.ReadKey().Key;
                Console.WriteLine();

                for (int i = 0; i < l; i++)
                {
                    Console.Write(c);
                    Console.Write(" ");
                }
                Console.WriteLine();
                for (int i = 0; i < l - 2; i++)
                {
                    Console.Write(c);
                    for (int j = 0; j < l - 2; j++)
                        Console.Write("  ");
                    Console.Write(" ");
                    Console.WriteLine(c);
                }
                for (int i = 0; i < l; i++)
                {
                    Console.Write(c);
                    Console.Write(" ");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static bool Check(int num)
        {
            int d = 1;
            while (num / d != 0)
                d = d * 10;
            d = d / 10;
            while (d > 1)
            {
                if (num / d != num % 10)
                    return false;
                num = (num % d) / 10;
                d = d / 100;
            }
            return true;
        }

        static void Task2()
        {
            Console.WriteLine("Enter the number:");
            int num = Math.Abs(int.Parse(Console.ReadLine()));
            if (Check(num))
                Console.WriteLine("It's palindrom.");
            else Console.WriteLine("It isn't a palindrom.");
        }

        static void Task3()
        {
            try
            {
                Console.Write("Enter the length of array and after that the array: ");
                int l = int.Parse(Console.ReadLine());
                if (l < 0) throw new FormatException("Wrong input");

                int[] arr = new int[l];
                for (int i = 0; i < l; i++)
                    arr[i] = int.Parse(Console.ReadLine());

                Console.Write("Enter the length of filter array and after that the array: ");
                int n = int.Parse(Console.ReadLine());
                if (n < 0) throw new FormatException("Wrong input");

                HashSet<int> set = new HashSet<int>();
                for (int i = 0; i < n; i++)
                    set.Add(int.Parse(Console.ReadLine()));

                List<int> list = new List<int>();
                for (int i = 0; i < l; i++)
                    if (!set.Contains(arr[i]))
                        list.Add(arr[i]);

                Console.Write("Result: ");
                for (int i = 0; i < list.Count(); i++)
                {
                    Console.Write(list[i]);
                    Console.Write(' ');
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
    }
}