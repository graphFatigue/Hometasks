using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deleg
{
    public delegate void Method1<T>(T arg1);
    public delegate T Method2<T>(int arg1, T arg2);
    public delegate double Method3(int arg1, int arg2);
    public class Program
    {
        static void Main(string[] args)
        {
            int arg1 = 1;
            string arg2 = "World";
            Method1<int> magic;
            magic = MagicImplementation1;
            Method2<string> magic2;
            magic2 = MagicImplementation2;

            magic?.Invoke(arg1);
            magic2?.Invoke(arg1, arg2);

            Method3 formula = (int a, int b) => (a + b) / ((a + b) / 2);

            string[] words = { "orange", "a", "Article", "elephant", "star", "and" };

            Func<string, int, bool> predicate = (str, index) => str.Length == index;
            Func<string, string> selector = str => str.ToUpper();

            IEnumerable<string> Filter(Func<string, int, bool> pr, Func<string, string> sel)
            {
                IEnumerable<string> aWords = words.Where(pr);
                IEnumerable<string> bWords = aWords.Select(sel);
                return bWords;
            }

            var squares = Filter(predicate, selector);

            foreach (string str in squares)
                Console.WriteLine(str);
        }

        public static void MagicImplementation1(int arg1) { }
        public static string MagicImplementation2(int arg1, string arg2)
        {
            return "Hello " + arg2;
        }
    }
}
