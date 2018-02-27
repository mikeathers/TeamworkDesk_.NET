using Newtonsoft.Json;
using System.Collections;
using System.DirectoryServices.AccountManagement;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using TeamworkDesk_React.Models;

namespace TeamworkDesk_React.Controllers.Api
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {

            ArrayList groups = new ArrayList();

            foreach (System.Security.Principal.IdentityReference group in
                System.Web.HttpContext.Current.Request.LogonUserIdentity.Groups)
            {
                groups.Add(group.Translate(typeof
                    (System.Security.Principal.NTAccount)).ToString());
            }


            var user = new User()
            {
                Authenticated = groups.Contains("SPEED\\IT") || groups.Contains("SPEED\\MANAGEMENT") ? true : false,
                Name = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name,
                EmailAddress = UserPrincipal.Current.EmailAddress
            };

            var result = JsonConvert.SerializeObject(user);


            var resp = new HttpResponseMessage
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json")
            };

            return resp;
        }





    }
}
