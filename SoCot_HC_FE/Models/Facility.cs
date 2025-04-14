using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace SoCot_HC_FE.Models
{
    public class Facility
    {
       
          
            public Guid Id { get; set; }
            public string AccreditationNo { get; set; }
            public string FacilityName { get; set; }
            public string Street { get; set; }
            public string EmailAddress { get; set; }
            public string TelephoneNumber { get; set; }
            public string ContactNumber { get; set; }
            public string Sector { get; set; }
            public Guid AddressId { get; set; }
            public int BarangayId { get; set; }
            public int? city_municipality_id { get; set; }
            public int? province_id { get; set; }
            public string Zipcode { get; set; }
            public string CipherKey { get; set; }
            public bool? Status { get; set; } = true;
            public string TypeofFacility { get; set; }

       

        [NotMapped]
            public static List<string> Levels = new List<string> { "LEVEL 0", "LEVEL 1", "LEVEL 2", "LEVEL 3", "APEX" };
        
    }

   
}