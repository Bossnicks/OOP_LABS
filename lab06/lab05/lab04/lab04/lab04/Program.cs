using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using lab06.Exceptions;
using System.Text;

namespace lab05
{



    interface IClonable
    {
        public void Stastic();
    }

    struct Clocks
    {
        public Clocks(int hours)
        {
            DayTime dayTime = new DayTime();
            if (hours >= 6 && hours < 12) { dayTime = DayTime.Morning; }
            if (hours >= 12 && hours < 18) { dayTime = DayTime.Afternoon; }
            if (hours >= 18 && hours <= 23) { dayTime = DayTime.Evening; }
            if (hours >= 0 && hours < 12) { dayTime = DayTime.Night; }
            switch ((int)dayTime)
            {
                case 0:
                    {
                        Console.WriteLine("Доброе утро!");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Добрый день!");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Добрый вечер!");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Доброй ночи!");
                        break;
                    }
            }
        }
    }
    public partial class Zoo
    {
        public List<Animal>? AnimalList { get; set; }
        public Zoo()
        {
            AnimalList = new List<Animal>();
        }

        public Zoo(int budget)
        {
            AnimalList = new List<Animal>();
        }
        public Zoo(params Animal[] animals)
        {
            var animalList = animals.ToList();
            int countOfFish = 0;
            int countOfHishnihBirds = 0;
            float sumWeightOfFish = 0;
            float averageWeightOfFish = 0;
            foreach (var animal in animalList)
            {
                if (typeof(Fish) == animal.GetType())
                {
                    sumWeightOfFish += animal.Weight;
                    countOfFish++;
                }
                if (typeof(Birds) == animal.GetType() && animal.Hishnaya == true)
                {
                    countOfHishnihBirds++;
                }
            }
            foreach (var animal in animalList)
            {
                Console.WriteLine(animal.Name);
            }
            averageWeightOfFish = sumWeightOfFish / countOfFish;
            Console.WriteLine($"Средний вес рыб в зоопарке: {averageWeightOfFish}");
            Console.WriteLine($"Количество хищных птиц: {countOfHishnihBirds}");
            AnimalList = animalList;
        }

    }
    enum DayTime
    {
        Morning,
        Afternoon,
        Evening,
        Night
    }
    public abstract class Animal
    {

        public abstract void Move();
        public string? Name { get; set; }
        public virtual void virVoid()
        {
            Console.WriteLine("Результат работы виртуальной функции");
        }
        public int Birth { get; set; }
        public int Weight { get; set; }
        public int Num { get; set; }
        public bool Hishnaya { get; set; }
    }
    
    sealed class Fish : Animal, IClonable
    {
        static int countOfLev, countOfTiger;

        public Fish(string fish)
        {
 
                //if (fish.Length < 2)
                //{
                //    throw new VeryLittleNameOrAnotherType("Название животного слишком маленькое!!!\nВведите большее название:", "Zoo");
                //}
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
        public Fish(string fish, int birth, int weight, int num)
        {
            
            DateOnly dateOnly = new DateOnly();
            if (birth > dateOnly.Year)
                throw new DateOfRange("Некорректная дата", "Fish");
            if (fish.Length <= 2)
                throw new VeryLittleAnimalName("Fish name can't be so little", "Fish");
            if (fish == "Eagle")
                throw new ZooExceptions("Fish can't be named as Eagle", "Fish");
            Name = fish;
            Birth = birth;
            Weight = weight;
            Num = num;
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
            Name = birds;
        }
        public Birds(string bird, int birth, int weight, int num)
        {
            Name = bird;
            Birth = birth;
            Weight = weight;
            Num = num;
        }
        public Birds(string bird, int birth, int weight, int num, bool hishnaya)
        {
            Hishnaya = hishnaya;
            Name = bird;
            Birth = birth;
            Weight = weight;
            Num = num;
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
            //if(mammal == "О")
            //{
            //    throw new VeryLittleNameOrAnotherType("Рыба не является млекопитающим!");
            //}
            //if(mammal.Length < 2)
            //{
            //    throw new VeryLittleNameOrAnotherType("Слишком короткое название животного!");
            //}
        }
        public Mammals(string mammal, int birth, int weight, int num)
        {
            Name = mammal;
            Birth = birth;
            Weight = weight;
            Num = num;
            //var vlnoat = new VeryLittleNameOrAnotherType(Name);
            //Name = vlnoat.vlnoatS;
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
        public void IAmPrinting(Animal item)
        {
            Console.WriteLine(item.ToString());

        }
    }

    public class Controller
    {
        public List<Animal> FindItemsByBirthRange(Zoo zoo, int minBirth, int maxBirth)
        {
            return zoo.AnimalList.FindAll(x => x.Birth <= maxBirth && x.Birth >= minBirth);
        }
        /*1.  Добавьте  в  класс-контроллер  метод,  считывающий  построчно текстовый файл, в котором хранятся данные вашего класса и инициализирует таким образом коллекцию.*/
        public void CreateZooFromTextFile(Zoo zoo)
        {
            StreamReader stream; 
            //try
            //{
            //    stream = new StreamReader(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab05\lab04\lab04\lab04\datta.txt");
            //}
            //catch(FileNotFoundException e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //finally
            //{
            stream = new StreamReader(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab05\lab04\lab04\lab04\data.txt");
            //}
            while (stream.ReadLine() is string line)
                switch (line)
                {
                    case "Fish":
                        zoo.Add(new Fish("Окунь", 2019, 2, 100));
                        break;
                    case "Bird":
                        zoo.Add(new Birds("Орёл", 2020, 5, 10, true));
                        break;
                    case "Mammal":
                        zoo.Add(new Mammals("Корова", 2021, 100, 10));
                        break;
                }
        }

        /*2. Реализуйте еще один метод, который будет считывать данные из json файла и инициализировать коллекцию*/
        //public void CreateGymFromJSONFile(Zoo zoo)
        //{
        //    //нужно правильно оформить Json файл - смотрите Data.json
        //    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        //    using var stream = new StreamReader(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab05\lab04\lab04\lab04\Data.json");
        //    string JsonData = stream.ReadToEnd();
        //    var deserializedList = JsonConvert.DeserializeObject<List<Inventory>>(JsonData, settings);
        //    foreach (var item in deserializedList) zoo.Add(item);
        //}


        class Program
        {
            private static void Main(string[] args)
            {
                TimeOnly time = new TimeOnly();
                time = time.AddHours(-4);
                int hours = time.Hour;
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
                Fish? fish6;
                string fisher;
                int fisherDate;
                foreach (var item in anima)
                {
                    pri.IAmPrinting(item);
                }
                try 
                {
                    
                        fish6 = new Fish("Awdw", 2000000, 100, 100);
                }
                catch (DateOfRange e)
                {
                     Console.WriteLine($"{e.Message}, ErrorClass - {e.ErrorClass}");
                }
                try
                {
                    fish6 = new Fish("A", 2015, 100, 100);
                }
                catch (VeryLittleAnimalName e)
                {
                     Console.WriteLine($"{e.Message}, ErrorClass - {e.ErrorClass}");
                }
                try
                {
                    fish6 = new Fish("Eagle", 2015, 100, 100);
                }
                catch (ZooExceptions e)
                {
                        Console.WriteLine($"{e.Message}");
                }
                
                FileStream? fstream = null;
                                            
                try
                {
                    fstream = new FileStream("data.txt", FileMode.Open);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    fstream?.Close();
                    Console.WriteLine("Finally");
                    fish6 = null;
                }
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}



                Clocks clocks = new Clocks(hours);
                var firstBird = new Birds("Журавль", 2020, 15, 40, true);
                var firstFish = new Fish("Акула", 2017, 150, 10);
                var firstMammal = new Mammals("Ирбис", 2018, 80, 5);
                var secondBird = new Birds("Гасторнис", 2021, 12, 100);
                var secondFish = new Fish("Косатка", 2015, 300, 5);
                var secondMammal = new Mammals("Белый медведь", 2015, 200, 7);
                var thirdBird = new Birds("Аист", 2019, 18, 10, true);
                var thirdFish = new Fish("Скат", 2018, 70, 5);
                var thirdMammal = new Mammals("Сkj", 2014, 12000, 3);
                var zoo = new Zoo(firstBird, secondBird,
                    firstFish, secondFish, fish6,
                    firstMammal, secondMammal, thirdMammal);
                zoo.PrintAnimalList();
                zoo.Add(thirdBird);
                zoo.Delete(firstFish);
                Console.WriteLine();
                var controller = new Controller();
                controller.FindItemsByBirthRange(zoo, 2017, 2019);
                controller.CreateZooFromTextFile(zoo);
                zoo.PrintAnimalList();
                //Debug.Assert(false);
            }
        }
    }
}