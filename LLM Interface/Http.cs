using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Windows;


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

            try
            {
                Task<HttpResponseMessage> response = client.GetAsync("v1/models");
                response.Wait();
                if (!response.IsCompletedSuccessfully) return null;
                Task<string> result = response.Result.Content.ReadAsStringAsync();
                result.Wait();
                Responses.ModelList? models = JsonConvert.DeserializeObject<Responses.ModelList>(result.Result);
                return models;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get response from the API.", "Connection Error", MessageBoxButton.OK);
                return null;
            }
        }
        public static Responses.PostList? Post(string model, string message)
        {
            try
            {
                string json = $"{{\"model\": \"{model}\",\"messages\": [{{\"role\": \"user\",\"content\": \"{message}\"}}]}}";
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> response = client.PostAsync("v1/chat/completions", stringContent);
                response.Wait();
                if (!response.IsCompletedSuccessfully) return null;
                Task<string> result = response.Result.Content.ReadAsStringAsync();
                result.Wait();
                Responses.PostList? posts = JsonConvert.DeserializeObject<Responses.PostList>(result.Result);
                return posts;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get response from the API.", "Connection Error", MessageBoxButton.OK);
                return null;
            }
        }
    }
}
