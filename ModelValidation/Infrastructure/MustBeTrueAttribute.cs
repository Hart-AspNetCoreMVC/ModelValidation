using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ModelValidation.Infrastructure
{
    public class MustBeTrueAttribute : Attribute, IModelValidator
    {   //this property just tells MVC that it needs to be validated first before less important stuff; not to be confused with the input is required
        public bool IsRequired => true;

        public string ErrorMessage { get; set; } = "this value must be true";

        //this validation method returns a sequence of ModelValidationResult objects that describe the error
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            //assigned to a bool, and if the bool does not have a value or that value returns a false -- then the error message will be given
            bool? value = context.Model as bool?;
            if (!value.HasValue || value.Value == false)
            {
                //ValidationResult ctor takes property name(empty string for individual properies) and a defualt error message)
                return new List<ModelValidationResult> { new ModelValidationResult("", ErrorMessage)};
            }
            else
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }
}
