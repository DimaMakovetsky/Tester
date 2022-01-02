using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenerator
{
    public class Classes
    {
        public string Name { get; private set; }

        public List<Constructors> Constructors { get; private set; }

        public List<Methods> Methods { get; private set; }

        public Classes(string name, List<Constructors> constructors, List<Methods> methods)
        {
            Name = name;
            Constructors = constructors;
            Methods = methods;
        }
    }
}
