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
    public class TicketsController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get(int id = 0, string status = "")
        {
            var endpoint = "";

            if (string.IsNullOrEmpty(status))
                endpoint = $"/desk/v1/smartinboxes/21/tickets.json?sortBy=createdAt&sortDir=DESC&startRow=1&groupId={id}";

            else if (status == "assigned")
                endpoint = $"/desk/v1/inboxes/{id}/tickets/Active.json?notAssignedTo[]=-1&notAssignedTo[]=156275&pageSize=1000&sortBy=createdAt&sortDir=ASC&startRow=1";

            else if (status == "search")
                endpoint = $"desk/v1/tickets/search.json?search={id}";

            else
                endpoint = $"/desk/v1/inboxes/{id}/tickets/{status}.json?pageSize=3000&sortBy=createdAt&sortDir=ASC&startRow=1";


            var jsonData = await Teamwork.GetData(endpoint);

            var ticketData = JsonConvert.DeserializeObject<TeamworkDeskTickets>(jsonData);

            var result = JsonConvert.SerializeObject(ticketData);

            var resp = new HttpResponseMessage
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),

            };

            return resp;
        }

    }
}
