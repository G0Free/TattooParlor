﻿using Microsoft.AspNetCore.Mvc;
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
        //public IEnumerable<JobsDone> Get()
        public IActionResult Get()
        {
            try
            {
                return Ok(jobsDoneLogic.GetAllJobsDone());
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(500, null);
                //return null;
            }
        }

        // GET: /jobsdone/5
        [HttpGet("{id}")]
        public JobsDone Get(int id)
        {
            try
            {
                return jobsDoneLogic.GetJobsDoneById(id);
            }
            catch (Exception e)
            {
                // logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
                return null;
            }
        }

        // POST: /jobsdone
        [HttpPost]
        public IActionResult Post([FromBody] JobsDoneDto value)
        {
            try
            {
                /*
                var jobsDoneEntity = new JobsDone
                {
                    JobsDoneId = value.JobsDoneId,
                    customerId = value.customerId,
                    TattooId = value.TattooId,
                    jobDate = value.jobDate,
                    Cost = value.Cost,
                    IsDeleted = value.IsDeleted
                };*/
                var mappedJobsDone = mapper.Map<JobsDone>(value);

                var jobsDone = jobsDoneLogic.AddNewJobsDone(mappedJobsDone);



                //var jobsDone = jobsDoneLogic.AddNewJobsDone(jobsDoneEntity);

                //jobsDoneLogic.AddNewJobsDone(value);

                return Ok(new JobsDoneDto
                {
                    JobsDoneId = jobsDone.JobsDoneId,
                    customerId = jobsDone.customerId,
                    TattooId = jobsDone.TattooId,
                    jobDate = jobsDone.jobDate,
                    Cost = jobsDone.Cost,
                    IsDeleted = jobsDone.IsDeleted
                });
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
                /*
                var jobsDoneEntity = new JobsDone
                {
                    JobsDoneId = value.JobsDoneId,
                    customerId = value.customerId,
                    TattooId = value.TattooId,
                    jobDate = value.jobDate,
                    Cost = value.Cost,
                    IsDeleted = value.IsDeleted
                };*/

                var mappedJobsDone = mapper.Map<JobsDone>(value);


                var jobsDone = jobsDoneLogic.AddNewJobsDone(mappedJobsDone);
                //var jobsDone = jobsDoneLogic.UpdateJobsDone(jobsDoneEntity);

                //jobsDoneLogic.AddNewJobsDone(value);

                
                return Ok(new JobsDoneDto
                {
                    JobsDoneId = jobsDone.JobsDoneId,
                    customerId = jobsDone.customerId,
                    TattooId = jobsDone.TattooId,
                    jobDate = jobsDone.jobDate,
                    Cost = jobsDone.Cost,
                    IsDeleted = jobsDone.IsDeleted
                });
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
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
        }
    }
}
