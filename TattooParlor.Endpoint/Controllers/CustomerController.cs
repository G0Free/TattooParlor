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
    public class CustomerController : ControllerBase
    {
        ICustomerLogic customerLogic;
        public CustomerController(ICustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }

        // GET: /customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerLogic.GetAllCustomers();
        }

        // GET /customer/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return customerLogic.GetCustomerById(id);
        }

        // POST /customer
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            customerLogic.AddNewCustomer(value);
        }

        // PUT /customer
        [HttpPut]
        public void Put([FromBody] Customer value)
        {
            customerLogic.UpdateCustomer(value);
        }

        // DELETE /customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerLogic.DeleteCustomer(id);
        }
    }
}
