using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Antra.Training.Contoso.Model.Common;

namespace Antra.Training.Contoso.Model
{
    public class Role : AuditableEntity
    {
        public Role()
        {
            CreatedDate = DateTime.Now;
        }

        [Required]
        public string RoleName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
