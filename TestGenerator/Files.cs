using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenerator
{
    class Files
    {
        public List<ClassData> Classes { get; private set; }

        public Files(List<ClassData> classes)
        {
            Classes = classes;
        }
    }
}
