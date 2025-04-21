using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class WRA
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Patient")]
        public Guid? PatientId { get; set; }
        //public Patient Patient { get; set; }

        //WRA PROFILE
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WraDateOfAssessment { get; set; } = DateTime.Now;
        public string Fecundity { get; set; }
        public bool HavePartner { get; set; }
        public bool WraPlanToHaveMoreChildren { get; set; }
        public string WraPlanToHveMoreChildrenDecision { get; set; }
        public bool ForCounseling { get; set; }
        public bool UsingAnyFPMethod { get; set; }
        public string FPType { get; set; }
        public string FPMethod { get; set; }
        public bool ShiftToModernMethod { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WraDateRecorded { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public int? userID { get; set; }
        //public User User { get; set; }


        [ForeignKey("Facility")]
        public int? FacilityId { get; set; }
        //public Facility Facility { get; set; }
    }
}