using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooParlor.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext ctx;
        //private readonly ILogger<Repository<T>> logger;
        protected Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }
        /*
        public IQueryable<T> GetAll()
        {
            try
            {
                return ctx.Set<T>();
                //return ctx.Set<T>().Where(x => x.IsDeleted == false);
            }
            catch (Exception e)
            {                
                Log.Error(e, e.Message);
                return null;
            }
        }*/
        public abstract IQueryable<T> GetAll();

        public abstract T GetOne(int id);

    }
}
