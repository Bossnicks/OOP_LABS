using System;   
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.Permissions;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace serial
{
    public class Serializer
    {
        public static void SerializeToBinary<T>(T obj) where T : class
        {
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = new FileStream(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab13\ConsoleApp1\ConsoleApp1\BINARY.bin", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fileStream, obj);
            }
        }
        public static void DeserializeFromBinary<T>(ref T container) where T : class
        {
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = new FileStream(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab13\ConsoleApp1\ConsoleApp1\BINARY.bin", FileMode.OpenOrCreate))
            {
                container = binaryFormatter.Deserialize(fileStream) as T;
            }
        }

        public static void SerializeToSoap<T>(T obj) where T : class
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fileStream = new FileStream(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab13\ConsoleApp1\ConsoleApp1\SOAP.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fileStream, obj);
            }
        }
        public static void DeserializeFromSoap<T>(ref T container) where T : class
        {
            var soapFormatter = new SoapFormatter();
            using (var fileStream = new FileStream(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab13\ConsoleApp1\ConsoleApp1\SOAP.soap", FileMode.OpenOrCreate))
            {
                container = soapFormatter.Deserialize(fileStream) as T;
            }
        }

        public static void SerializeToXml<T>(T obj) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var fileStream = new FileStream(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab13\ConsoleApp1\ConsoleApp1\XML.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, obj);
            }
        }
        public static void DeserializefromXml<T>(ref T container) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var fileStream = new FileStream(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab13\ConsoleApp1\ConsoleApp1\XML.xml", FileMode.OpenOrCreate))
            {
                container = xmlSerializer.Deserialize(fileStream) as T;
            }
        }

        public static void SerializeToJson<T>(T obj) where T : class
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            string serialized = JsonConvert.SerializeObject(obj, settings);
            using (var fileStream = new StreamWriter(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab13\ConsoleApp1\ConsoleApp1\JSON.json"))
            {
                fileStream.Write(serialized);
            }

        }
        public static void DeserializeFromJson<T>(ref T container) where T : class
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            using (var fileStream = new StreamReader(@"C:\Users\HP\Флешка\ООП\1 СЕМЕСТР\lab13\ConsoleApp1\ConsoleApp1\JSON.json"))
            {
                string json = fileStream.ReadToEnd();
                container = JsonConvert.DeserializeObject<T>(json, settings);
            }
        }

    }
}
