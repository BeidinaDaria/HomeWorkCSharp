using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DVD : Storage
    {
        private int readSpeed { get; set; }
        private int writeSpeed { get; set; }
        private bool type { get; set; }
        private float capacity { get; set; }
        private float occupiedCapacity { get; set; }
        public DVD(string _title, string _model, int _writeSpeed, int _readSpeed)
        {
            title = _title;
            model = _model;
            readSpeed = (_readSpeed >= 0) ? _readSpeed : 0;
            writeSpeed = (_writeSpeed >= 0) ? _writeSpeed : 0;
            Random random = new Random();
            capacity = (float)((random.Next(0, 1) == 0) ? 4.7 * 1024 : 9.0 * 1024);
            occupiedCapacity = 0;
            type = (capacity == 9.0);
        }
        public override float getMemoryCapacity() { return capacity; }
        public override bool copyFiles(float[] files)
        {
            float sum = files.Sum();
            if (capacity - occupiedCapacity - sum < 0)
                return false;
            occupiedCapacity += sum;
            return true;
        }
        public override float getFreeMemoryCapacity() { return capacity - occupiedCapacity; }
        public override void toString()
        {
            string t = (type) ? "duplex" : "unidirectional";
            Console.WriteLine($"DVD {title} of model {model} has speed of read - {readSpeed}, speed of write - {writeSpeed} and type - {t} ");
        }
        public override int getSpeed()
        {
            return writeSpeed;
        }
    }
}
