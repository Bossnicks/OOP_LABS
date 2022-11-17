using System;

namespace lab05
{
    interface IClonable
    {
        public void Stastic();
    }
    public abstract class Animal
    {
        public abstract void Move();
        public string? Name { get; set; }
        public virtual void virVoid()
        {
            Console.WriteLine("Результат работы виртуальной функции");
        }
    }
    sealed class Fish : Animal, IClonable
    {
        static int countOfLev, countOfTiger;
        public Fish (string fish)
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
        void IClonable.Stastic() { }
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
            Name=birds;
        }
        public int CountOfOwl
        {
            get { return countOfOwl; }
        }
        public int CountOfParr
        {
            get { return countOfParr; }
        }
        void IClonable.Stastic() { }
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
        void IClonable.Stastic() { }
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
    public class Printer
    {
        public void IAmPrinting(int item)
        {
            Console.WriteLine(item.ToString());

        }
    }

    class Program
    {
        private static void Main(string[] args)
        {
            Fish fish1 = new Fish("Акула");
            Fish fish2 = new Fish("Крокодил");
            Fish fish3 = new Fish("Акула");
            Fish fish4 = new Fish("Акула");
            Fish fish5 = new Fish("Крокодил");
            Birds bird1 = new Birds("Сова");
            Birds bird2 = new Birds("Попугай");
            Birds bird3 = new Birds("Сова");
            Mammals mammal1 = new Mammals("Лев");
            Mammals mammal2 = new Mammals("Тигр");
            Mammals mammal3 = new Mammals("Лев");
            Mammals mammal4 = new Mammals("Тигр");
            fish1.DoClony();
            bird1.DoClony();
            mammal1.DoClony();
            fish2.Move();
            mammal2.Move();
            bird2.Move();
            fish3.virVoid();
            mammal3.virVoid();
            bird3.virVoid();
            bool x = fish4 is Animal;
            Console.WriteLine(x);
            Console.WriteLine(bird2.ToString());
            Console.WriteLine(fish2.ToString());
            Console.WriteLine(mammal4.ToString());
            Console.WriteLine(mammal3.GetHashCode());
            Console.WriteLine(mammal3.Equals(mammal3));
            var bir = new Birds("Тукан");
            var fis = new Fish("Окунь");
            var mam = new Mammals("Заяц");
            var anima = new Animal[3];
            var pri = new Printer();
            anima[0] = bir;
            anima[1] = fis;
            anima[2] = mam;
            foreach(var item in anima)
            {
                pri.IAmPrinting(item);
            }
        }
    }
}