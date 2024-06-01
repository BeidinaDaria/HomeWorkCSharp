using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class City
    {
        private string name { get; set; }
        private int pop
        {
            get { return pop; }
            set { if (value > 0) pop = value; }
        }
        public City(string name, int pop) { this.name = name; this.pop = pop; }
        public static City operator +(City e1, int inc)
        {
            if (e1.pop + inc < 0) throw new ArgumentException("Negative salary!");
            return new City(e1.name, e1.pop + inc);
        }
        public static City operator -(City e1, int inc)
        {
            if (e1.pop - inc < 0) throw new ArgumentException("Negative salary!");
            return new City(e1.name, e1.pop - inc);
        }
        public static bool operator ==(City e1, City e2)
        {
            return e1.pop == e2.pop;
        }
        public static bool operator !=(City e1, City e2)
        {
            return e1.pop != e2.pop;
        }
        public static bool operator >(City e1, City e2)
        {
            return e1.pop > e2.pop;
        }
        public static bool operator <(City e1, City e2)
        {
            return e1.pop < e2.pop;
        }
        public bool Equals(ref City e1)
        {
            return e1 == this;
        }
    }
}
