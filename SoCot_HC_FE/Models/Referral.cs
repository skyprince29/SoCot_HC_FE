using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class Referral
    {
        public Guid ReferralId { get; set; }
        public string Complains { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public int ReferredTo { get; set; }
        public Facility FacilityReferredTo { get; set; }
        public int ReferredFrom {  get; set; }
        public Facility FacilityReferredFrom { get; set; }
        public string ReferralNo { get; set; }
        public Guid PersonnelId { get; set; }
        public Person Personnel { get; set;}
        public bool IsAccepted { get; set; }
        public Guid AttendingPhysicianId { get; set; }
        public Person AttendingPhysician { get; set; }
        public Guid CreatedBy {  get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public long ReferrenceId { get; set; }
    }
}