using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkDesk_React.Models
{
    public static class Teamwork
    {
        public static async Task<string> GetData(string endpoint)
        {
            const string apiKey = "qFO3YsODDZFw9cuI5u6fbC5f4HA0CV3s08BLiipWSocaz4Mip1";
            const string domain = "speedmedical.eu"; //.teamwork.com
            //const string endpoint = "projects.json"; //eg projects.json , milestones.json etc

            var client = new HttpClient { BaseAddress = new Uri("https://" + domain + ".teamwork.com") };
            client.DefaultRequestHeaders.Authorization =

                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}: x")));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var data = await client.GetAsync(endpoint);
            using (var responseStream = await data.Content.ReadAsStreamAsync())
            {
                return new StreamReader(responseStream).ReadToEnd();
            }
        }
    }
}