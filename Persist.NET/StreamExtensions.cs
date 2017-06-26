using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Persist.NET
{
    public static class StreamExtensions
    {
        public static void SerializeToJSON<T>(this Stream stream, T data)
        {            
            using (StreamWriter streamWriter = new StreamWriter(stream))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jsonWriter, data);
            }
        } 

        public static void SerializeToBSON<T>(this Stream stream, T data)
        {
            using (BsonWriter bsonWriter = new BsonWriter(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(bsonWriter, data);
            }
        }

        public static void SerializeToPrettyJSON<T>(this Stream stream, T data)
        {
            using (StreamWriter streamWriter = new StreamWriter(stream))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(jsonWriter, data);
            }
        }

        public static T DeserializeFromJSON<T>(this Stream stream)
        {
            using (StreamReader streamReader = new StreamReader(stream))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(jsonReader);
            }
        }

        public static T DeserializeFromBSON<T>(this Stream stream)
        {
            using (BsonReader bsonReader = new BsonReader(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(bsonReader);
            }
        }
    }
}
