﻿using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Data;
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
                newJobsDone.CreatedAt = DateTime.UtcNow;

                ctx.Add(newJobsDone);
            }
            catch (Exception e)
            {
                //logging
               // logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
            
            ctx.SaveChanges();
        }

        //Read
        public override JobsDone GetOne(int id)
        {
            try
            {
                //return GetAll().FirstOrDefault(x => x.JobsDoneId == id);
                return ((CompanyContext)ctx).JobsDones.FirstOrDefault(x => x.JobsDoneId == id);
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
                return null;
            }
        }

        //ReadAll
        public override IQueryable<JobsDone> GetAll()
        {
            try
            {                
                return ((CompanyContext)ctx).JobsDones.Where(x => x.IsDeleted == false);
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
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
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
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
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
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
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }

        //Delete
        public void DeleteJobsDone(int id)
        {
            try
            {
                var toDelete = GetOne(id);

                toDelete.IsDeleted = true;
                toDelete.DeletedAt = DateTime.UtcNow;

                //ctx.Remove(toDelete);
            }
            catch (Exception e)
            {               
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }
    }
}
