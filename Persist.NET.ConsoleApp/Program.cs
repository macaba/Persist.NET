using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persist.NET.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string datastoreDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            PersistList<MyModel> listA = new PersistList<MyModel>(datastoreDirectory, "listA", PersistFormat.PrettyJSON);
            listA.Add(new MyModel("Hello", 1, 1.1));
            listA.Add(new MyModel("World", 2, 2.2));
            listA.Save();
        }
    }
}
