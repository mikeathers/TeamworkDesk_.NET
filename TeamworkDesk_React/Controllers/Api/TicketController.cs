using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using TeamworkDesk_React.Models;

namespace TeamworkDesk_React.Controllers.Api
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class TicketController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get(int id)
        {
            var endpoint = $"/desk/v1/tickets/{id}.json";
            var jsonData = await Teamwork.GetData(endpoint);
            var ticketData = JsonConvert.DeserializeObject<TeamworkDeskTicket>(jsonData);

            var result = JsonConvert.SerializeObject(ticketData);

            var resp = new HttpResponseMessage
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json")
            };

            return resp;
        }
    }
}
