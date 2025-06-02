using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Model.Data
{
    public class JSONSerializer:Serializer
    {
        public override void Serialize<T>(string filePath,T obj)
        {
            string json=JsonConvert.SerializeObject(obj,Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath,json);
        }
        public override T Deserialize<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
