using System;
using DFI_Project.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace DFI_Project.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        ProjectDAL projectDAL = new ProjectDAL();
        public IActionResult Index()
        {
            List<Project> empList = new List<Project>();
            empList = projectDAL.GetAllProject().ToList();
            return View(empList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Project objEmp)
        {
            if (ModelState.IsValid)
            {
                projectDAL.AddProject(objEmp);
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
            Project emp = projectDAL.GetProjectByID((int)id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] Project objEmp)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                projectDAL.UpdateProject(objEmp);
                return RedirectToAction("Index");
            }
            return View(projectDAL);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Project emp = projectDAL.GetProjectByID((int)id);
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
            Project emp = projectDAL.GetProjectByID((int)id);
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
            projectDAL.DeleteProject(id);
            return RedirectToAction("Index");
        }
    }
}
