using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Verification
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            string[] strings = new string[10];
            Console.WriteLine("enter data 10 times");

            for (int i = 0; i < 10; i++)
            {
                strings[i] = Console.ReadLine();
            }

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                {
                    foreach (string str in strings)
                    {
                        writer.WriteLine(str);
                    }
                }
            }

            Console.WriteLine("\nRead from file");

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(file, Encoding.Unicode))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }

            Console.ReadLine();
        }
    }
}
