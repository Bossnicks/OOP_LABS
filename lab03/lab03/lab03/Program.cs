using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Diagnostics.Metrics;

namespace lab03
{
    
    public class Queue<T> : IEnumerable
    {
        private int _Front = -1;
        private int _Rear = -1;
        private int _Count = 0;
        private readonly int _Size;
        public readonly T[] _Array;
        public Queue(int Size)
        {
            this._Size = Size;
            this._Array = new T[Size];
        }
        public bool IsFull()
        {
            return _Rear == _Size - 1;
        }
        public bool IsEmpty()
        {
            return _Count == 0;
        }
        public void Enqueue(T Item)
        {
            if (this.IsFull())
                throw new Exception("Очередь полностью заполнена.");
            _Array[++_Rear] = Item;
            _Count++;
        }
        public T Dequeue()
        {
            if (this.IsEmpty())
                throw new Exception("Очередь не заполнена.");
            T value = _Array[++_Front];
            _Count--;
            if (_Front == _Rear)
            {
                _Front = -1;
                _Rear = -1;
            }
            return value;
        }
        public int Size
        {
            get { return _Size; }
        }
        public int Count
        {
            get { return _Count; }
        }
        public static Queue<T> operator +(Queue<T> q1, T it)
        {
            q1.Enqueue(it);
            return q1 as Queue<T>;
        }
        public static Queue<T> operator --(Queue<T> q1)
        {
            q1.Dequeue();
            return q1;
        }
        public static explicit operator int (Queue<T> q11)
        {
            return q11.Count;
        }
        public static Queue<T> operator <(Queue<T> q11, Queue<T> newQueue)
        {
            Array.Sort(q11._Array);
            Array.Reverse(q11._Array);

            for (int i = 0; i < q11._Array.Length; i++)
            {
                Console.Write(q11._Array[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < q11._Array.Length; i++)
            {
                newQueue.Enqueue(q11._Array[i]);
            }
            return newQueue;

        }
        public static Queue<T> operator >(Queue<T> q1, Queue<T> newQueue)
        {
            T[] massiv = new T[q1.Count];
            for (int i = q1.Count; i != 0; i--)
            {
                massiv[i] = q1.Dequeue();
            }
            Array.Sort(massiv);
            Array.Reverse(massiv);
            for (int i = 0; i < massiv.Length; i++)
            {
                Console.WriteLine(massiv[i] + " ");
            }
            for (int i = 0; i < massiv.Length; i++)
            {
                newQueue.Enqueue(massiv[i]);
            }
            return newQueue;
        }
        public static bool operator true(Queue<T> q1)
        {
            if(q1.Count != 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(Queue<T> q1)
        {
            if (q1.Count == 0)
            {
                return true;
            }
            Console.WriteLine("Перегружен оператор false");
            return false;
        }

        public T Peek()
        {
            if (this.IsEmpty())
                throw new Exception("Очередь не заполнена.");
            T value = _Array[_Front + 1];
            return value;
        }
        public IEnumerator GetEnumerator()
        {
            if (this.IsEmpty())
                throw new Exception("Очередь не заполнена.");

            for (int i = _Front + 1; i <= _Rear; i++)
                yield return _Array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public class Production
        {
            public Guid ID;
            public string Name;
            public string Organization;
            public Production()
            {
                ID = Guid.NewGuid();
                Name = "Nikon";
                Organization = "BSTU";
            }
        }
        public Production myProduction = new Production();
        public static class StatisticOperation
        {
            public static int Sum(Queue<int> set1, Queue<int> set2)
            {
                return set1.Count + set2.Count;
            }
            public static int Diff(Queue<int> set1)
            {
                int max = int.MinValue;
                int min = int.MaxValue;
                int member;
                while (set1.Count > 0)
                {
                    member = set1.Dequeue();
                    if(max < member)
                    {
                        max = member;
                    }
                    if(min > member)
                    {
                        min = member;
                    }
                }
                return max - min;
            }
            public static int Length(Queue<int> set1)
            {
                return set1.Count;
            }
        }
    }
    public static class Best
    {
        public static int IntCount(this Queue<int> set, int c)
        {
            int counter = 0;
            for (int i = 0; i < set._Array.Length; i++)
            {
                if (set._Array[i] == c)
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int LastInt(this Queue<int> set)
        {
            return set._Array.Last();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q1 = new Queue<int>(5);
            Queue<int> q2 = new Queue<int>(5);
            Queue<int> q3 = new Queue<int>(5);
            var test = q1 + 7;
            test = test + (-34);
            test = test + (27);
            test = test + (-9);
            int diffBetweenMaxAndMin = Queue<int>.StatisticOperation.Diff(q1);
            test = test + 7;
            test = test + (-34);
            test = test + (27);
            test = test + (-9);
            test = test + (27);
            --q1;
            q1 = q1 < q3;
            if (q1)
            {
                Console.WriteLine("Очередь пуста");
            }
            Console.WriteLine($"Кол-во введенного элемента {test.IntCount(27)}");
            Console.WriteLine($"Последний элемент {test.LastInt()}");
            int x = (int) q2;
            Console.WriteLine($"Кол-во {x}");
            Console.WriteLine("Сделано: " + q1.Dequeue());
            int len = Queue<int>.StatisticOperation.Length(q1);
            int sumOfBothQueue = Queue<int>.StatisticOperation.Sum(q1, q2);
            Console.WriteLine(sumOfBothQueue);
            Console.WriteLine(diffBetweenMaxAndMin);
            Console.WriteLine(len);
            foreach (int c in q1)
            {
                Console.WriteLine("Осталось: " + c);
            }
            Console.WriteLine("Всего осталось: " + q1.Count.ToString());
            Console.Read();
        }
    }
}

