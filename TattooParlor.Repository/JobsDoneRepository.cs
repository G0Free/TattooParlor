using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    public class JobsDoneRepository : Repository<JobsDone>, IJobsDoneRepository, ILogger
    {
        private readonly ILogger logger;
        public JobsDoneRepository(DbContext ctx): base(ctx)
        {

        }
        
        //Create
        public void AddNewJobsDone(JobsDone newJobsDone)
        {
            try
            {
                ctx.Add(newJobsDone);
            }
            catch (Exception e)
            {
                //logging
                logger.LogInformation(e.Message);
            }
            
            ctx.SaveChanges();
        }

        //Read
        public override JobsDone GetOne(int id)
        {
            try
            {
                return GetAll().FirstOrDefault(x => x.JobsDoneId == id);
            }
            catch (Exception e)
            {
                //logging
                logger.LogInformation(e.Message);
                return null;
            }
        }

        //Update
        public void UpdateJobsDone(JobsDone jobsDone)
        {
            try
            {
                var toUpdate = GetOne(jobsDone.JobsDoneId);
                toUpdate.Cost = jobsDone.Cost;
                toUpdate.jobDate = jobsDone.jobDate;
            }
            catch (Exception e)
            {
                //logging
                logger.LogInformation(e.Message);
            }
            ctx.SaveChanges();
        }
        public void ChangeCost(int id, int newCost)
        {
            try
            {
                var tattoo = GetOne(id);
                tattoo.Cost = newCost;
            }
            catch (Exception e)
            {
                //logging
                logger.LogInformation(e.Message);
            }
            ctx.SaveChanges();
        }
        public void ChangeJobDate(int id, DateTime newJobDate)
        {
            try
            {
                var tattoo = GetOne(id);
                tattoo.jobDate = newJobDate;
            }
            catch (Exception e)
            {
                //logging
                logger.LogInformation(e.Message);
            }
            ctx.SaveChanges();
        }

        //Delete
        public void DeleteJobsDone(int id)
        {
            try
            {
                var toDelete = GetOne(id);
                ctx.Remove(toDelete);
            }
            catch (Exception e)
            {
                //logging
                logger.LogInformation(e.Message);
            }
            ctx.SaveChanges();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }
    }
}
