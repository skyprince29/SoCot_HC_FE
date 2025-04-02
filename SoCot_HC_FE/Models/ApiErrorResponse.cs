using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Models
{
    public class ApiErrorResponse
    {
        public bool success { get; set; }
        public Dictionary<string, string[]> errors { get; set; }
    }
}