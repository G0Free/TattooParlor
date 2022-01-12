using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    class TattooRepository : Repository<Tattoo>, ITattooRepository
    {
        public TattooRepository(DbContext ctx) : base(ctx)
        {

        }

        //Create
        public void AddNewTatto(Tattoo tattoo)
        {
            ctx.Add(tattoo);
            ctx.SaveChanges();
        }

        //Read
        public override Tattoo GetOne(int id)
        {
            return GetAll().FirstOrDefault(x => x.TattoId == id);
        }


        //Update
        public void UpdateTatto(Tattoo tattoo)
        {
            var toUpdate = GetOne(tattoo.TattoId);
            toUpdate.FantasyName = tattoo.FantasyName;

            ctx.SaveChanges();
        }
        public void ChangeFantasyName(int id, string newName)
        {
            var tattoo = GetOne(id);
            tattoo.FantasyName = newName;
            ctx.SaveChanges();
        }


        //Delete
        public void DeleteTatto(int id)
        {
            var toDelete = GetOne(id);
            ctx.Remove(toDelete);
            ctx.SaveChanges();
        }
    }
}
