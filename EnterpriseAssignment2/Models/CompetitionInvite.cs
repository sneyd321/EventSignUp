using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseAssignment2.Models
{
    /// <summary>
    /// Holds information for the RsvpForm
    /// </summary>
    public class CompetitionInvite
    {
        /// <summary>
        /// Read-write property for name
        /// </summary>
        [Required(ErrorMessage = "Please enter your name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Read-write property for email
        /// </summary>
        [Required(ErrorMessage = "Please enter you email address")]
        [RegularExpression(".+\\@.+\\..+", 
            ErrorMessage = "Please enter a valid email address")]
        public string Email
        {
            get;
            set;
        }
        /// <summary>
        /// Read-write property for phone
        /// </summary>
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone
        {
            get;
            set;
        }
        /// <summary>
        /// Read-write property for WillAttend
        /// </summary>
        public bool? WillAttend
        {
            get;
            set;
        }
        /// <summary>
        /// Read-write property for address
        /// </summary>
        [Required(ErrorMessage = "Please enter your address")]
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// Read-write property for social network interest
        /// </summary>
        [Required(ErrorMessage = "Please enter your Social Network Interest")]
        public string SocialNetworkInterest
        {
            get;
            set;
        }
        /// <summary>
        /// Read-write property for technical interest
        /// </summary>
        [Range((int)(TechnicalInterest.IoT), (int)(TechnicalInterest.Programming), ErrorMessage = "Please enter you Technical Interest")]
        public TechnicalInterest Interest
        {
            get;
            set;
        }
        
        
    }
}
