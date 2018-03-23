using System.Collections.Generic;

namespace BuckarooSdk.DataTypes
{
	// INTERNAL NOTE: This class purely exists because of the legacy json message that has to be created. within
	// this message, the list of custom parameters is a value belonging to the tag: customparameters

	/// <summary>
	/// A class that holds a list of custom parameters. 
	/// </summary>
	public class CustomParameters
    {
		/// <summary>
		/// A list of custom parameters.
		/// </summary>
        public List<CustomParameter> List { get; set; }

		/// <summary>
		/// primary constructor. A new list of custom parameters is instantiated.
		/// </summary>
        public CustomParameters()
        {
	        this.List = new List<CustomParameter>();
        }
    }
}
