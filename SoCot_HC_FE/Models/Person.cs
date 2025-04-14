using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Suffix { get; set; }
        public string Birthdate { get; set; }
        public string BirthPlace { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string Religion { get; set; }
        public string  ContactNo { get; set; }
        public string Email { get; set; }
        public Guid AddressIdResidential { get; set; }
        public Address AddressResidential {  set; get; }
        public Guid AddressIdPermanent { get; set; }
        public Address AddressPermanent { set; get; }
        public bool IsDeceased { get; set; }
        public bool BloodType { get; set; }
    }
}