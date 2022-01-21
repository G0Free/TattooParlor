using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
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
        // private readonly ILogger logger;
        private readonly ILogger<TattooController> logger;
        public TattooController(ITattooLogic tattooLogic)
        {
            this.tattooLogic = tattooLogic;
           // var factory = new LoggerFactory();
           // logger = factory.CreateLogger(typeof(TattooController).FullName);
        }


        // GET: /tattoo
        [HttpGet]
        public IEnumerable<Tattoo> Get()
        {
            try
            {
                return tattooLogic.GetAllTattoes();
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return null;
            }
        }

        // GET: /tattoo/5
        [HttpGet("{id}")]
        public Tattoo Get(int id)
        {
            try
            {
                return tattooLogic.GetTattooById(id);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return null;
            }
        }

        // POST: /tattoo
        [HttpPost]
        public void Post([FromBody] Tattoo value)
        {
            try
            {
                tattooLogic.AddNewTattoo(value);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);                
            }
        }

        // PUT: /tattoo
        [HttpPut]
        public void Put([FromBody] Tattoo value)
        {
            try
            {
                tattooLogic.UpdateTattoo(value);
            }
            catch (Exception e)
            {
                
            }
        }

        // DELETE: /tattoo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                tattooLogic.DeleteTatto(id);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
            }
        }
    }
}
