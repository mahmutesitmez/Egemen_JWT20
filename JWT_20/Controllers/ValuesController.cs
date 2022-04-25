
using JWT_20.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT_20.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private AppIdentityDbContext context;

        public ValuesController(AppIdentityDbContext context)
        {
            this.context = context;
        }
        private readonly IBildirim bildirim;

        public ValuesController(IBildirim bildirim)
        {
            this.bildirim = bildirim;
        }



        // GET: api/<ValuesController>
        [HttpGet]
        
        public ActionResult<IEnumerable<string>> Get()
        {
            //return new string[] { "value1", "value2" };
            try
            {
                return context.Users.Select(x => x.UserName).ToArray();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        [Route("bildir")]
        public string Bildir()
        {
            return bildirim.Gonder();
        }
        [HttpGet]
        [Route("kampanya")]
        public string Kampanya()
        {
            return bildirim.Gonder();
        }
        [HttpGet]
        [Route("sonuc")]
        public string Sonuc()
        {
            return bildirim.Gonder();
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
