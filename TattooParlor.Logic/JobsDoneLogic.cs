﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;
using TattooParlor.Repository;

namespace TattooParlor.Logic
{
    public class JobsDoneLogic : IJobsDoneLogic
    {        
        IJobsDoneRepository jobRepo;
        public JobsDoneLogic(IJobsDoneRepository jobRepo)
        {
            this.jobRepo = jobRepo;
        }

        #region CRUD methods
        //Create
        public void AddNewJobsDone(JobsDone jobsDone)
        {
            jobRepo.AddNewJobsDone(jobsDone);
        }

        //Read
        public JobsDone GetJobsDoneById(int id)
        {
            if (id <= jobRepo.GetAll().Count())
            {
                return jobRepo.GetOne(id);
            }
            throw new IndexOutOfRangeException("Invalid ID");
        }

        //ReadAll
        public IEnumerable<JobsDone> GetAllJobsDone()
        {
            return jobRepo.GetAll();
        }

        //Update
        public void UpdateJobsDone(JobsDone jobsDone)
        {
            jobRepo.UpdateJobsDone(jobsDone);
        }
        public void ChangeCost(int id, int newCost)
        {
            jobRepo.ChangeCost(id, newCost);
        }
        public void ChangeJobDate(int id, DateTime newJobDate)
        {
            jobRepo.ChangeJobDate(id, newJobDate);
        }

        //Delete
        public void DeleteJobsDone(int id)
        {
            jobRepo.DeleteJobsDone(id);
        }
        #endregion

        #region non-CRUD methods

        public IList<JobsDone> GetAllJobsByOneCustomer(int id)
        {
            var q = from x in jobRepo.GetAll()
                    where x.customerId == id
                    select x;
            return q.ToList();
        }

        public int CountAllJobsByOneCustomer(int id)
        {
            // IList<JobsDone> alljobsby = GetAllJobsByOneCustomer(id);
            var q = from x in jobRepo.GetAll()
                    where x.customerId == id
                    select x;
            
            return q.Count();
        }

        #endregion
    }
}
