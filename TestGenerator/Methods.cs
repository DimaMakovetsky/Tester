using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenerator
{
    public class Methods
    {
        public string Name { get; private set; }

        public Dictionary<string, string> Parameters { get; private set; }

        public string ReturnValueType { get; private set; }

        public Methods(string name, Dictionary<string, string> parametersMap, string returnType)
        {
            Name = name;
            Parameters = parametersMap;
            ReturnValueType = returnType;
        }
    }
}
