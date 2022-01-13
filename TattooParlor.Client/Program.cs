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
                .Add(">> LIST ALL CUSTOMERS", () => );

            private static void ListAllCustomers(RestService rserv)
            {
                Console.Clear();
                Console.WriteLine("\n:: ALL CUSTOMERS ::\n");

                var customers = rserv.Get<Customer>("customer");
                foreach (var item in customers)
                {

                }
            }

        }
    }
}
