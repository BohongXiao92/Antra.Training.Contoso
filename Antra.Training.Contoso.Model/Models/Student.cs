using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Antra.Training.Contoso.Model
{
    [Table("Student")]
    public class Instructor : Person
    {
        public Instructor() => CreatedDate = DateTime.Now;

        public DateTime? EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
