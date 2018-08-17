using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseAssignment2.Models
{
    /// <summary>
    /// Class that holds who is coming to the event
    /// </summary>
    public static class Repository
    {
        //Initialize list to hold people attending the event
        private static List<CompetitionInvite> responses = new List<CompetitionInvite>();
        /// <summary>
        /// Create read only property for response
        /// </summary>
        public static IEnumerable<CompetitionInvite> Responses
        {
            get
            {
                return responses;
            }
        }
        /// <summary>
        /// Adds a response to the list
        /// </summary>
        /// <param name="response">response to be added</param>
        public static void AddResponse(CompetitionInvite response)
        {
            //add response
            responses.Add(response);
        }
    }
}
