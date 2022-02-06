using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Verification2
{
    static class AdditionalMethods
    {
        public static bool Contain(this Type[] list, string str)
        {
            foreach (var item in list)
            {
                string name = item.Name;
                if (Equals(name, str))
                {
                    return true;
                }
            }
            return false;
        }
        public static void CreateExampleOfInterface(this Assembly asm)
        {
            Console.WriteLine(asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t.Name);
            }

            Type type;
            Type[] n;
            //string result;

            type = asm.GetType("Education_dotNet_Reflection_classes.ClassA", true, true);
            n = type.GetInterfaces();
            bool flag = n.Contain("IInterface");
            //result = "ClassA";

            if (!flag)
            {

                type = asm.GetType("Education_dotNet_Reflection_classes.ClassB", true, true);
                n = type.GetInterfaces();
                //result = "ClassB";
            }

            Console.WriteLine(type);


            Console.WriteLine("Вызов интерфейса Interface");


            foreach (var item in n)
            {
                Console.WriteLine(item);
            }

            var ourClass = Activator.CreateInstance(type); 

            var prop = type.GetProperties().FirstOrDefault();
            prop.SetValue(ourClass, 32);

            MethodInfo[] met = type.GetMethods();
            foreach (MethodInfo mi in met)
            {
                Console.WriteLine(mi);
            }

            var method = type.GetMethod("GetNextIndex");
            Console.WriteLine(method.Invoke(ourClass, new object[] {  }));
            //Console.ReadLine();
            //return result;
        }
            
        




        }
        }
   

