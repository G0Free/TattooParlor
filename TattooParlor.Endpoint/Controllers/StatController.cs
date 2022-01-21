using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooParlor.Logic;
using TattooParlor.Models;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<StatController> logger;
        public StatController(ICustomerLogic customerLogic, IJobsDoneLogic jobLogic, ITattooLogic tattooLogic)
        {
            this.customerLogic = customerLogic;
            this.jobLogic = jobLogic;
            this.tattooLogic = tattooLogic;
        }

        // GET: stat/GetAllJobsByOneCustomer
        [HttpGet("{id}")]
        public IList<JobsDone> GetAllJobsByOneCustomer(int id)
        {
            try
            {
                return jobLogic.GetAllJobsByOneCustomer(id);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return null;
            }
        }

        // GET: stat/CountAllJobsByOneCustomer
        [HttpGet("{id}")]
        public int CountAllJobsByOneCustomer(int id)
        {
            try
            {
                return jobLogic.CountAllJobsByOneCustomer(id);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return -1;
            }
        }        
    }
}
