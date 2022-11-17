using System;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using serial;
using classes;
public class Program
{
    public static void Main()
    {
        Fish fish = new Fish("Акула");
        Fish containerForBinary = new Fish();
        Serializer.SerializeToBinary(fish);
        Serializer.DeserializeFromBinary(ref containerForBinary);
        Console.WriteLine($"(from .bin) {containerForBinary.ToString()} {containerForBinary.FieldToBeNotSeriazable}");
        //Fish containerForSOAP = new Fish();
        //Serializer.SerializeToSoap(fish);
        //Serializer.DeserializeFromSoap(ref containerForSOAP);
        //Console.WriteLine($"(from .soap) {containerForSOAP.ToString()} {containerForSOAP.FieldToBeNotSeriazable}");
        Fish containerForXML = new Fish();
        Serializer.SerializeToXml(fish);
        Serializer.DeserializefromXml(ref containerForXML);
        Console.WriteLine($"(from .xml) {containerForXML.ToString()} {containerForXML.FieldToBeNotSeriazable}");
        Fish containerForJSON = new Fish();
        Serializer.SerializeToJson(fish);
        Serializer.DeserializeFromJson(ref containerForJSON);
        Console.WriteLine($"(from .json) {containerForJSON.ToString()} {containerForJSON.FieldToBeNotSeriazable}");
        
        //-------------------------

        var animals = new List<Animal>();
        var animalsFromFile = new List<Animal>();

        var firstanimal = new Fish("Немо");
        var secondanimal = new Birds("Чайка");
        var thirdanimal = new Mammals("Корова");

        animalsFromFile.Add(firstanimal);
        animalsFromFile.Add(secondanimal);
        animalsFromFile.Add(thirdanimal);

        Serializer.SerializeToJson(animals);
        Serializer.DeserializeFromJson(ref animalsFromFile);
        foreach (var animal in animalsFromFile)
        {
            Console.WriteLine(animal.ToString());
        }

        //-----------------------------

        XmlDocument xml = new XmlDocument();
        xml.Load(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab13\ConsoleApp1\ConsoleApp1\XML.xml");
        var xRoot = xml.DocumentElement;
        var selectNodes = xRoot?.SelectNodes("*");
        foreach (object node in selectNodes) Console.WriteLine((node as XmlNode).Name);

        Console.WriteLine();
        var nameNodes = xRoot?.SelectNodes("Name");
        foreach (object nameNode in nameNodes) Console.WriteLine((nameNode as XmlNode).InnerText);

        //-----------------------------

        XDocument xDoc = new XDocument();
        XElement root = new XElement("Сотрудники");
        XElement employee;
        XElement name;
        XAttribute birthyear;
        employee = new XElement("employee");
        name = new XElement("name");
        name.Value = "Андрей";
        birthyear = new XAttribute("birthyear", 1989);
        employee.Add(name, birthyear);
        root.Add(employee);

        employee = new XElement("child");
        name = new XElement("name");
        name.Value = "Наташа";
        birthyear = new XAttribute("year", "1995");
        employee.Add(name);
        employee.Add(birthyear);
        root.Add(employee);

        xDoc.Add(root);
        xDoc.Save(@"C:\\Users\\HP\\Флешка\\ООП\\1 СЕМЕСТР\\lab13\\ConsoleApp1\\ConsoleApp1\\NewXML.xml");

        Console.WriteLine("Inter the year for searching: ");
        string yearXML = Console.ReadLine();
        var allAlbums = root.Elements("employee");
        foreach (var item in allAlbums)
        {
            if (item.Attribute("birthyear").Value == yearXML)
            {
                Console.WriteLine(item.Value);
            }
        }

    }
}