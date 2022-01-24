using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    public interface ITattooRepository : IRepository<Tattoo>
    {
        //Create
        void AddNewTattoo(Tattoo tattoo);

        //Update
        void UpdateTattoo(Tattoo tattoo);
        void ChangeFantasyName(int id, string newName);
        
        //Delete
        void DeleteTattoo(int id);
    }
}
