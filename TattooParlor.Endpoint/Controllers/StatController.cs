using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooParlor.Logic;
using TattooParlor.Models;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TattooParlor.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICustomerLogic customerLogic;
        IJobsDoneLogic jobLogic;
        ITattooLogic tattooLogic;       
        public StatController(ICustomerLogic customerLogic, IJobsDoneLogic jobLogic, ITattooLogic tattooLogic)
        {
            this.customerLogic = customerLogic;
            this.jobLogic = jobLogic;
            this.tattooLogic = tattooLogic;
        }

        // GET: stat/GetAllJobsByOneCustomer
        [HttpGet("{id}")]        
        public IActionResult GetAllJobsByOneCustomer(int id)
        {
            try
            {
                return Ok(jobLogic.GetAllJobsByOneCustomer(id));
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
                return StatusCode(500, null);
            }
        }

        // GET: stat/CountAllJobsByOneCustomer
        [HttpGet("{id}")]
        public IActionResult CountAllJobsByOneCustomer(int id)
        {
            try
            {
                return Ok(jobLogic.CountAllJobsByOneCustomer(id));
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(500,-1);
            }
        }        
    }
}
