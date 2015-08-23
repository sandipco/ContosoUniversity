using ContosoUniversity8_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity8_22.ViewModels
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}