using Antra.Training.Contoso.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Antra.Training.Contoso.Model
{
    public class Department : AuditableEntity
    {
        public Department() => CreatedDate = DateTime.Now;

        [MaxLength(150)]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }
        public int? InstructorId { get; set; }
        public byte[] RowVersion { get; set; }

        public Instructor Instructors { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
