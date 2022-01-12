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
        void ChangeJobDate(int id, DateTime newJobDate);
        void ChangeCost(int id, int newCost);
        void AddNewJobsDone(JobsDone newJobsDone);
        void UpdateJobsDone(JobsDone jobsDone);
        void DeleteJobsDone(int id);
    }
}
