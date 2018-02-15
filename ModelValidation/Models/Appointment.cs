using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidation.Models
{
    public class Appointment
    {
        //default errors will be shown if one is not specified, using the Display field will make more sense, 
        //otherwise is would say " The ClientName field is required."
        
        
        public string ClientName { get; set; }

        [UIHint("Date")]
        public DateTime Date { get; set; }
        
        //range sets a range of acceptable values. In this case -- from true to true.
        public bool TermsAccepted { get; set; }
    }
}
