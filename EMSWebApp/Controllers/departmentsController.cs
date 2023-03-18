using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMSWebApp.Data;
using EMSWebApp.Models;
using EMSWebApp.Repository;
using System.Security.Policy;

namespace EMSWebApp.Controllers
{
    public class departmentsController : Controller
    {
        IEMSRepository _repo;

        public departmentsController(IEMSRepository repo)
        {
            _repo = repo;
        }

        public IActionResult index()
        {
            var deptlist = _repo.index();
            return View(deptlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(department newDept) // model binded this where the views data is accepted 
        {
            //if (ModelState.IsValid)//eto tinanggal ko
           // {
                var todo = _repo.Adddepartment(newDept);
                return RedirectToAction("index");
           // }
           ViewData["Message"] = "Data is not valid to create the Department";
          //  return View();
        }

        public IActionResult Delete(int deptId)
        {
            var dep = _repo.DeleteDept(deptId);
            return RedirectToAction(controllerName: "departments", actionName: "index"); // reload the getall page it self
        }
        [HttpGet]
        public IActionResult edit(int deptId)
        {
            var oldDept = _repo.GetDeptById(deptId);
            return View(oldDept);
        }
        [HttpPost]
        public IActionResult edit( department dept)
        {
            var dep = _repo.editDept(dept.Id, dept);
            return RedirectToAction("index");
        }

       public IActionResult Details(int deptId)
       {
            var dept = _repo.GetDeptById(deptId);
            return View(dept);
        }
    }
}
