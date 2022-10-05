using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections;

namespace SimpleAlgorithmsApp
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using global::SimpleAlgorithmsApp.SimpleAlgorithmsApp;
    using System.Data.Common;

    namespace SimpleAlgorithmsApp
    {
        
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
                if(fl < 0)
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            NodeStack<float> [] stack = new NodeStack<float>[3];
            bool flagForTime = true;
            for (int i = 0; i < 3; i++)
            {
                bool flag = true;
                Console.WriteLine($"Заполните {i + 1}-ый стек:");
                while (flag) {
                    stack[i] = new NodeStack<float>();
                    if (flagForTime)
                    {
                        Console.WriteLine($"Вариант лабораторной: {stack[i].Variant}; Текущее время: {stack[i].BaseLine}");
                        flagForTime = false;
                    }
                    Console.WriteLine("Введите элемент:");
                    float elementOfStack = float.Parse(Console.ReadLine());
                    if (stack[i].Changer(ref i, elementOfStack) != -1)
                    {
                        Console.WriteLine($"Стек с номером {stack[i].identifier + 1} теперь имеет отрицательный элемент");
                    }
                    stack[i].Push(elementOfStack);
                    Console.WriteLine("Хотите ввести ещё элемент\n(Введите 1 если да и 0 если нет):");
                    int x = int.Parse(Console.ReadLine());
                    flag = x == 1 ?  true : false;                     
                }
            }
            int maxMean = 0, minMean = 0;
            float max = float.MaxValue;
            float min = float.MinValue;
            for (int i = 0; i < 3; i++)
            {
                if(stack[i].Peek() > min)
                {
                    min = stack[i].Peek();
                    maxMean = i;
                }
                if (stack[i].Peek() < max)
                {
                    max = stack[i].Peek();
                    minMean = i;
                }
            }
            Console.WriteLine($"Номер стека с наибольшим верхним элементом: {maxMean + 1}, с наименьшим: {minMean + 1}");
            var user = new { Name = "Tom", Age = 34 };//анонимный тип
            Console.WriteLine($"{user.Name}, {user.Age} года");
