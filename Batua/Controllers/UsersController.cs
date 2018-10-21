using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Batua.DAL;
using Batua.Models;

namespace Batua.Controllers
{
    public class UsersController : Controller
    {
        private UnitOfWork unitofWork = new UnitOfWork();
        //private IUserRepository userRepository;

        public UsersController()
        {
         //   this.userRepository = new UserRepository(new BatuaContext());
        }

        //public UsersController(IUserRepository userRepository)
        //{
        //    this.userRepository = userRepository;
        //}

       // private BatuaContext db = new BatuaContext();

        // GET: Users
        public ActionResult Index()
        {
            //return View(userRepository.GetUsers().ToList());
            var user = unitofWork.UserRepository.GetUsers().ToList();
            return View(user.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // User user = userRepository.GetUserByID((int)(id));
            User user = unitofWork.UserRepository.GetByID((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Mobile,Email")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //userRepository.InsertUser(user);
                    //userRepository.Save();
                    unitofWork.UserRepository.Insert(user);
                    unitofWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError(ex.Message, "Unable to save changes. Try again..");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  User user = userRepository.GetUserByID((int)id);
            User user = unitofWork.UserRepository.GetByID((int) id);
            unitofWork.Save();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,Mobile,Email")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //userRepository.UpdateUser(user);
                    //userRepository.Save();
                    unitofWork.UserRepository.Update(user);
                    unitofWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError(ex.Message, "Unable to save changes. Try again");
            }

            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  User user = userRepository.GetUserByID((int)id);
            User user = unitofWork.UserRepository.GetByID((int)id);
            
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //User user = userRepository.GetUserByID((int)id);
            //userRepository.DeleteUser((int)id);
            //userRepository.Save();
            User user = unitofWork.UserRepository.GetByID((int)id);
            unitofWork.UserRepository.Delete((int)id);
            unitofWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // userRepository.Dispose();
                unitofWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
