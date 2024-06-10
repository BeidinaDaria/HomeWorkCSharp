using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HDD : Storage
    {
        private int speed { get; set; }
        private int partitionAmount { get; set; }
        private float partitionCapacity { get; set; }
        private float occupiedCapacity { get; set; }
        public HDD(string _title, string _model, int _speed, int _partitionAmount, float _partitionCapacity)
        {
            title = _title;
            model = _model;
            speed = (_speed >= 0) ? _speed : 0;
            partitionCapacity = (_partitionCapacity >= 0) ? _partitionCapacity : 0;
            partitionAmount = (_partitionAmount >= 0) ? _partitionAmount : 0;
            occupiedCapacity = 0;
        }
        public override float getMemoryCapacity() { return partitionCapacity; }
        public override bool copyFiles(float[] files)
        {
            float sum = files.Sum();
            if (partitionCapacity - occupiedCapacity - sum < 0)
                return false;
            occupiedCapacity += sum;
            return true;
        }
        public override float getFreeMemoryCapacity() { return partitionCapacity - occupiedCapacity; }
        public override void toString()
        {
            Console.WriteLine($"HDD {title} of model {model} has speed - {speed}, amount of partitions - {partitionAmount} and full capacity - {partitionCapacity} ");
        }
        public override int getSpeed()
        {
            return speed;
        }
    }
}