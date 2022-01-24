using System;
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
        ICustomerRepository customerRepo;
        IJobsDoneRepository jobRepo;
        ITattooRepository tattooRepo;
        public JobsDoneLogic(IJobsDoneRepository jobRepo)
        {
            this.jobRepo = jobRepo;
        }

        public JobsDoneLogic(ICustomerRepository customerRepo, IJobsDoneRepository jobRepo, ITattooRepository tattooRepo)
        {
            this.customerRepo = customerRepo;
            this.jobRepo = jobRepo;
            this.tattooRepo = tattooRepo;
        }

        #region CRUD methods
        //Create
        public JobsDone AddNewJobsDone(JobsDone jobsDone)
        {
            jobRepo.AddNewJobsDone(jobsDone);

            return jobsDone;
        }

        //Read
        public JobsDone GetJobsDoneById(int id)
        {
            return jobRepo.GetOne(id);
            /*
            if (id <= jobRepo.GetAll().Count())
            {
                return jobRepo.GetOne(id);
            }
            throw new IndexOutOfRangeException("Invalid ID");
            */
        }

        //ReadAll
        public IEnumerable<JobsDone> GetAllJobsDone()
        {
            return jobRepo.GetAll();
        }

        //Update
        public JobsDone UpdateJobsDone(JobsDone jobsDone)
        {
            jobRepo.UpdateJobsDone(jobsDone);

            return jobsDone;
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
            var q = from x in jobRepo.GetAll()
                    where x.customerId == id
                    select x;

            return q.Count();
        }

        #endregion
    }
}
