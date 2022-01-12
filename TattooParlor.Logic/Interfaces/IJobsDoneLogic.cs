﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Logic
{
    public interface IJobsDoneLogic
    {
        //Create
        void AddNewJobsDone(JobsDone jobsDone);

        //Read
        JobsDone GetJobsDoneById(int id);

        //ReadAll
        IEnumerable<JobsDone> GetAllJobsDone();

        //Update
        void UpdateJobsDone(JobsDone jobsDone);
        void ChangeCost(int id, int newCost);
        void ChangeJobDate(int id, DateTime newJobDate);

        //Delete
        void DeleteJobsDone(int id);
    }
}