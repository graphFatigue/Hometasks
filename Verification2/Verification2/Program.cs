using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Verification2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assembly asm1 = Assembly.LoadFrom("Education_dotNet_Reflection_interface.dll");
            Assembly asm = Assembly.LoadFrom("Education_dotNet_Reflection_classes.dll");


            asm.CreateExampleOfInterface();

        }
    }
}
