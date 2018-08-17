using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnterpriseAssignment2.Models;
using WcfService;
namespace EnterpriseAssignment2.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Launches Index.cshtml and redirects to MyView.cshtml
        /// </summary>
        /// <returns>User to MyView.cshtml</returns>
        public ViewResult Index()
        {
            //Create variable that holds the current hour [Part of Textbook]
            int hour = DateTime.Now.Hour;
            //Create ViewBag to transfer variable information to another view
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            //Send user to MyView.cshtml
            return View("MyView");
        }
        
        /// <summary>
        /// On asp-action="RsvpForm" go to RsvpForm using get method
        /// </summary>
        /// <returns>RsvpForm.cshtml</returns>
        [HttpGet]
        public ViewResult RsvpForm()
        {
            //Return to RsvpForm
            return View();
        }
        /// <summary>
        /// On asp-action="RsvpForm" go to RsvpForm using post method
        /// </summary>
        /// <param name="invite">Sends object into view for information to be added</param>
        /// <returns>RsvpForm.cshtml if response is not valid otherwise returns Thanks.cshtml</returns>
        [HttpPost]
        public ViewResult RsvpForm(CompetitionInvite invite)
        {
            //string to hold value of html element that has the name attribute success
            string request = Request.Form["success"];
            //if the request is true
            if (request == "true")
            {
                //set WillAttend as true
                invite.WillAttend = true;
            }
            //if request is not true
            else
            {
                //set WillAttend as false
                invite.WillAttend = false;
            }
            //Check if form is valid
            if (ModelState.IsValid)
            {
               
                //Add response to Repository list
                Repository.AddResponse(invite);
                //returns user to Thanks.cshtml with parameter invite to extract data in view
                return View("Thanks", invite);
            }
            //If data is not valid
            else
            {
                //Redirect user back to RsvpForm
                return View();
            }
            
        }
        /// <summary>
        /// On asp-action="ListResponses" go to ListResponses.cshtml using get method
        /// </summary>
        /// <returns>Respsonses where WillAttend is true</returns>
        public ViewResult ListResponses()
        {
            //returns respsonses where WillAttend is true
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
