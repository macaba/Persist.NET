using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Persist.NET
{
    public class PersistList<T> : IList<T>, IPersistList
    {
        private readonly IList<T> _list;

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<T>

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return _list.IsReadOnly; }
        }

        #endregion

        #region Implementation of IList<T>

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        #endregion

        #region Additional stuff

        public string Path { get; set; }
        public PersistFormat Format { get; set; }

        public PersistList(string rootFolder, string collectionName, PersistFormat format)
        {
            string extension = "";
            switch (format)
            {
                case PersistFormat.BSON:
                    extension = ".bson";
                    break;
                case PersistFormat.PrettyJSON:
                case PersistFormat.JSON:
                    extension = ".json";
                    break;
                default:
                    throw new NotImplementedException();
            }
            Path = System.IO.Path.Combine(rootFolder, "PersistList[" + typeof(T).Name + "] - " + collectionName + extension);
            Format = format;

            if (File.Exists(Path))
            {
                switch (Format)
                {
                    case PersistFormat.PrettyJSON:
                    case PersistFormat.JSON:
                        using (FileStream fileStream = new FileStream(Path, FileMode.Open))
                            _list = fileStream.DeserializeFromJSON<List<T>>();
                        break;
                    case PersistFormat.BSON:
                        using (FileStream fileStream = new FileStream(Path, FileMode.Open))
                            _list = fileStream.DeserializeFromBSON<List<T>>();
                        break;
                }
                if (_list == null)
                    _list = new List<T>();
            }
            else
            {
                _list = new List<T>();
            }
        }

        public void Save()
        {
            switch (Format)
            {
                case PersistFormat.JSON:
                    using (FileStream fileStream = new FileStream(Path, FileMode.Create))
                        fileStream.SerializeToJSON(_list);
                    break;
                case PersistFormat.BSON:
                    using (FileStream fileStream = new FileStream(Path, FileMode.Create))
                        fileStream.SerializeToBSON(_list);
                    break;
                case PersistFormat.PrettyJSON:
                    using (FileStream fileStream = new FileStream(Path, FileMode.Create))
                        fileStream.SerializeToPrettyJSON(_list);
                    break;
            }
        }

        #endregion
    }
}
