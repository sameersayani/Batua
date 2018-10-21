using Batua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Batua.DAL
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int userID);
        void InsertUser(User user);
        void DeleteUser(int userID);
        void UpdateUser(User user);
        void Save();
    }
}