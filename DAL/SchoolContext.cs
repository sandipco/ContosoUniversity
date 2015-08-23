using ContosoUniversity8_22.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ContosoUniversity8_22.DAL
{
    public class SchoolContext:DbContext
    {
        /*The name of the connection string is passed in to the constructor. I could pass in the connection string itself instead of the name of
         one that is stored in the Web.config file. If I had not specified the connection string, EF assumes that the connection string name is the same as
         the class name. The default connection string name in this example would then be SchoolContext*/
        public SchoolContext()
            : base("SchoolContext")
        {

        }
        /*In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table
         I could have ommitted the DbSet<Enrollment> and DbSet<Course> statements and it would work the same. The Entity Framework would include them
         implicitly because the Student entity references the Enrollment entity and the Enrollment entity references the Course entity*/
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        //To prevent the table names from being pluralized
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Course>()
                 .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                 .Map(t => t.MapLeftKey("CourseID")
                     .MapRightKey("InstructorID").ToTable("CourseInstructor"));
            modelBuilder.Entity<Department>().MapToStoredProcedures();
        }
    }
}