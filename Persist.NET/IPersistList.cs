using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.NET
{
    interface IPersistList
    {
        string Path { get; set; }
        PersistFormat Format { get; set; }
        void Save();
    }
}
