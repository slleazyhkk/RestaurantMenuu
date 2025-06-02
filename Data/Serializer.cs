using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public abstract class Serializer
    {
        public abstract void Serialize<T>(string filePath, T obj);
        public abstract T Deserialize<T>(string filePath);
        public void SelectFile(string filePath)
        {
            var directory=Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static implicit operator Serializer(JsonSerializer v)
        {
            throw new NotImplementedException();
        }
    }
}
