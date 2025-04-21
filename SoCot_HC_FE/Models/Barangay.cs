using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class Barangay
    {
        public int BarangayId { get; set; }
        public  string BarangayName { get; set; }
        public int MunicipalityId { get; set; }
        public virtual  Municipality Municipality { get; set; }
        public virtual ICollection<Address> Address { get; set; } = new List<Address>();
    }
}