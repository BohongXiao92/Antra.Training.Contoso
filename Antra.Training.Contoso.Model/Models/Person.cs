using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Antra.Training.Contoso.Model.Common;

namespace Antra.Training.Contoso.Model
{
    public abstract class Person : AuditableEntity
    {
        [Required]
        [StringLength(50)]
        [MaxLength(150)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(150)]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string MiddleName { get; set; }

        public string FullName => LastName + ", " + FirstName;

        [Display(Name = "DateofBirth")]
        public DateTime DateofBirth { get; set; }

        [Display(Name = "Email")]
        [MaxLength(150)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [MaxLength(150)]
        public string Phone { get; set; }

        [MaxLength(150)]
        public string AddressLine1 { get; set; }

        [MaxLength(150)]
        public string AddressLine2 { get; set; }

        [MaxLength(50)]
        [DisplayName("Unit")]
        public string UnitOrApartmentNumber { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        [MaxLength(20)]
        public string ZipCode { get; set; }

        [DisplayName("Password")]
        [MaxLength(20)]
        [MinLength(8)]
        [Required]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public string Salt { get; set; }

        [ScaffoldColumn(false)]
        public bool IsLocked { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? LastLockedDateTime { get; set; }

        [ScaffoldColumn(false)]
        public int? FailedAttempts { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
