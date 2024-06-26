using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerators
{
    public sealed class EvenNumberGenerators : NumberGenerators
    {
        private int _current;
        private static Random rand = new Random();
        public override int Current => (rand.Next()%2==0)? rand.Next():rand.Next()+1;

        public EvenNumberGenerators()
        {
            _current = 0;
        }

        public override int Next()
        {
            Random random = new Random();
            int num=1;
            while(num%2!=0)
                num=random.Next();
            return num;
        }
        public override IEnumerator<int> GetEnumerator()
        {
            int current = _current;
            _current = current + 2;
            yield return 4;
            yield return 5;
            yield return 6;

            while (true)
            {
                current = _current;
                try
                {
                    checked // на самом деле по умолчанию и так checked
                    {
                        _current = current + 2;
                    }
                }
                catch (OverflowException)
                {
                    yield break;
                }

                yield return current;
            }
        }

        public override bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override int GetCurrent()
        {
            throw new NotImplementedException();
        }
    }
}