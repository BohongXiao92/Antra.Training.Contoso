using System;
using System.ComponentModel.DataAnnotations;

namespace Antra.Training.Contoso.Model.Common
{
    public class AuditableEntity : Entity, IAuditableEntity
    {
        public DateTime? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [MaxLength(20)]
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DateTime? UpdatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [MaxLength(20)]
        public string UpdatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
