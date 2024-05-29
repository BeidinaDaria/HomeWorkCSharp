using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Play
    {
        private int n;
        public Play()
        {
            Random random = new Random();
            n= random.Next()%10;
        }
        public void play()
        {
            int num;
            while (true)
            {
                Console.WriteLine("Enter the digit 0-9: ");
                num = int.Parse(Console.ReadLine());
                if (n == num)
                {
                    Console.WriteLine("You win!");
                    return;
                }
                if (n > num)
                    Console.WriteLine("My digit is more");
                else
                    Console.WriteLine("My digit is less");
            }
        }
    }
}
