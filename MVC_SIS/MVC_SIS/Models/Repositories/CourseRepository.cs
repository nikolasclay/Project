using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.Repositories
{
    public static class CourseRepository
    {
        private static List<SelectListItem> _courses;
        
        static CourseRepository()
        {
            // sample data
            _courses = new List<SelectListItem>
            {
                new SelectListItem { CourseId=1, CourseName="Art History" },
                new SelectListItem { CourseId=2, CourseName="Accounting 101" },
                new SelectListItem { CourseId=3, CourseName="Biology 101" },
                new SelectListItem { CourseId=4, CourseName="Business Law" },
                new SelectListItem { CourseId=5, CourseName="C# Fundamentals" },
                new SelectListItem { CourseId=6, CourseName="Economics 101" },
                new SelectListItem { CourseId=7, CourseName="Java Fundamentals" },
                new SelectListItem { CourseId=8, CourseName="Photography" }
            };
        }

        public static IEnumerable<SelectListItem> GetAll()
        {
            return _courses;
        }

        public static SelectListItem Get(int courseId)
        {
            return _courses.FirstOrDefault(c => c.CourseId == courseId);
        }

        public static void Add(string courseName)
        {
            SelectListItem course = new SelectListItem();
            course.CourseName = courseName;
            course.CourseId = _courses.Max(c => c.CourseId) + 1;

            _courses.Add(course);
        }

        public static void Edit(SelectListItem course)
        {
            var selectedCourse = _courses.FirstOrDefault(c => c.CourseId == course.CourseId);

            selectedCourse.CourseName = course.CourseName;
        }

        public static void Delete(int courseId)
        {
            _courses.RemoveAll(c => c.CourseId == courseId);
        }
    }
}