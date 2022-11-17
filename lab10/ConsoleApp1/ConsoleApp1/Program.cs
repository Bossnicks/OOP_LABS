using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;

public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            private Node() { }//закрытый конструктор
            public T Data { get; private set; }
            public Node<T> Next { get; set; }
        }
        public partial class NodeStack<T> : IEnumerable<T>, IEquatable<NodeStack<T>?> 
        {
            static readonly DateTime baseline;//переменная только для чтения
            const int variant = 14;//поле-константа
            Node<T> head;
            static int count;
            static float sum;
            public NodeStack()
            {

            }
            static NodeStack()//статический конструктор
            {
                baseline = DateTime.Now;
            }
            public int Variant
            {
                get { return variant; }
            }
            public float Sum { get; set; }
            public DateTime BaseLine
            {
                get { return baseline; }
            }
            public bool IsEmpty
            {
                get { return count == 0; }
            }
            public int Count
            {
                get { return count; }
            }

            public override bool Equals(object? obj)
            {
                return Equals(obj as NodeStack<T>);
            }

            public bool Equals(NodeStack<T>? other)
            {
                return other is not null &&
                       EqualityComparer<Node<T>>.Default.Equals(head, other.head) &&
                       Variant == other.Variant &&
                       BaseLine == other.BaseLine &&
                       IsEmpty == other.IsEmpty &&
                       Count == other.Count &&
                       identifier == other.identifier;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(head, Variant, BaseLine, IsEmpty, Count, identifier);
            }

            public static bool operator ==(NodeStack<T>? left, NodeStack<T>? right)
            {
                return EqualityComparer<NodeStack<T>>.Default.Equals(left, right);
            }

            public static bool operator !=(NodeStack<T>? left, NodeStack<T>? right)
            {
                return !(left == right);
            }
        }
        public partial class NodeStack<T> : IEnumerable<T>
        {
            public void Push(T item)
            {
                // увеличиваем стек
                Node<T> node = new Node<T>(item);
                Sum += Convert.ToSingle(item);
                node.Next = head; // переустанавливаем верхушку стека на новый элемент
                head = node;
                count++;
            }
            public T Pop()
            {
                // если стек пуст, выбрасываем исключение
                if (IsEmpty)
                    throw new InvalidOperationException("Стек пуст");
                Node<T> temp = head;
                head = head.Next; // переустанавливаем верхушку стека на следующий элемент
                count--;
                return temp.Data;
            }
            public T Peek()
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Стек пуст");
                return head.Data;
            }
            public int identifier;
            public int Changer(ref int id, float fl)
            {
                if (fl < 0)
                {
                    identifier = id;
                    return identifier;
                }
                return -1;
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }

public class Program
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        static float GetRandom()
        {
            //Создание объекта для генерации чисел (с указанием начального значения)
            Random rnd = new Random();

            //Получить случайное число 
            float value = rnd.Next(0, 2);

            //Вернуть полученное значение
            return value;
        }
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August",
            "September", "October", "November", "December" };
        Console.WriteLine("Enter string length, what you want to write");
        int len = Convert.ToInt32(Console.ReadLine());
        IEnumerable<string> monthQuery1 = 
            from month in months
            where month.Length == len
            select month;
        IEnumerable<string> monthQuery2 =
            from month in months
            where Array.IndexOf(months, month) == 0 ||
            Array.IndexOf(months, month) == 1 ||
            Array.IndexOf(months, month) == 5 ||
            Array.IndexOf(months, month) == 6 ||
            Array.IndexOf(months, month) == 7 ||
            Array.IndexOf(months, month) == 11
            select month;
        IEnumerable<string> monthQuery3 =
            from month in months
            orderby month
            select month;
        IEnumerable<string> monthQuery4 =
            from month in months
            where month.Contains("u") && month.Length > 4
            select month;
        foreach (string i in monthQuery1)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        foreach (string i in monthQuery2)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        foreach (string i in monthQuery3)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        foreach (string i in monthQuery4)
        {
            Console.WriteLine(i);
        }
        List <NodeStack<float>> list = new List<NodeStack<float>>();
        float[] firstNumber = new float[10];
        NodeStack<float>[] stack = new NodeStack<float>[10];
        bool flag = true;
        bool flag1 = true;
        for (int i = 0; i < 10; i++)
        {
            flag = true;
            stack[i] = new NodeStack<float>();
            stack[i].Push(GetRandom());
            stack[i].Push(GetRandom());
            stack[i].Push(GetRandom());
            stack[i].Push(GetRandom());
            firstNumber[i] = stack[i].Peek();
            list.Add(stack[i]);
            IEnumerable<float> monthQuery5 =
            from sta in stack[i]
            where sta < 0 
            select sta;
            IEnumerable<float> monthQuery6 =
            from sta in stack[i]
            where sta == 0
            select sta;
            IEnumerable<float> monthQuery7 =
            from sta in stack[i]
            where sta == 0
            select sta;
            

            foreach (float j in monthQuery5)
            { 
                if(j < 0 && flag)
                {
                    Console.WriteLine($"Cтэк - {i + 1} содержит отрицательные элементы");
                    flag = false;
                }
            }
            Console.WriteLine($"Длина стека - {stack[i].Count}");
            foreach (float j in monthQuery6)
            {
                if (flag1)
                {
                    Console.WriteLine($"Cтэк - {i + 1} первый стэк с нулевым элементом");
                    flag1 = false;
                }
            }
            
        }
        
        Console.WriteLine($"Минимальный элемент - {firstNumber.Min()}, максимальный - {firstNumber.Max()}");

        //for(int i = 0; i < 10; i++)
        //{
        //    Console.WriteLine($"{stack[i].Sum}");
        //}
        //Console.WriteLine(stack.OrderByDescending(i => i.Sum));

        //Console.WriteLine(list.Single(i => i.Peek() == list.Min(b => b.Peek())));
        //Console.WriteLine(list.Single(i => i.Peek() == list.Min().Peek()));
        IEnumerable<NodeStack<float>> monthQuery8 =
            from sta in list
            orderby sta.Sum descending
            select sta;
        float sql = monthQuery8.Where(i => i.Sum > 50).Take(4).Skip(1).Sum(x => x.Sum);
        double averageSum = monthQuery8.Average(sta => sta.Sum);
        bool sootvetstvuet = monthQuery8.All(sta => sta.Sum > -1000);
        foreach (var j in monthQuery8)
        {
            Console.WriteLine(j.Sum);
        }
        Console.WriteLine(averageSum);
        Console.WriteLine(sootvetstvuet);
        Console.WriteLine(sql);
        var personList = new List<Person>();
        personList.Add(new Person("Andrew", 0));
        personList.Add(new Person("George", 2));
        var result = from p in personList
                     join nod in list on p.Id equals nod.Average()
                     select new { nod = p.Id };
        foreach (var item in result)
        {
            Console.WriteLine(item.ToString());
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public float Id { get; set; }

        public Person()
        {
            Name = "default";
            Id = 0;
        }

        public Person(string name, float busNumber)
        {
            Id = busNumber;
            Name = name;
        }
    }

}