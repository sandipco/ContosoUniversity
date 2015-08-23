using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity8_22.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First Name Cannot be longer than 50 characters")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        //The ApplyFormatInEditMode setting specifies that the specified formatting should also be applied when the value is displayed in a text box for editing.
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        //Navigation properties are typically defined as virtual so that they can take advantage of certain Entity Framework functionality such
        //as lazy loading. If a navigation property can hold multiple entities(as in many-to-many or one-to-many relationships), its type must be a list in
        //which entries can be added, deleted, and updated, such as ICollection
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}