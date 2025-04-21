using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class Address
    {
        public Guid AddressId { get; set; }

        public int BarangayId { get; set; }
        public int MunicipalityId { get; set; }
        public int ProvinceId { get; set; }
        public string SitioPurok { get; set; }
        public string ZipCode { get; set; }
        public string HouseNo { get; set; }
        public string LotNo { get; set; }
        public string BlockNo { get; set; }
        public string Street { get; set; }
        public string Subdivision { get; set; }
    }
}