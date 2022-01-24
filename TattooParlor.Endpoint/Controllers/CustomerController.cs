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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic customerLogic;
        public readonly IMapper mapper;

        public CustomerController(IMapper mapper, ICustomerLogic customerLogic)
        {
            this.mapper = mapper;
            this.customerLogic = customerLogic;
        }

        // GET: /customer
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return base.Ok(customerLogic.GetAllCustomers());
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return base.StatusCode(500, null);
            }
        }

        // GET /customer/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            try
            {
                return customerLogic.GetCustomerById(id);
            }
            catch (Exception e)
            {
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);

                return null;
            }
        }

        // POST /customer
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto value)
        {
            try
            {
                /*
                var customerEntity = new Customer
                {
                    CustomerId = value.CustomerId,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    Email = value.Email,
                    BirthYear = value.BirthYear,
                    JobsDoneId = value.JobsDoneId,
                    IsDeleted = value.IsDeleted
                };*/
                var mappedCustomer = mapper.Map<Customer>(value);


                var customer = customerLogic.AddNewCustomer(mappedCustomer);
                /*var customer = customerLogic.AddNewCustomer(customerEntity);

                */
                return Ok(new CustomerDto 
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    BirthYear = customer.BirthYear,
                    JobsDoneId = customer.JobsDoneId,
                    IsDeleted = customer.IsDeleted
                });
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
                return StatusCode(500, null);
            }
        }

        // PUT /customer
        [HttpPut]
        public IActionResult Put([FromBody] Customer value)
        {
            try
            {
                /*
                var customerEntity = new Customer
                {
                    CustomerId = value.CustomerId,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    Email = value.Email,
                    BirthYear = value.BirthYear,
                    JobsDoneId = value.JobsDoneId,
                    IsDeleted = value.IsDeleted
                };*/
                var mappedCustomer = mapper.Map<Customer>(value);

                var customer = customerLogic.UpdateCustomer(mappedCustomer);
                //var customer = customerLogic.UpdateCustomer(customerEntity);

                return Ok(new CustomerDto
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    BirthYear = customer.BirthYear,
                    JobsDoneId = customer.JobsDoneId,
                    IsDeleted = customer.IsDeleted
                });
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(500, null);
            }
        }

        // DELETE /customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                customerLogic.DeleteCustomer(id);
            }
            catch (Exception e)
            {
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
        }
    }
}
