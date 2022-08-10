using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsGenerator
{
    public class Set
    {
        public Set()
        {
            ElementNames = new List<string>();
        }
        public string SetName { get; set; }
        public  List<string> ElementNames { get; set; }
    }
}
