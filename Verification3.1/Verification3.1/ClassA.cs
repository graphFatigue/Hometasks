using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Verification3._1
{
    [Serializable]
    public class ClassA
    {
        public int Count;

        public decimal Price;

        [NonSerialized]
        public decimal TotalPrice;

        public ClassA(int count, decimal price)
        {
            this.Count = count;
            this.Price = price;

            this.TotalPrice = count * price;
        }

        public MemoryStream Serialize(Object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(ms, obj);

            return ms;
        }

        public Object Deserialize(Stream st)
        {
            ClassA obj;
            BinaryFormatter formatter = new BinaryFormatter();

            obj = (ClassA)formatter.Deserialize(st);
            obj.TotalPrice = obj.Count * obj.Price;

            return obj;
        }
    }
}
