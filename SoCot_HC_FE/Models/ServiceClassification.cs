using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class ServiceClassification
    {
        public int ServiceClassificationId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}