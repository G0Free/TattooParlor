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
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic customerLogic;
       // private readonly ILogger<TattooController> logger;
        public CustomerController(ICustomerLogic customerLogic)
        {
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
                //logger.LogError(e, e.Message);
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
        public void Post([FromBody] Customer value)
        {
            try
            {
                customerLogic.AddNewCustomer(value);
            }
            catch (Exception e)
            {
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
        }

        // PUT /customer
        [HttpPut]
        public void Put([FromBody] Customer value)
        {
            try
            {
                customerLogic.UpdateCustomer(value);
            }
            catch (Exception e)
            {
               // logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
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
