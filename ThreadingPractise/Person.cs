using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingPractise
{
    class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
        public static bool CheckCity(string name)
        {
            if (name == "")
                throw new ArgumentException(name);
            return name == "Seattle";
        }
    }
}
