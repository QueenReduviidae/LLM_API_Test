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
        public class message()
        {
            public string role { get; set; }
            public string content { get; set; }
        }
        public class choice()
        {
            public string index { get; set; }
            public message message { get; set; }
            public string logprobs { get; set; }
            public string finish_reason { get; set; }

            public override string ToString()
            {
                return message.content;
            }
        }
        

        public class PostList()
        {
            public string id { get; set; }
            [JsonProperty("object")]
            public string obj { get; set; }
            public string created { get; set; }
            public string model { get; set; }
            public List<choice> choices { get; set; }
        }
    }
}
