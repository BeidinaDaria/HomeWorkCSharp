using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Matrix
    {
        private int[,] collection { get; set; }
        public Matrix(int n, int m)
        {
            Random random = new Random();   
            collection = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    collection[i, j] = random.Next(0, 10);
                }
            }
        }
        public void print()
        {
            for (int i = 0; i < collection.GetLength(0); i++)
            {
                for (int j = 0; j < collection.GetLength(1); j++)
                {
                    Console.Write(collection[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public int this[int i, int j]
        {
            get {
                if (i < 0 || i >= collection.GetLength(0) || j < 0 || j >= collection.GetLength(1))
                    throw new ArgumentException("Wrong index");
                return collection[i, j]; 
            }
            set
            {
                if (i < 0 || i >= collection.GetLength(0) || j < 0 || j >= collection.GetLength(1))
                    throw new ArgumentException("Wrong index");
                collection[i, j]=value;
            }
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.collection.GetLength(0) != b.collection.GetLength(0) || a.collection.GetLength(1) != b.collection.GetLength(1))
                throw new ArgumentException("Wrong sizes");
            Matrix c = new Matrix(a.collection.GetLength(0), a.collection.GetLength(1));
            for (int i = 0; i < a.collection.GetLength(0); i++)
            {
                for (int j = 0; j < a.collection.GetLength(1); j++)
                {
                    c[i,j]=a[i, j] + b[i, j];
                }
            }
            return c;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.collection.GetLength(0) != b.collection.GetLength(0) || a.collection.GetLength(1) != b.collection.GetLength(1))
                throw new ArgumentException("Wrong sizes");
            Matrix c = new Matrix(a.collection.GetLength(0), a.collection.GetLength(1));
            for (int i = 0; i < a.collection.GetLength(0); i++)
            {
                for (int j = 0; j < a.collection.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }
            return c;
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.collection.GetLength(1) != B.collection.GetLength(0))
                throw new ArgumentException("Wrong shapes");
            Matrix C = new Matrix(B.collection.GetLength(0), A.collection.GetLength(1));
            int sum = 0;
            for (int i = 0; i < C.collection.GetLength(0); i++)
                for (int j = 0; j < C.collection.GetLength(1); j++)
                {
                    for (int k = 0; k < B.collection.GetLength(1); k++)
                        sum += B[i, k] * A[k, j];
                    C[i, j] = sum;
                    sum = 0;
                }
            return C;
        }
        public static Matrix operator *(Matrix a, int n)
        {
            Matrix c = new Matrix(a.collection.GetLength(0), a.collection.GetLength(1));
            for (int i = 0; i < a.collection.GetLength(0); i++)
            {
                for (int j = 0; j < a.collection.GetLength(1); j++)
                {
                    c[i, j] = a[i, j]*n;
                }
            }
            return c;
        }
        public static bool operator==(Matrix a, Matrix b)
        {
            if (a.collection.GetLength(0) != b.collection.GetLength(0) || a.collection.GetLength(1) != b.collection.GetLength(1))
                return false;
            for (int i=0;i<a.collection.GetLength(0);i++)
                for (int j=0;j<a.collection.GetLength(1);j++)
                    if (a[i,j] != b[i,j])
                        return false;
            return true;
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            if (a.collection.GetLength(0) != b.collection.GetLength(0) || a.collection.GetLength(1) != b.collection.GetLength(1))
                return true;
            for (int i = 0; i < a.collection.GetLength(0); i++)
                for (int j = 0; j < a.collection.GetLength(1); j++)
                    if (a[i, j] != b[i, j])
                        return true;
            return false;
        }
    }
}
