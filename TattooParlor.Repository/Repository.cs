using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public IQueryable<T> GetAll()
        {
            try
            {
                return ctx.Set<T>();
            }
            catch (Exception e)
            {
              //  logger.LogError(e.Message, e);
                return null;
            }            
        }

        public abstract T GetOne(int id);
        
    }
}
