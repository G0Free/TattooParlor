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
        public TattooRepository(DbContext ctx) : base(ctx)
        {            
        }

        //Create
        public void AddNewTattoo(Tattoo tattoo)
        {
            try
            {
                tattoo.CreatedAt = DateTime.UtcNow;

                ctx.Add(tattoo);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
               Log.Error(e, e.Message);
            }            
        }

        //Read
        public override Tattoo GetOne(int id)
        {
            try
            {
                return ((CompanyContext)ctx).Tattoos.FirstOrDefault(x => x.TattooId == id);
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
                return null;
            }
        }

        //ReadAll
        public override IQueryable<Tattoo> GetAll()
        {
            try
            {                
                return ((CompanyContext)ctx).Tattoos.Where(x => x.IsDeleted == false);
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return null;
            }
        }

        //Update
        public void UpdateTattoo(Tattoo tattoo)
        {
            try
            {
                var toUpdate = GetOne(tattoo.TattooId);
                toUpdate.FantasyName = tattoo.FantasyName;
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);                
            }
            
        }
        public void ChangeFantasyName(int id, string newName)
        {
            try
            {
                var tattoo = GetOne(id);
                tattoo.FantasyName = newName;

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
            }
        }

        //Delete
        public void DeleteTattoo(int id)
        {
            try
            {
                var toDelete = GetOne(id);

                toDelete.IsDeleted = true;
                toDelete.DeletedAt = DateTime.UtcNow;

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
            }            
        }
    }
}
