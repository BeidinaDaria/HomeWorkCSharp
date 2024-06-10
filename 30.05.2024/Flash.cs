using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Flash : Storage
    {
        private int speed { get; set; }
        private float capacity { get; set; }
        private float occupiedCapacity { get; set; }
        public Flash(string _title, string _model, int _speed, float _capacity)
        {
            title = _title;
            model = _model;
            speed = (_speed >= 0) ? _speed : 0;
            capacity = (_capacity >= 0) ? _capacity : 0;
            occupiedCapacity = 0;
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
            Console.WriteLine($"Flash {title} of model {model} has speed - {speed} and capacity - {capacity}");
        }
        public override int getSpeed()
        {
            return speed;
        }
    }
}
