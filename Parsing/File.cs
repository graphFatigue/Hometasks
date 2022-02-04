using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public abstract class File
    {
        public string Extension { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }
    }
}
