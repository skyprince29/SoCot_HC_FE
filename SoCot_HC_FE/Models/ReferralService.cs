using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class ReferralService
    {
        public Guid ReferralId { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}