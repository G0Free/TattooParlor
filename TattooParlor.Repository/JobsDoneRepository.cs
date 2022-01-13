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
            ctx.Add(newJobsDone);
            ctx.SaveChanges();
        }

        //Read
        public override JobsDone GetOne(int id)
        {
            return GetAll().FirstOrDefault(x => x.JobsDoneId == id);
        }

        //Update
        public void UpdateJobsDone(JobsDone jobsDone)
        {
            var toUpdate = GetOne(jobsDone.JobsDoneId);
            toUpdate.Cost = jobsDone.Cost;
            toUpdate.jobDate = jobsDone.jobDate;
            ctx.SaveChanges();
        }
        public void ChangeCost(int id, int newCost)
        {
            var tattoo = GetOne(id);
            tattoo.Cost = newCost;
            ctx.SaveChanges();
        }
        public void ChangeJobDate(int id, DateTime newJobDate)
        {
            var tattoo = GetOne(id);
            tattoo.jobDate = newJobDate;
            ctx.SaveChanges();
        }

        //Delete
        public void DeleteJobsDone(int id)
        {
            var toDelete = GetOne(id);
            ctx.Remove(toDelete);
            ctx.SaveChanges();
        }
    }
}
