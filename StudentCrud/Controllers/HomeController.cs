using Microsoft.AspNetCore.Mvc;
using StudentCrud.Data;
using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.Controllers
{
    public class HomeController : Controller
    {
        StudentRepository repo;

        public HomeController(StudentRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            repo.AddStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult GetAll()
        {
            return View(repo.GetAll());
        }

        public IActionResult Delete(string id)
        {
            repo.DeleteStudentById(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult Print(string id)
        {
            var stud = repo.GetStudentById(id);
            return View(stud);
        }

        public IActionResult Modify(string id)
        {
            var student = repo.GetStudentById(id);

            ViewData["headertext"] = "Modify data for: " + student.Name;

            return View(student);
        }

        [HttpPost]
        public IActionResult Modify(Student newstudent)
        {
            if (!ModelState.IsValid)
            {
                return View(newstudent);
            }

            try
            {
                repo.DeleteStudentById(newstudent.NeptunCode);
                repo.AddStudent(newstudent);
            }
            catch(Exception e)
            {
                //saját hibakóddal visszatérés
                return StatusCode(777);
            }
            
            
            return RedirectToAction("GetAll");
        }


    }
}
