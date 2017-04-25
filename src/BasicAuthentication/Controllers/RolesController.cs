using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAuthentication.Controllers
{
    public class RolesController : Controller
    {
        public ApplicationDbContext _db = new ApplicationDbContext();
        //private readonly ApplicationDbContext _db;

        // GET: /<controller>/
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        // GET: /Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Roles/Create
        //[HttpPost]
        //public IActionResult Create(FormCollection collection)
        //{
        //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));

        //    var role = new IdentityRole() { Name = "Admin" }; 
        //    _db.Roles.Add(role);
        //    _db.SaveChanges();
        //    ViewBag.ResultMessage = "Role created successfully !";
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                _db.Roles.Add(new IdentityRole()
                {
                    Name = "admin"
                });
                _db.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(string RoleName)
        {
            var thisRole = _db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _db.Roles.Remove(thisRole);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
