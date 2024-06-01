using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Card
    {
        private int cvc { get; }
        private int balance { get; set; }
        public Card(int cvc, int balance) {
            if (cvc < 0 || cvc > 999)
                throw new ArgumentException("Wrong CVC");
            this.cvc = cvc;
            this.balance = balance;
        }
        public static Card operator +(Card e1, int inc)
        {
            if (e1.balance + inc < 0) throw new ArgumentException("Negative salary!");
            return new Card(e1.cvc, e1.balance + inc);
        }
        public static Card operator -(Card e1, int inc)
        {
            if (e1.balance - inc < 0) throw new ArgumentException("Negative salary!");
            return new Card(e1.cvc, e1.balance - inc);
        }
        public static bool operator ==(Card e1, Card e2)
        {
            return e1.cvc == e2.cvc && e1.balance == e2.balance;
        }
        public static bool operator !=(Card e1, Card e2)
        {
            return e1.cvc != e2.cvc || e1.balance != e2.balance;
        }
        public static bool operator >(Card e1, Card e2)
        {
            return e1.balance > e2.balance;
        }
        public static bool operator <(Card e1, Card e2)
        {
            return e1.balance < e2.balance;
        }
        public bool Equals(ref Card e1)
        {
            return e1 == this;
        }
    }
}