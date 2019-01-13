using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackerActivity.Domain.Activity;
using TrackerActivity.Application.Core;

namespace TrackerActivity.UI.ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcitvityController : ControllerBase
    {
        // GET: api/ReadingAcitvity
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ReadingAcitvity/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ReadingAcitvity
        [HttpPost]
        public void Post([FromBody] IActivity  activity)
        {

        }

        // PUT: api/ReadingAcitvity/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
