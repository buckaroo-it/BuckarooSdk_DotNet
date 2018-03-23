using System.Collections.Generic;

namespace BuckarooSdk.DataTypes
{
	// INTERNAL NOTE: This class purely exists because of the legacy json message that has to be created. within
	// this message, the list of custom parameters is a value belonging to the tag: additionalparameters

	/// <summary>
	/// A class that holds a list of additional parameters. 
	/// </summary>
	public class AdditionalParameters
    {
		/// <summary>
		/// A list of additional parameters.
		/// </summary>
		public List<AdditionalParameter> AdditionalParameter { get; set; }

		/// <summary>
		/// primary constructor. A new list of additional parameters is instantiated.
		/// </summary>
		public AdditionalParameters()
        {
	        this.AdditionalParameter = new List<AdditionalParameter>();
        }
    }
}
