using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity8_22.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    /* The StudentID property is a foreign key, and teh corresponding navigation property is Student. An Enrollment entity is associated with one
     * Student entity, so the property can only hold a single Student entity (unlike the Student.Enrollments navigation property, which can hold
     * multiple Enrollment entities*/
    /*The CourseID property is a foreign key, and the corresponding navigation property is Course. An Enrollment entity is associated with one Course
     * entity*/
    /*Entity framework interprets a property as a foreign property if it's named <navigation property name><primary key property name> for example
     * StudentID for the Student navigation property since the Student entity's primary key is ID). Foreign key properties can also be named the same
     * simply <primary key property name> (for example, CourseID since the Course entity's primary key is CourseID)*/
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}