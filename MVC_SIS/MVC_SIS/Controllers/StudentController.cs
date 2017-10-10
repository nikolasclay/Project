using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM model)
        {
            if (ModelState.IsValid)
            {
                model.Student.Courses = new List<Course>();

                foreach (var id in model.SelectedCourseIds)
                    model.Student.Courses.Add(CourseRepository.Get(id));

                model.Student.Major = MajorRepository.Get(model.Student.Major.MajorId);

                StudentRepository.Add(model.Student);

                return RedirectToAction("List");

            }
            else
            {
                model.SetCourseItems(CourseRepository.GetAll());
                model.SetMajorItems(MajorRepository.GetAll());
                return View(model);
            }




        }
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var viewModel = new StudentVM();
            viewModel.Student = StudentRepository.Get(id);
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult EditStudent(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Models.Data.Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var student = StudentRepository.Get(id);
            return View();
        }
        [HttpPost]
        public ActionResult DeleteStudent(StudentVM studentVM)
        {
            StudentRepository.Delete(studentVM.Student.StudentId);
            return RedirectToAction("List");
        }
    }
}