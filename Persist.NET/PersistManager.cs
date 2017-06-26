using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.NET
{
    //Singleton class that manages background threads, collection registrations and configuration
    public sealed class PersistManager
    {
        //Singleton Pattern
        private static readonly Lazy<PersistManager> lazy = new Lazy<PersistManager>(() => new PersistManager());

        public static PersistManager Instance { get { return lazy.Value; } }

        private PersistManager()
        {
        }
        //End of Singleton Pattern

        private List<IPersistList> lists = new List<IPersistList>();


    }
}
