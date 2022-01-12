using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Logic
{
    public interface ITattooLogic
    {
        //Create
        void AddNewTattoo(Tattoo tattoo);

        //Read
        Tattoo GetTattooById(int id);

        //ReadAll
        IEnumerable<Tattoo> GetAllTattoes();

        //Update
        void UpdateTattoo(Tattoo tattoo);
        void ChangeFantasyName(int id, string newName);

        //Delete
        void DeleteTatto(int id);
    }
}
