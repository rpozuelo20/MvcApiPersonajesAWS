using Microsoft.Extensions.Configuration;
using MvcApiPersonajesAWS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcApiPersonajesAWS.Services
{
    public class ServiceApiPersonajes
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue Header;
        public ServiceApiPersonajes(IConfiguration configuration)
        {
            this.UrlApi = configuration.GetValue<string>("UrlApis:ApiPersonajes");
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }


        private async Task<T> CallApiAsync<T>(string request)
        {
            using(HttpClient client =new HttpClient())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public async Task InsertPersonajeAsync(Personaje personaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/personajes";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                string json = JsonConvert.SerializeObject(personaje);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.GetAsync(request);
            }
        }
        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            string request = "/api/personajes";
            List<Personaje> personajes = await this.CallApiAsync<List<Personaje>>(request);
            return personajes;
        }
    }
}
