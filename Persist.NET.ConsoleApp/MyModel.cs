using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persist.NET.ConsoleApp
{
    public class MyModel
    {
        public string AString { get; set; }
        public int AInt { get; set; }
        public double ADouble { get; set; }

        public MyModel(string aString, int aInt, double aDouble)
        {
            AString = aString;
            AInt = aInt;
            ADouble = aDouble;
        }
    }
}
