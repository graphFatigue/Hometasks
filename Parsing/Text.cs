using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class Text: File
    {
        public string Content { get; set; }
        public Text(string name, string size, string extension, string content)
        {
            Size = size;
            Extension = extension;
            Content = content;
            Name = name;
        }
    }
}
