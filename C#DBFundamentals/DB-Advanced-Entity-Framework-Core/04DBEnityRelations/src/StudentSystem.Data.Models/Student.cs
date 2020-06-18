using System;
using System.Collections.Generic;

namespace StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.CourseEnrollments = new HashSet<StudentCourse>();
            this.HomeworkSubmissions = new HashSet<Homework>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistratedOn { get; set; }

        public DateTime? BirthDay { get; set; }

        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }

        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
