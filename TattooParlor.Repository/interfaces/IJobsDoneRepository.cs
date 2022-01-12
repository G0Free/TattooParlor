using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    public interface IJobsDoneRepository : IRepository<JobsDone>
    {
        //Create
        void AddNewJobsDone(JobsDone newJobsDone);

        //Update
        void UpdateJobsDone(JobsDone jobsDone);
        void ChangeJobDate(int id, DateTime newJobDate);
        void ChangeCost(int id, int newCost);        
        

        //Delete
        void DeleteJobsDone(int id);
    }
}
