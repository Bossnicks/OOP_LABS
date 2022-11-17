using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab06.Exceptions
{
    public class ZooExceptions : Exception
    {
        public ZooExceptions(string message, string errorClass) : base(message)
        {
            ErrorClass = errorClass;
        }
        public string ErrorClass { get; }
    }
    //class VeryLittleNameOrAnotherType : ZooExceptions
    //{
    //    public VeryLittleNameOrAnotherType(string obj, string reasonOfProblem = "Название животного слишком короткое!",
    //        string zone = "Fish, bird or mammal")
    //    {
    //        Console.WriteLine($"{base.Message}, объект: {obj}, причина: {reasonOfProblem}, место: {zone}");
    //    }
        
    //}
    class DateOfRange : ZooExceptions
    {
        public DateOfRange(string message, string errorClass) : base(message, errorClass)
        {
        }
    }
    class VeryLittleAnimalName : ZooExceptions
    {
        public VeryLittleAnimalName(string message, string errorClass) : base(message, errorClass)
        {
        }
    }
    //class FileError : ZooExceptions
    //{
    //    public FileError(string obj, string reasonOfProblem = "Ошибка в файловой системе!",
    //        string zone = "Fish, bird or mammal")
    //    {
    //        Console.WriteLine($"{base.Message}, объект: {obj}, причина: {reasonOfProblem}, место: {zone}");
    //    }
    //}
}
