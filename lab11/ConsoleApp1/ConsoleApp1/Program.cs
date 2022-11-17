using System;
using System.Reflection;
using lab09;
using lab05;
using System.Security.Cryptography.X509Certificates;

namespace lab12
{
    public class Program
    {
        public static void Main()
        {
            Reflector.WriteAssemblyName("lab12.Reflector");
            Reflector.WriteIsAnyPublicConstruction("lab12.Reflector");
            Reflector.WritePublicMethods("lab12.Reflector");
            Reflector.WriteMethodsWithUserParametr("lab12.Reflector", "currentClassName");
            Reflector.Invoke("lab12.Multiple", "Mult");


            Reflector.WriteAssemblyName("lab05.Controller");
            Reflector.WriteIsAnyPublicConstruction("lab05.Controller");
            Reflector.WritePublicMethods("lab05.Controller");
            Reflector.WriteMethodsWithUserParametr("lab05.Controller", "zoo");

            Reflector.WriteAssemblyName("lab09.MyCollection<T>");
            Reflector.WriteIsAnyPublicConstruction("lab09.MyCollection<T>");
            Reflector.WritePublicMethods("lab09.MyCollection<T>");
            Reflector.WriteMethodsWithUserParametr("lab09.MyCollection<T>", "item");

            Reflector.WriteAssemblyName("System.Exception");
            Reflector.WriteIsAnyPublicConstruction("System.Exception");
            Reflector.WritePublicMethods("System.Exception");
            Reflector.WriteMethodsWithUserParametr("System.Exception", "");

            var sum = Reflector.Create("lab12.Multiple");
            Console.WriteLine(sum is Multiple);

        }
        static void ClearFile()
        {
            var fileForInfortmation = new StreamWriter(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab11\ConsoleApp1\ConsoleApp1\Reflection.txt", false);

            fileForInfortmation.Close();
        }
    }
    public class Multiple
    {
        public int Mult(int a, int b)
        {
            return a + b;
        }
    }
}

