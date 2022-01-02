using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenerator
{
    public class Constructors
    {
        public string Name { get; private set; }

        public Dictionary<string, string> Parameters { get; private set; }

        public Constructors(string name, Dictionary<string, string> parametersMap)
        {
            Name = name;
            Parameters = parametersMap;
        }
    }
}
