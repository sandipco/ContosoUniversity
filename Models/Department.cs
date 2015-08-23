using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ContosoUniversity8_22.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        /* the Column attribute is being used to change SQL data type mapping so that 
         * the column will be defined using the SQL Server money type in the database*/
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }
        
        public virtual Instructor Administrator { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
