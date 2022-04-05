using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DietetykPro.serialization.impl
{
    public class BinarySerializer<T> : ISerialize<T>
    {
        private string _path;

        public BinarySerializer(string path)
        {
            _path = path;
        }

        public void Serialize(List<T> list)
        {
            IFormatter formatter = new BinaryFormatter();

            try
            {
                using Stream stream = new FileStream(_path, FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Zapis zakończony niepowodzeniem");
                return;
            }
        }

        public List<T> Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            List<T> result = null;

            try
            {
                using Stream stream = new FileStream(_path, FileMode.Open, FileAccess.Read);
                var obj = formatter.Deserialize(stream);
                if (obj is List<T>)
                {
                    result = (List<T>)obj;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return result;
            }
            return result;
        }
    }
}