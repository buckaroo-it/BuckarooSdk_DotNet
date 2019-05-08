using System;

namespace BuckarooSdk.DataTypes.Response.Status
{
    /// <summary>
    /// The overcoupling class of the current status that is returned in the response, 
    /// belonging to the transaction request.
    /// </summary>
    public class Status
    {
        /// <summary>
        /// The actual code of the status
        /// </summary>
        public StatusCode Code { get; set; }
        /// <summary>
        /// The statussubcode of the status
        /// </summary>
        public StatusSubCode SubCode { get; set; }
        /// <summary>
        /// The datetime stamp that states when the status was set.
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// primary status constructor
        /// </summary>
        public Status()
        {
	        this.Code = new StatusCode();
	        this.SubCode = new StatusSubCode();
        }
    }
}