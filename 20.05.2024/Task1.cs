using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class OddGenerator { 
        public static int gen()
        {
            Random rnd = new Random();
            int c=rnd.Next();
            if (c * 2 > int.MaxValue)
                return (c * 2-1) % int.MaxValue;
            return c*2-1;
        }
    };
    public class EvenGenerator {
        public static int gen()
        {
            Random rnd = new Random();
            int c=rnd.Next();
            if (c * 2 > int.MaxValue)
                return (c * 2) % int.MaxValue;
            return c * 2;
        }
    };
    public class SimpleGenerator {
        private static bool check(int x)
        {
            for (int i = 2; i <= Math.Sqrt(x); i++)
                if (x % i == 0)
                    return false;
            return true;
        }
        public static int gen()
        {
            Random rnd = new Random();
            int num = 1;
            int count = rnd.Next()%1000;
            int s = 1;

            while (s < count)
            {
                num++;
                if (check(num))
                {
                    s++;
                }
            }
            return num;
        }
    };
    public class FibGenerator {
        public static int gen()
        {
            Random rnd = new Random();
            int count = rnd.Next()%1000;
            if (count==0) return 0;
            if (count ==1 || count==2) return 1;
            int s = 3;
            int a = 1, b = 1, c = 2;
            while (s < count)
            {
                a = b;
                b = c;
                c = a + b;
                s++;
            }
            return c;
        }
    };
}
