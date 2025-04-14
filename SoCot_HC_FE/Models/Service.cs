using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FacilityId { get; set; }
        public Facility Facility { get; set; }
        public int ServiceClassificationId { get; set; }
        public ServiceClassification ServiceClassification { get; set; }
    }
}