using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Data;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        //private readonly ILogger<CustomerRepository> logger;
        private readonly CompanyContext ctx;
        public CustomerRepository(CompanyContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }

        //Create
        public void AddNewCustomer(Customer customer)
        {
            try
            {
                customer.CreatedAt = DateTime.UtcNow;

                ctx.Add(customer);
            }
            catch (Exception e)
            {
                //Logging
               // logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }

        //Read
        public override Customer GetOne(int id)
        {
            try
            {
                //logger.LogInformation("We just returned a Customer with ID: " +  id); //this is just for testing
                //return GetAll().FirstOrDefault(x => x.CustomerId == id);
                return (Customer)ctx.Customers.FirstOrDefault(x => x.CustomerId == id);
            }
            catch (Exception e)
            {
                //logging
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
                return null;
            }
        }

        //Update
        public void UpdateCustomer(Customer customer)
        {
            try
            {
                var toUpdate = GetOne(customer.CustomerId);
                toUpdate.FirstName = customer.FirstName;
                toUpdate.LastName = customer.LastName;
                toUpdate.BirthYear = customer.BirthYear;
                toUpdate.Email = customer.Email;
            }
            catch (Exception e)
            {
                //logging
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }
        public void ChangeBirthYear(int id, int newBirthYear)
        {
            try
            {
                var customer = GetOne(id);
                customer.BirthYear = newBirthYear;
            }
            catch (Exception e)
            {
                //logging
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }

        public void ChangeEmail(int id, string newEmail)
        {
            try
            {
                var customer = GetOne(id);
                customer.Email = newEmail;
            }
            catch (Exception e)
            {
                //logging
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }

        public void ChangeFirstName(int id, string newFirstName)
        {
            try
            {
                var customer = GetOne(id);
                customer.FirstName = newFirstName;
            }
            catch (Exception e)
            {
                //logging
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }

        public void ChangeLastName(int id, string newLastName)
        {
            try
            {
                var customer = GetOne(id);
                customer.LastName = newLastName;
            }
            catch (Exception e)
            {
                //logging
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }

        //Delete
        public void DeleteCustomer(int id)
        {
            try
            {
                var toDelete = GetOne(id);

                toDelete.IsDeleted = true;
                toDelete.DeletedAt = DateTime.UtcNow;

                //ctx.Remove(toDelete);
            }
            catch (Exception e)
            {
                //logging
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }

    }
}
