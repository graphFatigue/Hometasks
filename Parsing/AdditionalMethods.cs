using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    static class AdditionalMethods
    {
        public static int MinArray(this int[] array)
        {
            array = array.Where(num => num != -1).ToArray();
            if (array.Length == 0) return 0;
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[0])
                {
                    min = array[i];
                }
            }
            return min;
        }

        public static void Dry (this string inputString, ref int pos, ref File[] listOfFiles)
        {
            string movie = "Movie";
            string image = "Image";
            string text = "Text";
            int position = inputString.IndexOf(":");
            string type = inputString.Substring(0, position);
            inputString = inputString.Substring(position);
            if (type == text)
            {
                pos = inputString.IndexOf("txt");
            }
            else if (type == movie)
            {
                pos = inputString.IndexOf("mkv");
            }
            else if (type == image)
            {
                pos = inputString.IndexOf("bmp");
            }
            string name = inputString.Substring(1, pos - 2).Replace(" ", "");
            int openBracket = inputString.IndexOf("(") + 1;
            int closeBracket = inputString.IndexOf(")");
            int localLength = closeBracket - openBracket;
            string size = inputString.Substring(openBracket, localLength);
            int[] wordsIndexes = new int[3];
            wordsIndexes[0] = inputString.IndexOf(text);
            wordsIndexes[1] = inputString.IndexOf(movie);
            wordsIndexes[2] = inputString.IndexOf(image);
            pos = wordsIndexes.MinArray() != 0 ? wordsIndexes.MinArray() : inputString.Length;
            if (type == text)
            {
                localLength = pos - inputString.IndexOf(";");
                string content = inputString.Substring(inputString.IndexOf(";") + 2, localLength - 3);
                Text text1 = new Text(name, size, "txt", content);
                Array.Resize(ref listOfFiles, listOfFiles.Length + 1);
                listOfFiles[listOfFiles.Length - 1] = text1;
            }
            else if (type == movie)
            {
                inputString = inputString.Substring(inputString.IndexOf(";") + 1);
                pos = wordsIndexes.MinArray() != 0 ? wordsIndexes.MinArray() : inputString.Length;
                string resolution = inputString.Substring(1, 9);
                string length = inputString.Substring(inputString.IndexOf(";") + 2, pos- inputString.IndexOf(";") - 2);
                Movie movie1 = new Movie(name, size, "mkv", resolution, length);
                Array.Resize(ref listOfFiles, listOfFiles.Length + 1);
                listOfFiles[listOfFiles.Length - 1] = movie1;

            }
            else if (type == image)
            {
                string resolution = inputString.Substring(inputString.IndexOf(";") + 2, 9);
                Image image1 = new Image(name, size, "bmp", resolution);
                Array.Resize(ref listOfFiles, listOfFiles.Length + 1);
                listOfFiles[listOfFiles.Length - 1] = image1;
            }
            pos += type.Length;
        }
    }
}
