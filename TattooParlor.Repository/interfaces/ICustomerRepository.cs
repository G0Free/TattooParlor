using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void ChangeFirstName(int id, string newFirstName);
        void ChangeLastName(int id, string newLastName);
        void ChangeEmail(int id, string newEmail);
        void ChangeBirthYear(int id, int newBirthYear);
        void AddNewCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
