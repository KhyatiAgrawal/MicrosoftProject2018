using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Examples;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Bond.Protocols;
using System.IO;
using Bond;

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
            return "done";
        }

        // GET api/values/somestring
        [HttpGet("{str}")]
        public string Get(string str)
        {
            /*if (str == "foo")
                return "bar";
            else
                return "no bar";
                */

            // Convert string to json
            var reader = new SimpleJsonReader(new StringReader(str));

            // Deserialize the json to record
            var readRecord = Deserialize<Record>.From(reader);
    
            // Change record
            readRecord.Name = "Changed";

            // Convert json back to string
            var jsonString = new StringBuilder();
            var jsonWriter = new SimpleJsonWriter(new StringWriter(jsonString));

            //Reserialize
            Serialize.To(jsonWriter, readRecord);
            jsonWriter.Flush();

            // Send response
            return jsonString.ToString();
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
