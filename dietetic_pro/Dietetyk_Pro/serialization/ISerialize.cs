using System.Collections.Generic;


namespace DietetykPro.serialization
{
    public interface ISerialize<T>
    {

        public void Serialize(List<T> list);

        public List<T> Deserialize();

    }
}
