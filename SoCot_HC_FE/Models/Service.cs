using System;

namespace SoCot_HC_FE.Models
{
    public class Service : AuditInfo
    {
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
        public int ServiceClassificationId { get; set; }
        public ServiceClassification ServiceClassification { get; set; }
        public bool IsActive { get; set; }
    }
}