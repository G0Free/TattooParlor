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
        public IList<JobsDone> GetAllJobsByOneCustomer(int id)
        {
            return jobLogic.GetAllJobsByOneCustomer(id);
        }

        // GET: stat/CountAllJobsByOneCustomer
        [HttpGet("{id}")]
        public int CountAllJobsByOneCustomer(int id)
        {
            return jobLogic.CountAllJobsByOneCustomer(id);
        }        
    }
}
