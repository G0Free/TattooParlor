using ConsoleTools;
using System;
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
                
                .Add(">> EXIT", ConsoleMenu.Close)
                ;

            menu.Show();
        }

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
    }
}
