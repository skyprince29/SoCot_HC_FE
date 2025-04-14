using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class Province
    {
    
        public int province_id { get; set; }
      
        public string province_name { get; set; }
        public int province_code { get; set; }
    }
}