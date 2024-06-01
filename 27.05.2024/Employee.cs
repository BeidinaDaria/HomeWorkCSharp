using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Employee
    {
        private string name { get; set; }
        private int salary {
            get { return salary; }
            set { if (value > 0) salary = value; }
        }
        public Employee(string name, int salary) { this.name = name; this.salary = salary; }
        public static Employee operator +(Employee e1, int inc)
        {
            if (e1.salary + inc < 0) throw new ArgumentException("Negative salary!");
            return new Employee(e1.name, e1.salary + inc);
        }
        public static Employee operator -(Employee e1, int inc)
        {
            if (e1.salary - inc < 0) throw new ArgumentException("Negative salary!");
            return new Employee(e1.name, e1.salary - inc);
        }
        public static bool operator ==(Employee e1, Employee e2)
        {
            return e1.name == e2.name && e1.salary == e2.salary;
        }
        public static bool operator !=(Employee e1, Employee e2)
        {
            return e1.name != e2.name || e1.salary != e2.salary;
        }
        public static bool operator >(Employee e1, Employee e2)
        {
            return e1.salary > e2.salary;
        }
        public static bool operator <(Employee e1, Employee e2)
        {
            return e1.salary < e2.salary;
        }
        public bool Equals(ref Employee e1)
        {
            return e1 == this;
        }
    }
}
