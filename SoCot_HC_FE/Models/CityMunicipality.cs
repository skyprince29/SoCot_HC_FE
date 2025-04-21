using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
      public class Municipality
    {

        public int MunicipalityId { get; set; }
        public int ProvinceId { get; set; }
        public virtual  Province Province { get; set; }
        public  string MunicipalityName { get; set; }

        [InverseProperty("Municipality")]
        public virtual ICollection<Address> Address { get; set; } = new List<Address>();
    }
}