using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Diagnostics.Metrics;


namespace Laba8
{

    public class Queue<T>: IGeneric<T>, IEnumerable
    {
        private int _Front = -1;
        private int _Rear = -1;
        private int _Count = 0;
        private readonly int _Size;
        public T[] _Array;
        public T[] _ReserveArray;
        private int _newCount;
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
        public void Contains(T a)
        {
            _ReserveArray = _Array;

            while (_Count > 0)
            {
                T value = this.Dequeue();
                if (!Convert.ToBoolean(Convert.ToInt32(value).CompareTo(a)))
                {
                    Console.WriteLine("Данное значение встречается в очереди");
                }
                else
                {
                    Console.WriteLine("Таких значений нет");
                }
            }
            _Array = _ReserveArray;

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
        public static explicit operator int(Queue<T> q11)
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
            if (q1.Count != 0)
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


        //public T[] ReadFromFile()
        //{
        //    using (StreamReader sw = new StreamReader(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab07\ConsoleApp1\ConsoleApp1\data.txt"))
        //    {
        //        string[] items = sw.ReadToEnd().Split(" --> ");

        //        T[] outputItems = new T[items.Length];


        //        int counter = 0;
        //        foreach (string item in items)
        //        {
        //            outputItems[counter] = (T)Convert.ChangeType(item, typeof(T));
        //            counter++;
        //        }

        //        return outputItems;
        //    }
        //    //TODO как-то обобщить это
        //}
        public IEnumerator GetEnumerator()
        {
            if (this.IsEmpty())
                throw new Exception("Очередь не заполнена.");

            for (int i = _Front + 1; i <= _Rear; i++)
                yield return _Array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
                    if (max < member)
                    {
                        max = member;
                    }
                    if (min > member)
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
            
            public static T[] ReadFromFile()
            {
                using (StreamReader sw = new StreamReader(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab07\ConsoleApp1\ConsoleApp1\data.txt"))
                {
                    string[] items = sw.ReadToEnd().Split(" ");
                    Console.WriteLine(items.Length);
                    T[] outputItems = new T[items.Length - 1];


                    int counter = 0;
                    
                    for(int i = 0; i < items.Length; i++)
                    {
                        outputItems[counter] = (T)Convert.ChangeType(items[i], typeof(int));
                        counter++;
                    }

                    return outputItems;
                }
                //TODO как-то обобщить это
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
        public static void WriteToFile(Queue<int> q11)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab07\ConsoleApp1\ConsoleApp1\data.txt"))
            {
                for (int i = 0; i < q11._Array.Length; i++)
                {
                    sw.Write(q11._Array[i] + " ");
                }

                //static int LastInt(this Queue<int> set)
                //{
                //    return set._Array.Last();
                //}
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
                Best.WriteToFile(q1);
                //int[] GETT = Queue<int>.StatisticOperation.ReadFromFile();
                //foreach (int i in GETT)
                //{
                //    Console.WriteLine(i + " ");
                //}
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
                //Console.WriteLine($"Последний элемент {test.LastInt()}");
                int x = (int)q2;
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
                q1.Contains(4);
                //q1.Show();

                var list = new List<int>();

                try
                {
                    list.Add(12);
                    list.Add(13);
                    list.Add(14);
                    
                    //list.Show();
                    //list.Delete(13);
                    //list.Show();
                    //list.Delete(12);
                    //list.Show();
                    //list.Delete(14);
                    //list.Show();
                    //list.Delete(14);
                }
                catch (InvalidOperationException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Finally");
                }

                /*Проверьте использование обобщения для стандартных типов данных (в качестве стандартных типов использовать целые, вещественные и т.д.).*/

                var stringList = new List<string>();
                var intList = new List<int>();
                var doubleList = new List<double>();

                Console.ForegroundColor = ConsoleColor.Magenta;
                stringList.Add("A");
                stringList.Add("B");
                stringList.Add("C");
                stringList.Remove("B");

                Console.ForegroundColor = ConsoleColor.Yellow;
                intList.Add(12);
                intList.Add(13);
                intList.Add(14);


                Console.ForegroundColor = ConsoleColor.Green;
                doubleList.Add(1.2);
                doubleList.Add(2.2);
                doubleList.Add(3.2);


                var printers = new List<Printer>();

                Console.Read();
            }
        }
        public class Printer
        {
            public void IAmPrinting(int item)
            {
                Console.WriteLine(item.ToString());

            }
        }
    }
}


