using Antra.Training.Contoso.Model.Common;
using System;

namespace Antra.Training.Contoso.Model
{
    public class Enrollment : AuditableEntity
    {
        public Enrollment() => CreatedDate = DateTime.Now;
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Instructor Student { get; set; }
    }

    public enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }
}
