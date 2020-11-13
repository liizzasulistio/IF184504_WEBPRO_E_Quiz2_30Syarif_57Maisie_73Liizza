using System;
using DFI_Project.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DFI_Project.Controllers
{
    public class UserController : Controller
    {
        UserDAL userDAL = new UserDAL();
        public IActionResult Index()
        {
            List<User> empList = new List<User>();
            empList = userDAL.GetAllUser().ToList();
            return View(empList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] User objEmp)
        {
            if (ModelState.IsValid)
            {
                userDAL.AddUser(objEmp);
                return RedirectToAction("Index");
            }
            return View(objEmp);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User emp = userDAL.GetUserByID((int)id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] User objEmp)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                userDAL.UpdateUser(objEmp);
                return RedirectToAction("Index");
            }
            return View(userDAL);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User emp = userDAL.GetUserByID((int)id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User emp = userDAL.GetUserByID((int)id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(int id)
        {
            userDAL.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
