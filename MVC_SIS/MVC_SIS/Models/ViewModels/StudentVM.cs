using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Exercises.Models.Data;

namespace Exercises.Models.ViewModels
{
    public class StudentVM
    {
        public Student Student { get; set; }
        public List<System.Web.Mvc.SelectListItem> CourseItems { get; set; }
        public List<System.Web.Mvc.SelectListItem> MajorItems { get; set; }
        public List<System.Web.Mvc.SelectListItem> StateItems { get; set; }
        public List<int> SelectedCourseIds { get; set; }

        public StudentVM()
        {
            CourseItems = new List<System.Web.Mvc.SelectListItem>();
            MajorItems = new List<System.Web.Mvc.SelectListItem>();
            StateItems = new List<System.Web.Mvc.SelectListItem>();
            SelectedCourseIds = new List<int>();
            Student = new Student();
        }

        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                CourseItems.Add(new System.Web.Mvc.SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseName
                });
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            foreach (var major in majors)
            {
                MajorItems.Add(new System.Web.Mvc.SelectListItem()
                {
                    Value = major.MajorId.ToString(),
                    Text = major.MajorName
                });
            }
        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new System.Web.Mvc.SelectListItem()
                {
                    Value = state.StateAbbreviation,
                    Text = state.StateName
                });
            }
        }
    }
}