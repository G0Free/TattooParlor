using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    public class TattooRepository : Repository<Tattoo>, ITattooRepository
    {
        public TattooRepository(DbContext ctx) : base(ctx)
        {

        }

        //Create
        public void AddNewTatto(Tattoo tattoo)
        {
            try
            {
                ctx.Add(tattoo);
            }
            catch (Exception e)
            {
                //here we can logging
            }
            ctx.SaveChanges();
        }

        //Read
        public override Tattoo GetOne(int id)
        {
            try
            {
                return GetAll().FirstOrDefault(x => x.TattoId == id);
            }
            catch (Exception)
            {
                //here we can logging
                return null;
            }
        }


        //Update
        public void UpdateTatto(Tattoo tattoo)
        {
            try
            {
                var toUpdate = GetOne(tattoo.TattoId);
                toUpdate.FantasyName = tattoo.FantasyName;
            }
            catch (Exception)
            {
                //logging                
            }
            ctx.SaveChanges();
        }
        public void ChangeFantasyName(int id, string newName)
        {
            try
            {
                var tattoo = GetOne(id);
                tattoo.FantasyName = newName;
            }
            catch (Exception)
            {
                //logging
            }
            ctx.SaveChanges();
        }


        //Delete
        public void DeleteTatto(int id)
        {
            try
            {
                var toDelete = GetOne(id);
                ctx.Remove(toDelete);
            }
            catch (Exception)
            {
                //logging
            }
            ctx.SaveChanges();
        }
    }
}
