﻿using System;

namespace Antra.Training.Contoso.Model.Common
{
    public interface IAuditableEntity
    {
        DateTime? CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
}
