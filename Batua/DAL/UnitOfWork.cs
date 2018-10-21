﻿using Batua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Batua.DAL
{
    public class UnitOfWork : IDisposable
    {
        private BatuaContext context = new BatuaContext();
        private UserRepository userRepository;
        
        public UnitOfWork()
        {
            
        }

        public UserRepository UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}