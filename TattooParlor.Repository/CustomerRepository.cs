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
            return GetAll().FirstOrDefault(x => x.CustomerId == id);
        }

        //Update
        public void UpdateCustomer(Customer customer)
        {
            var toUpdate = GetOne(customer.CustomerId);
            toUpdate.FirstName = customer.FirstName;
            toUpdate.LastName = customer.LastName;
            toUpdate.BirthYear = customer.BirthYear;
            toUpdate.Email = customer.Email;
            ctx.SaveChanges();
        }
        public void ChangeBirthYear(int id, int newBirthYear)
        {
            var customer = GetOne(id);
            customer.BirthYear = newBirthYear;
            ctx.SaveChanges();
        }

        public void ChangeEmail(int id, string newEmail)
        {
            var customer = GetOne(id);
            customer.Email = newEmail;
            ctx.SaveChanges();
        }

        public void ChangeFirstName(int id, string newFirstName)
        {
            var customer = GetOne(id);
            customer.FirstName = newFirstName;
            ctx.SaveChanges();
        }

        public void ChangeLastName(int id, string newLastName)
        {
            var customer = GetOne(id);
            customer.LastName = newLastName;
            ctx.SaveChanges();
        }

        //Delete
        public void DeleteCustomer(int id)
        {
            var toDelete = GetOne(id);
            ctx.Remove(toDelete);
            ctx.SaveChanges();
        }
    }
}
