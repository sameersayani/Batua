using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Batua.Models;

namespace Batua.DAL
{
    public class UserRepository : GenericRepository<User>//IUserRepository, IDisposable
    {
        //private BatuaContext context;

        //public UserRepository(BatuaContext context)
        //{
        //    this.context = context;
        //}

        public UserRepository(BatuaContext context)
        : base(context)
        {
        }

        public void DeleteUser(int userID)
        {
            User user = context.User.Find(userID);
            context.User.Remove(user);
        }

        public User GetUserByID(int userID)
        {
            return context.User.Find(userID);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.User.ToList();
        }

        public void InsertUser(User user)
        {
            context.User.Add(user);
        }

        public void UpdateUser(User user)
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
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