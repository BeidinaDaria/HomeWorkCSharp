using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGenerators
{
    public abstract class NumberGenerators: INumberGenerator
    {
        public abstract int GetCurrent();

        object IEnumerator.Current => throw new NotImplementedException();

        public abstract int Current { get; }

        public abstract int Next();
        public abstract IEnumerator<int> GetEnumerator();
        public abstract bool MoveNext();
        public abstract void Reset();
        public abstract void Dispose();

        public sealed class SingleRandomNumber : NumberGenerators
        {
            private static readonly Random Random = new Random();
            public static SingleRandomNumber Instance { get; } = new SingleRandomNumber();
            public override int Current => Random.Next();

            private SingleRandomNumber() { }

            public override IEnumerator<int> GetEnumerator()
            {
                yield return Random.Next();
            }

            public override int GetCurrent()
            {
                return Current;
            }

            public override int Next()
            {
                return Random.Next();
            }

            public override bool MoveNext()
            {
                return false;
            }

            public override void Reset()
            {
                return;
            }

            public override void Dispose()
            {
                return;
            }
        }
        public static class NumberGeneratorExtensions
        {
            public static IEnumerable<int> toNumberGenerator(int count)
            {
                for (int i = 0; i < count; i++) {
                    yield return NumberGenerator.enumerator.Current;
                }
            }
            private class NumberGenerator
            {
                public static IEnumerator<int> enumerator =  NumberGenerators.SingleRandomNumber.Instance;
            }
        }
    }
}
