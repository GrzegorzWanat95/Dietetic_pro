using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace DietetykPro.serialization.impl
{
    public class XmlSerializer<T> : ISerialize<T>
    {
        private string _path;
       // private XmlSerializer _serializer;

        public XmlSerializer(string path)
        {
            _path = path;
           // _serializer = new XmlSerializer(typeof(List<T>));
        }

        public void Serialize(List<T> list)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            try
            {
                using TextWriter tw = new StreamWriter(_path);
                //serializer.Serialize(tw, _path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("XML Serialization failed!");
                return;
            }
        }

        public List<T> Deserialize()
        {
            Console.WriteLine("XML Deserialization start");
            XmlSerializer deserializer = new XmlSerializer(typeof(List<T>));
            List<T> result = null;

            try
            {
                using TextReader tr = new StreamReader(_path);
                var obj = deserializer.Deserialize(tr);
                if (obj is List<T>)
                {
                    result = (List<T>)obj;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("XML Deserialization failed!");
                return null;
            }

            Console.WriteLine("XML Deserialization finished");
            return result;
        }

       
    }
}
