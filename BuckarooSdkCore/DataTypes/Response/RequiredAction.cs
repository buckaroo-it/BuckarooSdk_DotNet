using System;
using System.Collections.Generic;

namespace BuckarooSdk.DataTypes.Response
{
    /// <summary>
    /// The data corresponding to the required actions within the reponse.
    /// </summary>
    public class RequiredAction
    {
        /// <summary>
        /// The type of the required action
        /// </summary>
        public RequiredActionType Type { get; set; }

        /// <summary>
        /// The name of the required action. This name is similar to the name of the type.
        /// </summary>
        public string Name
        {
            get
            {
                return this.Type.ToString();
            }
            set
            {
                RequiredActionType type;
                Enum.TryParse(value, out type);
	            this.Type = type;
            }
        }
        /// <summary>
        /// The URL used to redirect the customer to, in case the action is redirect.
        /// </summary>
        public string RedirectURL { get; set; }
        /// <summary>
        /// The list of request information parameters
        /// </summary>
        public List<RequestInformationParameter> RequestedInformation { get; set; }
        /// <summary>
        /// An overview of the details belonging to the payremainders
        /// </summary>
        public PayRemainderDetails PayRemainderDetails { get; set; }
    }
}