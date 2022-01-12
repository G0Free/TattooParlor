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
        void AddNewTatto(Tattoo tattoo);

        //Update
        void UpdateTatto(Tattoo tattoo);
        void ChangeFantasyName(int id, string newName);
        
        //Delete
        void DeleteTatto(int id);
    }
}
