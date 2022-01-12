using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    interface ITattooRepository : IRepository<Tattoo>
    {
        void ChangeFantasyName(int id, string newName);
        void AddNewTatto(Tattoo tattoo);
        void UpdateTatto(Tattoo tattoo);
        void DeleteTatto(int id);
    }
}
