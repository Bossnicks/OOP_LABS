using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab09
{
    internal class Program
    {
        public static void Main()
        {
            var myCollection = new MyCollection<Concert>();
            var enotherCollection = myCollection;
            var web = new Concert();
            var array = new Concert[5];

            myCollection.Add(new Concert("Лазарев"));
            myCollection.Add(new Concert("Big Baby Tape"));
            myCollection.Add(new Concert("Лепс"));
            myCollection.Show();
            myCollection.Insert(1, web);
            Console.WriteLine(myCollection.Contains(web));
            Console.WriteLine(myCollection.IndexOf(web));
            myCollection.Show();
            myCollection.Remove(web);
            myCollection.RemoveAt(0);
            Console.WriteLine(myCollection[0]);
            myCollection.CopyTo(array, 2);
            foreach (var i in array) Console.Write($"{i} ");
            Console.WriteLine();
            myCollection.Show();
            myCollection.Clear();
            myCollection.Show();
            Console.WriteLine(myCollection.Equals(enotherCollection));
            var universalCollection = new Dictionary<string, int>();
            var anotherCollection = new ConcurrentDictionary<string, int>();

            universalCollection.TryAdd("A", 12);
            universalCollection.TryAdd("B", 15);
            universalCollection.TryAdd("Y", 25);
            foreach (var keyValuePair in universalCollection) Console.WriteLine($"Key - {keyValuePair.Key} , Value - {keyValuePair.Value}");
            int tmp;
            universalCollection.Remove("A", out tmp);
            Console.WriteLine(tmp);
            foreach (var keyValuePair in universalCollection) anotherCollection.TryAdd(keyValuePair.Key, keyValuePair.Value);
            foreach (var keyValuePair in anotherCollection) Console.WriteLine($"Key - {keyValuePair.Key} , Value - {keyValuePair.Value}");
            Console.WriteLine(anotherCollection.ContainsKey("B"));
            Console.ForegroundColor = ConsoleColor.Magenta;
            var myCollect = new ObservableCollection<Concert>();
            myCollect.CollectionChanged += SayChange;

            myCollect.Add(new Concert("Билан"));
            myCollect.Add(new Concert("Kizaru"));
            myCollect.Add(new Concert("WRLD Juice"));

            myCollect.RemoveAt(2);
            Console.WriteLine(myCollect.Count);
        }
        private static void SayChange(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine("|Add comlete|");
            else if (e.Action == NotifyCollectionChangedAction.Remove) Console.WriteLine("|Remove complete|");
        }
    }
    public class MyCollection<T> : ICollection<T>
    {
        private T[] _content;
        public MyCollection()
        {
            Count = 0;
            _content = Array.Empty<T>();
        }
        public int Count { get; private set; }
        public bool IsReadOnly { get; }
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++) yield return _content[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (item == null)
                throw new NullReferenceException();

            var tmp = new T[Count + 1];
            _content.CopyTo(tmp, 0);
            _content = tmp;
            _content[Count] = item;
            Count++;
        }

        public void Clear()
        {
            _content = Array.Empty<T>();
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (var i = 0; i < Count; i++)
                if (Equals(_content[i], item))
                    return true;

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex < Count)
                throw new ArgumentOutOfRangeException();

            for (var i = 0; i < Count; i++) array[arrayIndex + i] = _content[i];
        }

        public bool Remove(T item)
        {
            int numIndex = Array.IndexOf(_content, item);
            if (numIndex == -1)
                return false;
            _content = _content.Where((val, idx) => idx != numIndex).ToArray();
            Count--;
            return true;
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
                if (Equals(_content[i], item))
                    return i;
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            Count++;
            var tmp = new T[Count];
            _content.CopyTo(tmp, 0);
            _content = tmp;
            for (int i = Count - 1; i > index; i--) _content[i] = _content[i - 1];

            _content[index] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 && index >= Count) throw new ArgumentOutOfRangeException();

            _content = _content.Where((val, idx) => idx != index).ToArray();
            Count--;
        }

        public T this[int index]
        {
            get => _content[index];
            set => _content[index] = value;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            foreach (var x1 in _content) Console.Write($"{x1.ToString()} ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
    public class Concert
    {
        public Concert()
        {
        }
        public Concert(string name)
        {
            Name = name;
        }
        public string Name { get; set; } = "Default";
        public override string ToString()
        {
            return Name;
        }
    }
}