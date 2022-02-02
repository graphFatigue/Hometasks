using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    class Program
    {
        public static File[] MethodParse(string inputString)
        {
            int counter = 0;
            char[] CH = inputString.ToCharArray();
            for (int i = 0; i < inputString.Length; i++)
            {
                if (CH[i] == ':')
                {
                    counter++;
                }
            }
            int iterations = 0;
            File[] ListOfFiles = new File[] { };
            while (iterations < counter)
            {
                int pos = 0;
                inputString.Dry(ref pos, ref ListOfFiles);
                iterations++;
                inputString = inputString.Substring(pos);
            }
            return ListOfFiles;
        }
        static void Main(string[] args)
        {
            string text = "Text: file.txt(6B); Some string conten Image: img.bmp(19MB); 1920х1080 Text:data.txt(12B); Another string Text:data1.txt(7B); Yet another string Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";
            MethodParse(text);
        }
    }
}
