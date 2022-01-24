using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;
using Serilog;
using TattooParlor.Data;

namespace TattooParlor.Repository
{
    public class TattooRepository : Repository<Tattoo>, ITattooRepository
    {
        //private readonly ILogger<TattooRepository> logger;

        private readonly CompanyContext ctx;
        public TattooRepository(CompanyContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }

        //Create
        public void AddNewTatto(Tattoo tattoo)
        {
            try
            {
                tattoo.CreatedAt = DateTime.UtcNow;

                ctx.Add(tattoo);
            }
            catch (Exception e)
            {
               Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }

        //Read
        public override Tattoo GetOne(int id)
        {
            try
            {
                // return GetAll().FirstOrDefault(x => x.TattooId == id);
                return ctx.Tattoos.FirstOrDefault(x => x.TattooId == id);
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
                return null;
            }
        }

        //Update
        public void UpdateTatto(Tattoo tattoo)
        {
            try
            {
                var toUpdate = GetOne(tattoo.TattooId);
                toUpdate.FantasyName = tattoo.FantasyName;
            }
            catch (Exception e)
            {
                //logging
                Log.Error(e, e.Message);
                //logger.LogError(e, e.Message);
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
            catch (Exception e)
            {
                //logging
                //logger.LogError(e, e.Message);
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }

        //Delete
        public void DeleteTatto(int id)
        {
            try
            {
                var toDelete = GetOne(id);

                toDelete.IsDeleted = true;
                toDelete.DeletedAt = DateTime.UtcNow;

                //ctx.Remove(toDelete);
            }
            catch (Exception e)
            {
                //logging
                Log.Error(e, e.Message);
            }
            ctx.SaveChanges();
        }
    }
}
