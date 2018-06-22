using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Examples;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Hello Web";
        }

        // GET api/values/5
        [HttpGet("{name}/{uni}/{year}")]
        public async Task<string> Get(string name, string uni, double year)
        {
            var rec = pro.Serializer(name, uni, year);
            byte[] result = rec.Data.ToArray();
            /* var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/bond"));

            client.BaseAddress = new Uri("http://localhost:52513/");
            var byteArrayContent = new ByteArrayContent(result);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/bond");
            var res = await client.PostAsync("api/SomeData/Incoming", byteArrayContent);
            res.EnsureSuccessStatusCode();*/
            return "done";
        }

        // GET api/values/5
        [HttpGet("{str}")]
        public string Get(string str)
        {
            if (str == "foo")
                return "bar";
            else
                return "no bar";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


}
