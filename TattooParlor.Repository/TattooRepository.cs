﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;

namespace TattooParlor.Repository
{
    public class TattooRepository : Repository<Tattoo>, ITattooRepository, ILogger
    {
        private readonly ILogger logger;
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
                logger.LogInformation(e.Message);
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
            catch (Exception e)
            {
                logger.LogInformation(e.Message);
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
            catch (Exception e)
            {
                //logging
                logger.LogInformation(e.Message);
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
                logger.LogInformation(e.Message);
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
            catch (Exception e)
            {
                //logging
                logger.LogInformation(e.Message);
            }
            ctx.SaveChanges();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }
    }
}
