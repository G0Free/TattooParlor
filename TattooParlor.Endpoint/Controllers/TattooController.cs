using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooParlor.Logic;
using TattooParlor.Models;
using TattooParlor.Models.DTO;

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
        //public IEnumerable<Tattoo> Get()
        public IActionResult Get()
        {
            try
            {
                return Ok(tattooLogic.GetAllTattoes());
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(500, null);
                //return null;
            }
        }

        // GET: /tattoo/5
        [HttpGet("{id}")]
        public Tattoo Get(int id)
        {
            try
            {
                Log.Information("A tattoo was returned with id: {id}", id);
                //logger.LogInformation("A tattoo was returned with id: {id}", id);
                return tattooLogic.GetTattooById(id);
            }
            catch (Exception e)
            {
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
                return null;
            }
        }

        // POST: /tattoo
        [HttpPost]
        public IActionResult Post([FromBody] TattooDto value)
        {
            try
            {
                var tattooEntity = new Tattoo
                {
                    TattooId = value.TattooId,
                    FantasyName = value.FantasyName,
                    jobsDoneId = value.jobsDoneId,
                    IsDeleted = value.IsDeleted
                };

                var tattoo = tattooLogic.AddNewTattoo(tattooEntity);

                return Ok(new TattooDto
                {
                    TattooId = tattoo.TattooId,
                    FantasyName = tattoo.FantasyName,
                    jobsDoneId = tattoo.jobsDoneId,
                    IsDeleted = tattoo.IsDeleted
                });
                
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
                return StatusCode(500, null);
            }
        }

        // PUT: /tattoo
        [HttpPut]
        public IActionResult Put([FromBody] Tattoo value)
        {
            try
            {
                var tattooEntity = new Tattoo
                {
                    TattooId = value.TattooId,
                    FantasyName = value.FantasyName,
                    jobsDoneId = value.jobsDoneId,
                    IsDeleted = value.IsDeleted
                };

                var tattoo = tattooLogic.UpdateTattoo(tattooEntity);

                return Ok(new TattooDto
                {
                    TattooId = tattoo.TattooId,
                    FantasyName = tattoo.FantasyName,
                    jobsDoneId = tattoo.jobsDoneId,
                    IsDeleted = tattoo.IsDeleted
                });

            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(500, null);
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
                Log.Error(e, e.Message);
            }
        }
    }
}
