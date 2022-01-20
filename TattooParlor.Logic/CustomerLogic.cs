using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;
using TattooParlor.Repository;

namespace TattooParlor.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        ICustomerRepository customerRepo;
        IJobsDoneRepository jobRepo;
        ITattooRepository tattooRepo;

        public CustomerLogic(ICustomerRepository repo)
        {
            this.customerRepo = repo;
        }

        public CustomerLogic(ICustomerRepository customerRepo, IJobsDoneRepository jobRepo, ITattooRepository tattooRepo)
        {
            this.customerRepo = customerRepo;
            this.jobRepo = jobRepo;
            this.tattooRepo = tattooRepo;
        }

        #region CRUD methods
        //Create
        public void AddNewCustomer(Customer customer)
        {
            customerRepo.AddNewCustomer(customer);
        }

        //Read
        public Customer GetCustomerById(int id)
        {
            if (id <= customerRepo.GetAll().Count())
            {
                return customerRepo.GetOne(id);
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid ID");
            }
        }

        //ReadAll
        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerRepo.GetAll();
        }

        //Update
        public void UpdateCustomer(Customer customer)
        {
            customerRepo.UpdateCustomer(customer);
        }
        public void ChangeBirthYear(int id, int newBirthYear)
        {
            customerRepo.ChangeBirthYear(id, newBirthYear);
        }
        public void ChangeEmail(int id, string newEmail)
        {
            customerRepo.ChangeEmail(id, newEmail);
        }
        public void ChangeFirstName(int id, string newFirstName)
        {
            customerRepo.ChangeFirstName(id, newFirstName);
        }
        public void ChangeLastName(int id, string newLastName)
        {
            customerRepo.ChangeLastName(id, newLastName);
        }

        //Delete
        public void DeleteCustomer(int id)
        {
            customerRepo.DeleteCustomer(id);
        }
        #endregion


    }
}
