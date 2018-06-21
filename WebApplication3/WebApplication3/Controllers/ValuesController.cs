using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Examples;
using System.Text;

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
        public string Get(string name, string uni, double year)
        {
            var rec = pro.Serializer(name, uni, year);
            byte[] result = rec.Data.ToArray();
            // return "done" + " " + System.Text.ASCIIEncoding.ASCII.GetString(result);
            return "done";
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
