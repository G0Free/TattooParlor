using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    public class JobsDoneRepository : Repository<JobsDone>, IJobsDoneRepository
    {
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
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                //logging
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
            catch (Exception)
            {
                //logging
            }
            ctx.SaveChanges();
        }
    }
}
