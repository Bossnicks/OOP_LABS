using System;

namespace classes
{
    interface IClonable
    {
        public void Stastic();
    }
    [Serializable]
    public abstract class Animal
    {
        public abstract void Move();
        public string? Name { get; set; }
        public virtual void virVoid()
        {
            Console.WriteLine("Результат работы виртуальной функции");
        }
    }
    [Serializable]
    public sealed class Fish : Animal, IClonable
    {
        [NonSerialized] public string FieldToBeNotSeriazable = "NonSerialized";
        static int countOfLev, countOfTiger;
        string fish;
        public Fish() {
            if (fish == null)
            {
                fish = "default";
                Name = fish;
            }
        }
        public Fish(string fish)
        {
            if (fish == "Акула")
            {
                countOfLev++;
            }
            else
            {
                countOfTiger++;
            }
            Name = fish;
            
        }
        public int CountOfTiger
        {
            get { return countOfTiger; }
        }
        public int CountOfLev
        {
            get { return countOfLev; }
        }
        void IClonable.Stastic() { Console.WriteLine("Это класс Fish"); }
        public void DoClony()
        {
            Console.WriteLine($"Количество рыб {countOfLev + countOfTiger}, в том числе {countOfTiger}" +
                $" крокодила и {countOfLev} акулы");
        }
        public override void Move()
        {
            Console.WriteLine("Это сообщение от класса Fish");
        }
        public override void virVoid()
        {
            Console.WriteLine("Результат работы виртуальной функции для Fish");
        }
        public override string ToString()
        {
            return $"It's a {this.GetType()} name - {this.Name}";
        }
    }
    //class A : Fish { } --- ОШИБКА
    [Serializable]
    class Birds : Animal, IClonable
    {
        static int countOfOwl, countOfParr;
        public Birds(string birds)
        {
            if (birds == "Сова")
            {
                countOfOwl++;
            }
            else
            {
                countOfParr++;
            }
            Name = birds;
        }
        public int CountOfOwl
        {
            get { return countOfOwl; }
        }
        public int CountOfParr
        {
            get { return countOfParr; }
        }
        void IClonable.Stastic() { Console.WriteLine("Это класс Birds"); }
        public void DoClony()
        {
            Console.WriteLine($"Количество птиц {countOfOwl + countOfParr}, в том числе {countOfOwl}" +
                $" сова и {countOfParr} попугай");
        }
        public override void Move()
        {
            Console.WriteLine("Это сообщение от класса Birds");
        }
        public override void virVoid()
        {
            Console.WriteLine("Результат работы виртуальной функции для Birds");
        }
        public override string ToString()
        {
            return $"It's a {this.GetType()} name - {this.Name}";
        }
    }
    [Serializable]
    class Mammals : Animal, IClonable
    {
        static int countOfLev, countOfTiger;
        public Mammals(string mammal)
        {
            if (mammal == "Лев")
            {
                countOfLev++;
            }
            else
            {
                countOfTiger++;
            }
            Name = mammal;
        }
        public int CountOfTiger
        {
            get { return countOfTiger; }
        }
        public int CountOfLev
        {
            get { return countOfLev; }
        }
        void IClonable.Stastic() { Console.WriteLine("Это класс Mammals"); }
        public void DoClony()
        {
            Console.WriteLine($"Количество млекопитающих {countOfLev + countOfTiger}, в том числе {countOfTiger}" +
                $" тигров и {countOfLev} львов");
        }
        public override void Move()
        {
            Console.WriteLine("Это сообщение от класса Mammal");
        }
        public override void virVoid()
        {
            Console.WriteLine("Результат работы виртуальной функции для Mammal");
        }
        public override string ToString()
        {
            return $"It's a {this.GetType()} name - {this.Name}";
        }
        public override bool Equals(object? obj)
        {
            return this == obj;
        }
        public override int GetHashCode()
        {
            return new Random().Next(0, 100000000);
        }
    }
    [Serializable]
    public class Printer
    {
        public void IAmPrinting(Animal item)
        {
            Console.WriteLine(item.ToString());

        }
    }
}
