using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using static System.Collections.Specialized.BitVector32;

namespace SoCot_HC_FE.Models
{
    public class Facility : AuditInfo
    {

        public int FacilityId { get; set; }

        public string AccreditationNo { get; set; }

        public string FacilityName { get; set; }

        public string EmailAddress { get; set; }

        public string TINNumber { get; set; }

        public string ContactNumber { get; set; }


        public string Sector { get; set; }

        public string FacilityLevel { get; set; }
        public bool IsActive { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public string FacilityCode {  get; set; }


    }


}