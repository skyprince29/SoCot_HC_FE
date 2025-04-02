using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class VitalSign
    {
        public long VitalSignId { get; set; }
        public decimal Temperature { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int RespiratoryRate { get; set; }
        public int CardiacRate { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
    }
}