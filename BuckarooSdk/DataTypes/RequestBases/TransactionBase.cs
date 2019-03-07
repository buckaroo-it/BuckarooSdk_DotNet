using BuckarooSdk.Services;
using Newtonsoft.Json;

namespace BuckarooSdk.DataTypes.RequestBases
{
	/// <summary>
	/// The base properties for a transaction request
	/// </summary>
    public class TransactionBase : IRequestBase
    {
		/// <summary>
		/// The parameters that are custom, which means that they can vary in case different services
		/// are used. Where the base transaction paremeters are service independent, these
		/// </summary>
        [JsonProperty()]
        internal CustomParameters CustomParameters { get; set; }
		/// <summary>
		/// The parameters that are additional to the service, which means that they can vary in case 
		/// different service are used. Where the base transaction paremeters are service independent, these
		/// </summary>
		[JsonProperty()]
        internal AdditionalParameters AdditionalParameters { get; set; }
		/// <summary>
		/// A services property, which then contains a list of Services
		/// </summary>
        [JsonProperty()]
        internal TransactionServices Services { get; set; }

	    /// <summary>
	    /// Contains the reference to a previously performed transaction. It has a type, as well as the
	    /// actual reference
	    /// </summary>
		public TransactionReference OriginalTransactionReference { get; set; }

	    /// <summary>
	    /// The Ip Address of the client, that is sending the request. Needs to be instantiated.
	    /// </summary>
	    public IpAddress ClientIp { get; set; }

		/// <summary>
		/// Primary constructor. Al lists are instantiate within this constructor
		/// </summary>
		public TransactionBase()
        {
            this.CustomParameters = new CustomParameters();
            this.AdditionalParameters = new AdditionalParameters();
            this.Services = new TransactionServices();
            this.OriginalTransactionReference = new TransactionReference();
            this.ClientIp = new IpAddress();
        }

        /// <summary>
        /// Adds a custom parameter to the transactionbase. requires a parameter key and a parameter value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public TransactionBase AddCustomParameter(string key, string value)
        {
            this.CustomParameters.List.Add(new CustomParameter()
            {
                Name = key,
				Value = value
            });

            return this;
        }
    }
}
