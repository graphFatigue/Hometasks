using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class Movie: File
    {
        public string Resolution { get; set; }
        public string Length { get; set; }
        public Movie(string name, string size, string extension, string resolution, string length)
        {
            Name = name;
            Size = size;
            Extension = extension;
            Resolution = resolution;
            Length = length;
        }
    }
}
