using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Antra.Training.Contoso.Model
{
    [Table("Student")]
    public class Student : Person
    {
        public Student() => CreatedDate = DateTime.Now;

        public DateTime? EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
