using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Storage
    {
        protected string title { get; set; }
        protected string model { get; set; }
        public abstract float getMemoryCapacity();
        public abstract bool copyFiles(float[] files);
        public abstract float getFreeMemoryCapacity();
        public abstract void toString();
        public abstract int getSpeed();
    }
}
