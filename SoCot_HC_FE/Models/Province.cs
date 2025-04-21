using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class Province
    {
    
        public int ProvinceId { get; set; }
      
        public string ProvinceName { get; set; }
    }
}