using System;
using System.Text;

namespace Lessons
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] arr = { "Яблоко", "от", "яблони", "недалеко", "падает" };
            bool rrr = true;
            int b = 1;
            while (rrr)
            {
                Console.WriteLine("Выберите задание, которое хотите увидеть (1-Task1, 2-Task2, 3-Arrs, 4-Changer, 5-Jagged, 6-Cort, 0-Exit):");
                string a = Console.ReadLine();
                b = Convert.ToInt32(a);


                switch (b)
                {
                    case 1:
                        {
                            Task1();
                            break;
                        }
                    case 2:
                        {
                            Task2();
                            break;
                        }
                    case 3:
                        {
                            Arrs();
                            break;
                        }
                    case 4:
                        {
                            Changer(arr);
                            break;
                        }
                    case 5:
                        {
                            Jagged();
                            break;
                        }
                    case 6:
                        {
                            Cort();
                            break;
                        }
                    case 7:
                        {
                            int[] numForReturner = { 45, -65, 37, 0, -8, 19 };
                            string strForReturner = "ASP.NET";
                            (int max, int min, int sum, char firstLetter) = Returner(numForReturner, strForReturner);
                            Console.WriteLine($"Максимальное значение элемента в массиве: {max}, минимальное: {min}, сумма всех элементов: {sum} \nпервая буква строки: {firstLetter}");
                            break;
                        }
                    case 0:
                        {
                            rrr = false;
                            break;
                        }
                }
            }
            //Task1();
            //Task2();
            //Arrs();
            //Changer(arr);
            //Jagged();
            //Cort();
        }
        public static void Task1()
        {
            Console.WriteLine("Введите значения типа bool:");
            bool trigger = System.Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Вот значения типа string явно преобразованное в bool:" + trigger);
            byte num1 = 57;
            Console.WriteLine("Значение типа byte:" + num1);
            sbyte num2 = 21;
            Console.WriteLine("Значение типа sbyte:" + num2);
            Console.WriteLine("Введите значения типа char:");
            char symb1 = (char)Console.Read();
            Console.WriteLine("Значение типа char:" + symb1);
            int num3 = 436278904;
            Console.WriteLine("Значение типа int:" + num3);
            decimal max = decimal.MaxValue;
            Console.WriteLine("Значение типа decimal:" + max);
            double num4 = 45384.3;
            Console.WriteLine("Значение типа double:" + num4);
            System.Int32 num5 = -234;
            Console.WriteLine("Значение типа int:" + num5);
            System.UInt32 num6 = 47237;
            Console.WriteLine("Значение типа uint:" + num6);
            nint num7 = nint.MinValue;
            nuint num8 = nuint.MaxValue;
            long num9 = long.MaxValue;
            ulong num10 = ulong.MinValue;
            short num11 = short.MaxValue;
            ushort num12 = ushort.MinValue;
            object setOfNumbers = (object)5432;
            string str = 2345.ToString();
            Console.WriteLine("Значение типа nint {0} и nuint {1}:", num7, num8);
            Console.WriteLine("Значение типа long:" + num9);
            Console.WriteLine("Значение типа ulong:" + num10);
            Console.WriteLine("Значение типа short:" + num11);
            Console.WriteLine("Значение типа ushort:" + num12);
            Console.WriteLine("Пример объекта:" + setOfNumbers);
            Console.WriteLine("Пример строки:" + str);
            Console.WriteLine("Пример упаковки и распаковки:");
            object o = num5;     // boxing
            int j = (int)o;   // unboxing
            var i = 5;
            var i2 = i + '0';
            Console.WriteLine("{0}      {1}        {2}", i, i2, i2.GetType());
            int? n = null;
            Console.WriteLine(n);
            if (n == null)
            {
                Console.WriteLine("Здесь должен был быть нулевой тип");
            }
        }
        public static void Task2()
        {
            string sent1 = "C# - объектно-ориентированный язык";
            string sent2 = "Java - тоже объектно-ориентированный язык";
            string sent3 = "А вот JavaScript применяет в основном функциональный подход";
            int result = string.Compare(sent1, sent2);
            string sent4 = string.Concat(sent3, ".");
            string sent5 = string.Copy(sent4);
            string sent6 = sent5.Substring(sent5.Length - 1);
            string[] words = sent2.Split(' ');
            sent3 = sent3.Insert(5, ",к примеру,");
            sent2 = sent2.Remove(sent2.Length - 5);
            string sent7 = $"{sent1} {sent4}";
            Console.WriteLine(sent7);
            string sent8 = "", sent9 = null, sent10 = " ";
            String Test(string s)
            {
                if (String.IsNullOrEmpty(s))
                    return "is null or empty";
                else
                    return String.Format("(\"{0}\") is neither null nor empty", s);
            }
            Console.WriteLine("String sent8 {0}.", Test(sent8));
            Console.WriteLine("String sent9 {0}.", Test(sent9));
            Console.WriteLine("String sent10 {0}.", Test(sent10));
            string sent11 = string.Concat(sent8, sent9);
            Console.WriteLine("String sent11 {0}.", Test(sent11));
            StringBuilder sb = new StringBuilder("ABC", 50);
            sb.Append(new char[] { 'D', 'E', 'F' });
            sb.AppendFormat("GHI{0}{1}", 'J', 'k');
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());
            sb.Insert(0, "Alphabet: ");
            sb.Replace('k', 'K');
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());
            sb.Remove(5, sb.Length - 10);
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());
            sb.Insert(sb.Length, "LMNOP");
            Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());
        }
        static void Changer(string[] arr)
        {
            int maxForChecker = int.MaxValue;
            try
            {
                checked
                {
                    maxForChecker++;
                }
            }
            catch(OverflowException e) {
                Console.WriteLine(e.Message);
            }
            Console.Write("Введите значнение, которое хотите изменить и новое значение:");
            string word = Console.ReadLine();
            string newWord = Console.ReadLine();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == word)
                {
                    arr[i] = newWord;
                }
            }
            Console.WriteLine("Массив с изменённым значением:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("\n");
        }
        static void Jagged()
        {
            int[][] jagged = new int[3][];
            jagged[0] = new int[2];
            jagged[1] = new int[3];
            jagged[2] = new int[4];
            Console.WriteLine("Введите значения для ступенчатого массива:");
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.Write("\n");
            }
        }
        static void Arrs()
        {
            Random rand = new Random();
            int[,] multiDimensionalArray1 = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    multiDimensionalArray1[i, j] = rand.Next(1, 15);
                    Console.Write(multiDimensionalArray1[i, j] + "  ");
                    //Console.WriteLine();
                }
                Console.Write("\n");
            }
            string[] arr = { "Яблоко", "от", "яблони", "недалеко", "падает" };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("\n");
            Console.WriteLine($"Длина массива равна {arr.Length}");
        }
        static void Cort()
        {
            (int number, string stroka1, char symbol, string stroka2, ulong bigNumber) t =
                (27, "Россия", 'R', "Cat", 446744073);
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите позицию элемента, который вы хотите вывести в консоль из кортежа(если хотите закончит, введите 0):");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //t.number = Console.Read();
                        Console.WriteLine(t.number);
                        break;
                    case 2:
                        //t.stroka1 = Console.ReadLine();
                        Console.WriteLine(t.stroka1);
                        break;
                    case 3:
                        //t.symbol = Console.ReadKey().KeyChar;
                        Console.WriteLine(t.symbol);
                        break;
                    case 4:
                        //t.stroka2 = Console.ReadLine();
                        Console.WriteLine(t.stroka2);
                        break;
                    case 5:
                        //t.bigNumber = UInt64.Parse(Console.ReadLine());
                        Console.WriteLine(t.bigNumber);
                        break;
                    case 0:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Неверное значение!");
                        break;
                }
            }
            (int number, string stroka1, char symbol, string stroka2, ulong bigNumber) = t;
            var (numb, stro, _, _, bigNumb) = t;
            (short, string, char, string, ulong) un = (27, "Россия", 'R', "Cat", 446744073);
            var array = new object[2];
            var str = "";
            str = stro;
            array[0] = numb;
            array[1] = bigNumb;
            Console.WriteLine(un == t);
        }
        static (int max, int min, int sum, char firstLetter) Returner(int[] arr, string str)
        {
            int minimum = int.MaxValue;
            int maximum = int.MinValue;
            int maxForChecker = int.MaxValue;
            unchecked
            {
                maxForChecker++;
            }
            int sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < minimum) minimum = arr[i];
                if(arr[i] > maximum) maximum = arr[i];
                sum += arr[i];
            }
            
            return (maximum, minimum, sum, str[0]);
        }
    }
}