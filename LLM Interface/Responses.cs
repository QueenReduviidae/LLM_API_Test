using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace LLM_Interface
{
    class Responses
    {
        public class Model
        {
            public string id { get; set; }
            [JsonProperty("object")]
            public string obj { get; set; }
            public string owned_by { get; set; }
            public override string ToString()
            {
                return id.ToString();
            }
        }

        public class ModelList
        {
            public ModelList()
            {
                data = new List<Model>();
            }


            public List<Model> data { get; set; }
        }
    }
}
