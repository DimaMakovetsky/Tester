using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenerator
{
    public class Files
    {
        public List<Classes> Classes { get; private set; }

        public Files(List<Classes> classes)
        {
            Classes = classes;
        }
    }
}
