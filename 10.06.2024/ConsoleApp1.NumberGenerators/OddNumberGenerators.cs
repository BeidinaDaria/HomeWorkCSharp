using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerators
{
    public sealed class OddNumberGenerators : NumberGenerators
    {
        private int _current;

        public override int Current
        {
            get { return _current; }
        }

        public OddNumberGenerators()
        {
            _current = 1;
        }

        public override int Next()
        {
            return _current;
        }
        public override IEnumerator<int> GetEnumerator()
        {
            int current = _current;
            _current = current + 2;
            yield return current;
        }

        public override int GetCurrent()
        {
            throw new NotImplementedException();
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
    }
}
