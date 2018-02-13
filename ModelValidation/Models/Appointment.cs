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
        [Required]
        [Display(Name = "name")] // adding this line, the error reads "the name field is required" instead of using the property name
        public string ClientName { get; set; }

        [UIHint("Date")]
        [Required(ErrorMessage = "Please enter a date")]
        public DateTime Date { get; set; }
        
        //range sets a range of acceptable values. In this case -- from true to true.
        [Range(typeof(bool), "true", "true", ErrorMessage = "Must accept the terms & conditions")]
        public bool TermsAccepted { get; set; }
    }
}
