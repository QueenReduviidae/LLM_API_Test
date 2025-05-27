using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;


namespace LLM_Interface
{
    internal class Http
    {
        private static HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:1234/"),
        };

        
        public static Responses.ModelList? Get()
        {
            Task<HttpResponseMessage> response = client.GetAsync("v1/models");
            response.Wait();
            if (!response.IsCompletedSuccessfully) return null;
            Task<string> result = response.Result.Content.ReadAsStringAsync();
            result.Wait();
            Responses.ModelList? models = JsonConvert.DeserializeObject<Responses.ModelList>(result.Result);
            return models;
        }
    }
}
