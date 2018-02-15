using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    public class AttributeAppointment
    {
        //default errors will be shown if one is not specified as in [Required], using the Display field will make more sense, 
        //otherwise is would say " The ClientName field is required."
        [Required]
        [Display(Name = "name")] // adding this line, the error reads "the name field is required" instead of using the property name
        public string ClientName { get; set; }

        //UI hint filters the date so that no time is displayed
        [UIHint("Date")]
        [Required(ErrorMessage = "Please enter a date")]
        public DateTime Date { get; set; }
        
        //range sets a range of acceptable values. In this case -- from true to true.
        //[Range(typeof(bool), "true", "true", ErrorMessage = "Must accept the terms & conditions")]
        //this attribute is example of custom built from the "MustBeTrueAttribute" class, must apply using Infrastructure namespace
        [MustBeTrue]
        public bool TermsAccepted { get; set; }
    }
}
