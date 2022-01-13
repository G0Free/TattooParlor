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
    public class JobsDoneController : ControllerBase
    {
        IJobsDoneLogic jobsDoneLogic;

        public JobsDoneController(IJobsDoneLogic jobsDoneLogic)
        {
            this.jobsDoneLogic = jobsDoneLogic;
        }


        // GET: /jobsdone
        [HttpGet]
        public IEnumerable<JobsDone> Get()
        {
            return jobsDoneLogic.GetAllJobsDone();
        }

        // GET /jobsdone/5
        [HttpGet("{id}")]
        public JobsDone Get(int id)
        {
            return jobsDoneLogic.GetJobsDoneById(id);
        }

        // POST jobsdone
        [HttpPost]
        public void Post([FromBody] JobsDone value)
        {
            jobsDoneLogic.AddNewJobsDone(value);
        }

        // PUT /jobsdone
        [HttpPut]
        public void Put([FromBody] JobsDone value)
        {
            jobsDoneLogic.UpdateJobsDone(value);
        }

        // DELETE /jobsdone/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            jobsDoneLogic.DeleteJobsDone(id);
        }
    }
}
