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
        ITattooRepository tattooRepo;
        IJobsDoneRepository jobRepo;

        public CustomerLogic(ICustomerRepository repo)
        {
            this.customerRepo = repo;
        }

        public CustomerLogic(ICustomerRepository customerRepo, ITattooRepository tattooRepo, IJobsDoneRepository jobRepo)
        {
            this.customerRepo = customerRepo;
            this.tattooRepo = tattooRepo;
            this.jobRepo = jobRepo;
        }

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
            throw new IndexOutOfRangeException("Invalid ID");
        }

        //ReadAll
        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerRepo.GetAll();
        }

        //Update
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

        

        

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
