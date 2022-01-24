using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TattooParlor.Logic;
using TattooParlor.Models;
using Serilog;
using TattooParlor.Models.DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TattooParlor.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobsDoneController : ControllerBase
    {
        IJobsDoneLogic jobsDoneLogic;
        public readonly IMapper mapper;

        public JobsDoneController(IMapper mapper, IJobsDoneLogic jobsDoneLogic)
        {
            this.mapper = mapper;
            this.jobsDoneLogic = jobsDoneLogic;
        }


        // GET: /jobsdone
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //return Ok(jobsDoneLogic.GetAllJobsDone());
                var mappedJobsDone = mapper.Map<IEnumerable<JobsDone>>(jobsDoneLogic.GetAllJobsDone());
                return Ok(mappedJobsDone);
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(500, null);
            }
        }

        // GET: /jobsdone/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //return jobsDoneLogic.GetJobsDoneById(id);
                var mappedJobsDone = mapper.Map<JobsDoneDto>(jobsDoneLogic.GetJobsDoneById(id));
                return Ok(mappedJobsDone);
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(500, null);
            }
        }

        // POST: /jobsdone
        [HttpPost]
        public IActionResult Post([FromBody] JobsDoneDto value)
        {
            try
            {
                var mappedJobsDone = mapper.Map<JobsDone>(value);

                var jobsDone = jobsDoneLogic.AddNewJobsDone(mappedJobsDone);


                return Ok(mapper.Map<JobsDoneDto>(jobsDone));
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(500, null);
            }
        }

        // PUT: /jobsdone
        [HttpPut]
        public IActionResult Put([FromBody] JobsDone value)
        {
            try
            {
                var mappedJobsDone = mapper.Map<JobsDone>(value);

                var jobsDone = jobsDoneLogic.AddNewJobsDone(mappedJobsDone);

                return Ok(mapper.Map<JobsDoneDto>(jobsDone));
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(500, null);
            }
        }

        // DELETE: /jobsdone/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                jobsDoneLogic.DeleteJobsDone(id);
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
            }
        }
    }
}
