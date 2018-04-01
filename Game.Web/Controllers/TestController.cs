using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Game.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly IHubContext<GameHub> hubcontext;

        public TestController(IHubContext<GameHub> hubcontext)
        {
            this.hubcontext = hubcontext;
        }

        // GET: api/test
        [HttpGet]
        public void Get()
        {
            this.hubcontext.Clients.All.SendAsync("playerJoined", "player1", 100);
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Test
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
