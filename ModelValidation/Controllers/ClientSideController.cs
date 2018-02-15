using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelValidation.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace ModelValidation.Controllers
{
    public class ClientSideController : Controller
    {   
        
        public IActionResult Index() => View("MakeBooking", new AttributeAppointment() {Date = DateTime.Now});
        
       
        [HttpPost]
        public ViewResult MakeBooking(AttributeAppointment appt)
        {   
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
        }
    }

