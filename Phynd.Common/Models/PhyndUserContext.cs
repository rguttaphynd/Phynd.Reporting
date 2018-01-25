using System;
using System.Collections.Generic;
using System.Text;

namespace Phynd.Common.Models
{
    public class PhyndUserContext
    {
        /// <summary>
        /// This is the URL Or the IP address of the request sourec
        /// </summary>
        public string RequestSource { get; set; }

        public int UserID { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// This is the health system that the user belongs to.
        /// </summary>
        public int UserHealthSystemID { get; set; }

        /// <summary>
        /// THis is the health system for which the data will be retrieved
        /// </summary>
        public int TargetHealthSystemID { get; set; }

        /// <summary>
        /// This is to distinguish between the request made by the health system app or by
        /// internally by the Phynd platform. It should be used to ignore serialization
        /// of certain attributes (e.g. HealthSystemID, UserID etc,) if the request 
        /// is from health system apps.
        /// </summary>
        public Boolean IsExternalRequest { get; set; }
    }
}
