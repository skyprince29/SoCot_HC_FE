using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class SchoolAgeProfile
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        //public Patient Patient { get; set; }
        public string PatientAge { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherMiddleName { get; set; }
        public string MotherLastName { get; set; }
        public string EducationalLevel { get; set; }
        public string Grade { get; set; }
        public string SchoolYear { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SAPDateRecorded { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public int? userID { get; set; }
        //public User User { get; set; }


        [ForeignKey("Facility")]
        public int? FacilityId { get; set; }
        //public Facility Facility { get; set; }
    }
}