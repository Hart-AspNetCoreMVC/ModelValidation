using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View("MakeBooking", new Appointment {Date = DateTime.Now});

        //example of creating manual validation for form fields
        [HttpPost]
        public ViewResult ManualExample(Appointment appt)
        {   //uses string property to check if there was an input
            if (string.IsNullOrEmpty(appt.ClientName))
            {   //if true, the AddModelError method is called and registers an error in hte ModelStateDictionary
                ModelState.AddModelError(nameof(appt.ClientName), "Please enter your name");
            }
            //checks if a valid date object was was received, and if so, then checks that the date was in the future
            if (ModelState.GetValidationState("Date") == ModelValidationState.Valid && DateTime.Now > appt.Date)
            {   //if true, will register in error in the dictionary
                ModelState.AddModelError(nameof(appt.Date), "Please enter a date in the future");
            }
            //checks if a bool was checked
            if (!appt.TermsAccepted)
            {
                ModelState.AddModelError(nameof(appt.TermsAccepted), "You must accept our policy terms");
            }
            //MODEL LEVEL VALIDATION -- combines several properties. be sure to check that data is entered and valid first, then I check the 
            //more specific features
            if (ModelState.GetValidationState(nameof(appt.Date)) == ModelValidationState.Valid &&
                ModelState.GetValidationState(nameof(appt.ClientName))
                == ModelValidationState.Valid &&
                appt.ClientName.Equals("Mikayla", StringComparison.OrdinalIgnoreCase) &&
                appt.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("", "Doggies cannot book appointments on Monday!");
            }
            //this checks if ModelState is valid and everything is ok -- can proceed to the next view
            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            //if ModelState is Invalid then the view() will return to the form for user to try again
            //the View() method will incorporate any errors founds and add "input-validation-error" to the class of the html tag
            else
            {
                return View();
            }

        }
        //this example relies on the attribute validations attached to the model properties
        public IActionResult MakeBooking(Appointment appt)
        {
            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            else
            {
                return View();
            }
        }
    }
}
