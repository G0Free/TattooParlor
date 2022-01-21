using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Logic;
using TattooParlor.Models;
using TattooParlor.Repository;

namespace TattooParlor.Test
{
    [TestFixture]
    public class CustomerLogicTests
    {
        CustomerLogic customerLogic { get; set; }

        [SetUp]
        public void Init()
        {
            Mock<ICustomerRepository> mockedCustomerRepository = new Mock<ICustomerRepository>();
            Mock<IJobsDoneRepository> mockedJobsDoneRepository = new Mock<IJobsDoneRepository>();
            Mock<ITattooRepository> mockedTattooRepository = new Mock<ITattooRepository>();

            mockedCustomerRepository.Setup(x => x.GetAll()).Returns(this.FakeCustomerObjects);
            mockedJobsDoneRepository.Setup(x => x.GetAll()).Returns(this.FakeJobDoneObjects);
            mockedTattooRepository.Setup(x => x.GetAll()).Returns(this.FakeTattooObjects);

            this.customerLogic = new CustomerLogic(mockedCustomerRepository.Object, mockedJobsDoneRepository.Object, mockedTattooRepository.Object);
        }

        #region TESTS



        #endregion


        #region FAKES

        private IQueryable<Customer> FakeCustomerObjects()
        {
            #region Customers
            Customer customer1 = new Customer() { CustomerId = 1, FirstName = "Adam", LastName = "Test", Email = "adam.test@testemail.com", BirthYear = 1998 };
            Customer customer2 = new Customer() { CustomerId = 2, FirstName = "Ben", LastName = "Smith", Email = "ben.smith@gmail.com", BirthYear = 1983 };
            Customer customer3 = new Customer() { CustomerId = 3, FirstName = "Elliot", LastName = "Alderson", Email = "fsociety@ecorp.com", BirthYear = 1986 };
            #endregion

            #region Tattoos
            Tattoo tattoo1 = new Tattoo() { TattooId = 1, FantasyName = "BigSpider" };
            Tattoo tattoo2 = new Tattoo() { TattooId = 2, FantasyName = "SmallHeart" };
            Tattoo tattoo3 = new Tattoo() { TattooId = 3, FantasyName = "LittleTriangle" };
            #endregion

            #region JobsDones
            JobsDone jobsDone1 = new JobsDone() { JobsDoneId = 1, Cost = 14000, jobDate = new DateTime(2021, 01, 04) };
            JobsDone jobsDone2 = new JobsDone() { JobsDoneId = 2, Cost = 10000, jobDate = new DateTime(2021, 05, 12) };
            JobsDone jobsDone3 = new JobsDone() { JobsDoneId = 3, Cost = 25000, jobDate = new DateTime(2021, 05, 23) };
            JobsDone jobsDone4 = new JobsDone() { JobsDoneId = 4, Cost = 12000, jobDate = new DateTime(2021, 10, 11) };
            #endregion

            #region ForeignKeySet
            jobsDone1.customerId = customer1.CustomerId;
            jobsDone2.customerId = customer2.CustomerId;
            jobsDone3.customerId = customer3.CustomerId;
            jobsDone4.customerId = customer1.CustomerId;

            jobsDone1.TattooId = tattoo2.TattooId;
            jobsDone2.TattooId = tattoo3.TattooId;
            jobsDone3.TattooId = tattoo1.TattooId;
            jobsDone4.TattooId = tattoo3.TattooId;
            #endregion

            List<Customer> items = new List<Customer>();
            items.Add(customer1);
            items.Add(customer2);
            items.Add(customer3);

            return items.AsQueryable();
        }

        private IQueryable<JobsDone> FakeJobDoneObjects()
        {
            #region Customers
            Customer customer1 = new Customer() { CustomerId = 1, FirstName = "Adam", LastName = "Test", Email = "adam.test@testemail.com", BirthYear = 1998 };
            Customer customer2 = new Customer() { CustomerId = 2, FirstName = "Ben", LastName = "Smith", Email = "ben.smith@gmail.com", BirthYear = 1983 };
            Customer customer3 = new Customer() { CustomerId = 3, FirstName = "Elliot", LastName = "Alderson", Email = "fsociety@ecorp.com", BirthYear = 1986 };
            #endregion

            #region Tattoos
            Tattoo tattoo1 = new Tattoo() { TattooId = 1, FantasyName = "BigSpider" };
            Tattoo tattoo2 = new Tattoo() { TattooId = 2, FantasyName = "SmallHeart" };
            Tattoo tattoo3 = new Tattoo() { TattooId = 3, FantasyName = "LittleTriangle" };
            #endregion

            #region JobsDones
            JobsDone jobsDone1 = new JobsDone() { JobsDoneId = 1, Cost = 14000, jobDate = new DateTime(2021, 01, 04) };
            JobsDone jobsDone2 = new JobsDone() { JobsDoneId = 2, Cost = 10000, jobDate = new DateTime(2021, 05, 12) };
            JobsDone jobsDone3 = new JobsDone() { JobsDoneId = 3, Cost = 25000, jobDate = new DateTime(2021, 05, 23) };
            JobsDone jobsDone4 = new JobsDone() { JobsDoneId = 4, Cost = 12000, jobDate = new DateTime(2021, 10, 11) };
            #endregion

            #region ForeignKeySet
            jobsDone1.customerId = customer1.CustomerId;
            jobsDone2.customerId = customer2.CustomerId;
            jobsDone3.customerId = customer3.CustomerId;
            jobsDone4.customerId = customer1.CustomerId;

            jobsDone1.TattooId = tattoo2.TattooId;
            jobsDone2.TattooId = tattoo3.TattooId;
            jobsDone3.TattooId = tattoo1.TattooId;
            jobsDone4.TattooId = tattoo3.TattooId;
            #endregion

            List<JobsDone> items = new List<JobsDone>();
            items.Add(jobsDone1);
            items.Add(jobsDone2);
            items.Add(jobsDone3);
            items.Add(jobsDone4);

            return items.AsQueryable();
        }

        private IQueryable<Tattoo> FakeTattooObjects()
        {
            #region Customers
            Customer customer1 = new Customer() { CustomerId = 1, FirstName = "Adam", LastName = "Test", Email = "adam.test@testemail.com", BirthYear = 1998 };
            Customer customer2 = new Customer() { CustomerId = 2, FirstName = "Ben", LastName = "Smith", Email = "ben.smith@gmail.com", BirthYear = 1983 };
            Customer customer3 = new Customer() { CustomerId = 3, FirstName = "Elliot", LastName = "Alderson", Email = "fsociety@ecorp.com", BirthYear = 1986 };
            #endregion

            #region Tattoos
            Tattoo tattoo1 = new Tattoo() { TattooId = 1, FantasyName = "BigSpider" };
            Tattoo tattoo2 = new Tattoo() { TattooId = 2, FantasyName = "SmallHeart" };
            Tattoo tattoo3 = new Tattoo() { TattooId = 3, FantasyName = "LittleTriangle" };
            #endregion

            #region JobsDones
            JobsDone jobsDone1 = new JobsDone() { JobsDoneId = 1, Cost = 14000, jobDate = new DateTime(2021, 01, 04) };
            JobsDone jobsDone2 = new JobsDone() { JobsDoneId = 2, Cost = 10000, jobDate = new DateTime(2021, 05, 12) };
            JobsDone jobsDone3 = new JobsDone() { JobsDoneId = 3, Cost = 25000, jobDate = new DateTime(2021, 05, 23) };
            JobsDone jobsDone4 = new JobsDone() { JobsDoneId = 4, Cost = 12000, jobDate = new DateTime(2021, 10, 11) };
            #endregion

            #region ForeignKeySet
            jobsDone1.customerId = customer1.CustomerId;
            jobsDone2.customerId = customer2.CustomerId;
            jobsDone3.customerId = customer3.CustomerId;
            jobsDone4.customerId = customer1.CustomerId;

            jobsDone1.TattooId = tattoo2.TattooId;
            jobsDone2.TattooId = tattoo3.TattooId;
            jobsDone3.TattooId = tattoo1.TattooId;
            jobsDone4.TattooId = tattoo3.TattooId;
            #endregion

            List<Tattoo> items = new List<Tattoo>();
            items.Add(tattoo1);
            items.Add(tattoo2);
            items.Add(tattoo3);

            return items.AsQueryable();
        }

        #endregion
    }
}
