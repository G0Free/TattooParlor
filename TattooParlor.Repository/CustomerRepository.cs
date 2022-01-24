using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Data;
using TattooParlor.Models;
using TattooParlor.Models.Attributes;
using TattooParlor.Models.Exceptions;

namespace TattooParlor.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {       
        public CustomerRepository(DbContext ctx) : base(ctx)
        {
        }

        //Create
        public void AddNewCustomer(Customer customer)
        {
            try
            {
                if (Validator.CheckEmail(customer))
                {
                    customer.CreatedAt = DateTime.UtcNow;

                    ctx.Add(customer);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new InvalidEmailException();
                }
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                //if (!(e is InvalidEmailException))
                //{
                //    Log.Error(e, e.Message);
                //}
                //else
                //{
                //    throw new InvalidEmailException();
                //}
            }            
        }

        //Read
        public override Customer GetOne(int id)
        {
            try
            {
                return ((CompanyContext)ctx).Customers.FirstOrDefault(x => x.CustomerId == id);
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
                return null;
            }
        }

        //ReadAll
        public override IQueryable<Customer> GetAll()
        {
            try
            {               
                return ((CompanyContext)ctx).Customers.Where(x => x.IsDeleted == false);
            }
            catch (Exception e)
            {
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
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
            }            
        }
        public void ChangeBirthYear(int id, int newBirthYear)
        {
            try
            {
                var customer = GetOne(id);
                customer.BirthYear = newBirthYear;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
            }            
        }

        public void ChangeEmail(int id, string newEmail)
        {
            try
            {
                var customer = GetOne(id);
                customer.Email = newEmail;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
            }            
        }

        public void ChangeFirstName(int id, string newFirstName)
        {
            try
            {
                var customer = GetOne(id);
                customer.FirstName = newFirstName;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
            }            
        }

        public void ChangeLastName(int id, string newLastName)
        {
            try
            {
                var customer = GetOne(id);
                customer.LastName = newLastName;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
            }            
        }

        //Delete
        public void DeleteCustomer(int id)
        {
            try
            {
                var toDelete = GetOne(id);

                toDelete.IsDeleted = true;
                toDelete.DeletedAt = DateTime.UtcNow;
                
                ctx.SaveChanges();
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
            }            
        }

    }
}
