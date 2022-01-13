using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Threading;
using TattooParlor.Models;

namespace TattooParlor.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(8000); //endpoint needs more time to start

            RestService rserv = new RestService("http://localhost:20358"); //from Endpoint launchSettings.json

            var menu = new ConsoleMenu()
                .Add(">> LIST ALL CUSTOMERS", () => ListAllCustomers(rserv))
                .Add(">> LIST ALL TATTOOS", () => ListAllTattoo(rserv))
                .Add(">> LIST ALL JOBS DONE", () => ListAllJobsDone(rserv))
                
                .Add("", () => Console.WriteLine())

                .Add(">> CUSTOMER BY ID", () => CustomerById(rserv))
                .Add(">> TATTOO BY ID", () => TattooById(rserv))
                .Add(">> JOBS BY ID", () => JobsById(rserv))

                .Add("", () => Console.WriteLine())

                .Add(">> ADD NEW CUSTOMER", () => AddNewCustomer(rserv))
                .Add(">> ADD NEW TATTOO", () => AddNewTattoo(rserv))
                .Add(">> ADD NEW JOB", () => AddNewJob(rserv))

                .Add("", () => Console.WriteLine())

                .Add(">> DELETE A CUSTOMER", () => DeleteCustomerById(rserv))
                .Add(">> DELETE A TATTOO", () => DeleteTattooById(rserv))
                .Add(">> DELETE A JOB", () => DeleteJobById(rserv))

                .Add("", () => Console.WriteLine())

                .Add(">> COUNT ALL JOBS BY ONE CUSTOMER", () => CountAllJobsByOneCustomer(rserv))
                .Add(">> LIST ALL JOBS BY ONE CUSTOMER", () => GetAllJobsByOneCustomer(rserv))

                .Add("", () => Console.WriteLine())

                .Add(">> EXIT", ConsoleMenu.Close)
                ;

            menu.Show();
        }

        #region LISTS
        private static void ListAllCustomers(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: ALL CUSTOMERS ::\n");

            var customers = rserv.Get<Customer>("customer");
            foreach (var item in customers)
            {
                Console.WriteLine(item.MainData);
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void ListAllTattoo(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: ALL TATTOO ::\n");

            var tattoos = rserv.Get<Tattoo>("tattoo");
            foreach (var item in tattoos)
            {
                Console.WriteLine(item.MainData);
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void ListAllJobsDone(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: ALL JOBS DONE ::\n");

            var jobs = rserv.Get<JobsDone>("jobsdone");
            foreach (var item in jobs)
            {
                Console.WriteLine(item.MainData);
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }
        #endregion

        #region SEARCH
        private static void CustomerById(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: CUSTOMER BY ID ::\n");

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenCustomer = rserv.Get<Customer>(choosenId, "customer");
            Console.WriteLine(choosenCustomer.MainData);

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void TattooById(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: TATTOO BY ID ::\n");

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenTattoo = rserv.Get<Tattoo>(choosenId, "tattoo");
            Console.WriteLine(choosenTattoo.MainData);

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void JobsById(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: JOBS BY ID ::\n");

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenJob = rserv.Get<JobsDone>(choosenId, "jobsdone");
            Console.WriteLine(choosenJob.MainData);

            Console.WriteLine();
            Console.WriteLine(choosenJob.customer.MainData);
            Console.WriteLine(choosenJob.tattoo.MainData);

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }
        #endregion

        #region ADD
        private static void AddNewCustomer(RestService rserv)
        {
            Console.Clear();

            Customer customer = new Customer();          

            Console.WriteLine("Firstname:");
            customer.FirstName = Console.ReadLine();

            Console.WriteLine("Lastname:");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("Email:");
            customer.Email = Console.ReadLine();

            Console.WriteLine("Birthyear:");
            customer.BirthYear = int.Parse(Console.ReadLine());

            rserv.Post<Customer>(customer, "customer");

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void AddNewTattoo(RestService rserv)
        {
            Console.Clear();

            Tattoo tattoo = new Tattoo();          

            Console.WriteLine("Fantasy name:");
            tattoo.FantasyName = Console.ReadLine();

            rserv.Post<Tattoo>(tattoo, "tattoo");
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void AddNewJob(RestService rserv)
        {
            Console.Clear();

            JobsDone job = new JobsDone();

            ListAllCustomers(rserv);
            Console.WriteLine("CustomerID:");
            job.customerId = int.Parse(Console.ReadLine());

            Console.Clear();

            ListAllTattoo(rserv);
            Console.WriteLine("TattooID:");
            job.TattooId = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Date:");
            job.jobDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Cost:");
            job.Cost = int.Parse(Console.ReadLine());

            rserv.Post<JobsDone>(job, "jobsdone");
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }
        #endregion

        #region DELETE
        private static void DeleteCustomerById(RestService rserv)
        {
            Console.Clear();

            ListAllCustomers(rserv);

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenItem = rserv.Get<Customer>(choosenId, "customer");
            Console.WriteLine(choosenItem.MainData + " got deleted");

            rserv.Delete(choosenId, "customer");
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void DeleteTattooById(RestService rserv)
        {
            Console.Clear();

            ListAllTattoo(rserv);

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenItem = rserv.Get<Tattoo>(choosenId, "tattoo");
            Console.WriteLine(choosenItem.MainData + " got deleted");

            rserv.Delete(choosenId, "tattoo");
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void DeleteJobById(RestService rserv)
        {
            Console.Clear();

            ListAllJobsDone(rserv);

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var choosenItem = rserv.Get<JobsDone>(choosenId, "jobsdone");
            Console.WriteLine(choosenItem.MainData + " got deleted");

            rserv.Delete(choosenId, "jobsdone");

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }
        #endregion

        #region non-CRUDs
        private static void GetAllJobsByOneCustomer(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: LIST ALL JOBS BY ONE CUSTOMER  ::\n");

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            Console.Clear();

            var customer = rserv.Get<Customer>(choosenId, "customer");
            Console.WriteLine(customer.MainData);
            Console.WriteLine();
           
            var result = rserv.Get<IList<JobsDone>>(choosenId, "stat/GetAllJobsByOneCustomer");

            Console.WriteLine($"Number of results: {result.Count}");            
            List<Tattoo> tattoos = new List<Tattoo>();
            foreach (var item in result)
            {
                tattoos.Add(item.tattoo);
                Console.WriteLine(item.MainData);
            }

            Console.WriteLine("\nTattoos:");
            foreach (var item in tattoos)
            {
                Console.WriteLine(item.MainData);
            }

            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        private static void CountAllJobsByOneCustomer(RestService rserv)
        {
            Console.Clear();
            Console.WriteLine("\n:: COUNT ALL JOBS BY ONE CUSTOMER   ::\n");

            Console.WriteLine("ID:");
            int choosenId = int.Parse(Console.ReadLine());

            var result = rserv.Get<int>(choosenId, "stat/CountAllJobsByOneCustomer");

            Console.WriteLine($"The result is: {result}");


            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue!");
            Console.ReadLine();
        }

        #endregion
    }
}
