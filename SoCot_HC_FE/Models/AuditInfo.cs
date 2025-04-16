using System;

namespace SoCot_HC_FE.Models
{
    public abstract class AuditInfo
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
} 