using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deleg
{
    public class GenericClass<T>
    {
        private Method1<T> Delegat { get; }
        public GenericClass(Method1<T> delegat)
        {
            Delegat = delegat;
        }
        public void Execute(T param)
        {
            Delegat?.Invoke(param);
        }
    }
}