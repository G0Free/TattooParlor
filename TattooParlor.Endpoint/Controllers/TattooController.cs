using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooParlor.Logic;
using TattooParlor.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TattooParlor.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TattooController : ControllerBase
    {
        ITattooLogic tattooLogic;
        public TattooController(ITattooLogic tattooLogic)
        {
            this.tattooLogic = tattooLogic;
        }


        // GET: /tattoo
        [HttpGet]
        public IEnumerable<Tattoo> Get()
        {
            return tattooLogic.GetAllTattoes();
        }

        // GET tattoo/5
        [HttpGet("{id}")]
        public Tattoo Get(int id)
        {
            return tattooLogic.GetTattooById(id);
        }

        // POST /tattoo
        [HttpPost]
        public void Post([FromBody] Tattoo value)
        {
            tattooLogic.AddNewTattoo(value);
        }

        // PUT /tattoo
        [HttpPut]
        public void Put([FromBody] Tattoo value)
        {
            tattooLogic.UpdateTattoo(value);
        }

        // DELETE /tattoo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tattooLogic.DeleteTatto(id);
        }
    }
}
