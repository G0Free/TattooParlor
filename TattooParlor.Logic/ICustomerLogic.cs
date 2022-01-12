using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Logic
{
    public interface ICustomerLogic
    {
        //Create
        void AddNewCustomer(Customer customer);

        //Read
        Customer GetCustomerById(int id);

        //ReadAll
        IEnumerable<Customer> GetAllCustomers();

        //Update
        void ChangeBirthYear(int id, int newBirthYear);
        void ChangeEmail(int id, string newEmail);
        void ChangeFirstName(int id, string newFirstName);
        void ChangeLastName(int id, string newLastName);

        //Delete
        void DeleteCustomer(int id);
    }
}
