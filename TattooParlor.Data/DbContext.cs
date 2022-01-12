using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Data
{
    class CompanyContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<JobsDone> JobsDones { get; set; }
        public virtual DbSet<Tattoo> Tattoos { get; set; }

        public CompanyContext()
        {
            this.Database.EnsureCreated();
        }

        public CompanyContext(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TattooParlor_Database.mdf;Integrated Security=True";
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Customers
            Customer customer1 = new Customer() { FirstName = "Adam", LastName = "Test", Email = "adam.test@testemail.com", BirthYear = 1998 };
            Customer customer2 = new Customer() { FirstName = "Ben", LastName = "Smith", Email = "ben.smith@gmail.com", BirthYear = 1983 };
            Customer customer3 = new Customer() { FirstName = "Elliot", LastName = "Alderson", Email = "fsociety@ecorp.com", BirthYear = 1986 };
            #endregion

            #region Tattoos
            Tattoo tattoo1 = new Tattoo() { FantasyName = "BigSpider" };
            Tattoo tattoo2 = new Tattoo() { FantasyName = "SmallHeart" };
            Tattoo tattoo3 = new Tattoo() { FantasyName = "BigSpider" };
            #endregion

            #region JobsDones
            JobsDone jobsDone1 = new JobsDone() { Cost = 14000, jobDate = new DateTime(2021, 01, 04) };
            JobsDone jobsDone2 = new JobsDone() { Cost = 10000, jobDate = new DateTime(2021, 05, 12) };
            JobsDone jobsDone3 = new JobsDone() { Cost = 25000, jobDate = new DateTime(2021, 05, 23) };
            JobsDone jobsDone4 = new JobsDone() { Cost = 12000, jobDate = new DateTime(2021, 10, 11) };
            #endregion

            #region ForeignKeySet
            jobsDone1.customerId = customer1.CustomerId;
            jobsDone2.customerId = customer2.CustomerId;
            jobsDone3.customerId = customer3.CustomerId;
            jobsDone4.customerId = customer1.CustomerId;

            jobsDone1.TattooId = tattoo2.TattoId;
            jobsDone2.TattooId = tattoo3.TattoId;
            jobsDone3.TattooId = tattoo1.TattoId;
            jobsDone4.TattooId = tattoo3.TattoId;
            #endregion

            modelBuilder.Entity<JobsDone>(entity =>
           {
               entity
               .HasOne(job => job.customer)
               .
           }


                );

            modelBuilder.Entity<Customer>().HasData(customer1, customer2, customer3);
            modelBuilder.Entity<Tattoo>().HasData(tattoo1, tattoo2, tattoo3);
            modelBuilder.Entity<JobsDone>().HasData(jobsDone1, jobsDone2, jobsDone3, jobsDone4);
        }
    }
}
