using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class Address
    {
        public Guid Address_id { get; set; }

        public int barangay_id { get; set; }


        public int city_municipality_id { get; set; }
        public CityMunicipality CityMunicipality { get; set; }

        public string barangay_name { get; set; }
        public int province_code { get; set; }
        public int city_municipality_code { get; set; }
        public int barangay_code { get; set; }
        public int population_count { get; set; }
    }
}