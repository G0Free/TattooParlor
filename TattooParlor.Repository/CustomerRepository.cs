﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ILogger logger;
        public CustomerRepository(DbContext ctx) : base(ctx)
        {
            var factory = new LoggerFactory();

            //logger = factory.CreateLogger("logger");
            logger = factory.CreateLogger(typeof(CustomerRepository).FullName);

            //done
        }

        //Create
        public void AddNewCustomer(Customer customer)
        {
            try
            {
                ctx.Add(customer);
            }
            catch (Exception e)
            {
                //Logging
                logger.LogError(e.Message, e);
            }
            ctx.SaveChanges();
        }

        //Read
        public override Customer GetOne(int id)
        {
            try
            {
                logger.LogInformation("We just returned a Customer with ID: " +  id);
                return GetAll().FirstOrDefault(x => x.CustomerId == id);
            }
            catch (Exception e)
            {
                //logging
                logger.LogError(e.Message, e);
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
                logger.LogError(e.Message, e);
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
                logger.LogError(e.Message, e);
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
                logger.LogError(e.Message, e);
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
                logger.LogError(e.Message, e);
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
                logger.LogError(e.Message, e);
            }
            ctx.SaveChanges();
        }

        //Delete
        public void DeleteCustomer(int id)
        {
            try
            {
                var toDelete = GetOne(id);
                ctx.Remove(toDelete);
            }
            catch (Exception e)
            {
                //logging
                logger.LogError(e.Message, e);
            }
            ctx.SaveChanges();
        }

        //public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsEnabled(LogLevel logLevel)
        //{
        //    throw new NotImplementedException();
        //}

        //public IDisposable BeginScope<TState>(TState state)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
