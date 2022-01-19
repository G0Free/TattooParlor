using Microsoft.EntityFrameworkCore;
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
        public CustomerRepository(DbContext ctx) : base(ctx)
        {
            //done
        }

        //Create
        public void AddNewCustomer(Customer customer)
        {
            try
            {
                ctx.Add(customer);
            }
            catch (Exception)
            {
                //Logging
            }
            ctx.SaveChanges();
        }

        //Read
        public override Customer GetOne(int id)
        {
            try
            {
                return GetAll().FirstOrDefault(x => x.CustomerId == id);
            }
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                ///logging
            }
            ctx.SaveChanges();
        }
    }
}
