using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class Image: File
    {
        public string Resolution { get; set; }
        public Image(string name, string size, string extension, string resolution)
        {
            Size = size;
            Extension = extension;
            Resolution = resolution;
            Name = name;
        }
    }
}
