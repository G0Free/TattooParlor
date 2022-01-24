using AutoMapper;
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
        private readonly ITattooLogic tattooLogic;
        public readonly IMapper mapper;

        public TattooController(IMapper mapper, ITattooLogic tattooLogic)
        {
            this.mapper = mapper;
            this.tattooLogic = tattooLogic;
        }


        // GET: /tattoo
        [HttpGet]       
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
                var mappedTattoo = mapper.Map<Tattoo>(value);

                var tattoo = tattooLogic.AddNewTattoo(mappedTattoo);

                return Ok(mapper.Map<TattooDto>(tattoo));               
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

                var mappedTattoo = mapper.Map<Tattoo>(value);

                var tattoo = tattooLogic.UpdateTattoo(mappedTattoo);

                return Ok(mapper.Map<TattooDto>(tattoo));

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
