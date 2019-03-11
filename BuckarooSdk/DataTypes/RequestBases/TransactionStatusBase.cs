using System.Collections.Generic;
using Newtonsoft.Json;

namespace BuckarooSdk.DataTypes.RequestBases
{
	public class TransactionStatusBase : IRequestBase
	{
		public List<TransactionStatus> Transactions { get; set; }

		public TransactionStatusBase(List<TransactionStatus> transactions)
		{
			this.Transactions = transactions;
		}

		public TransactionStatusBase AddTransactionStatus(TransactionStatus transaction)
		{
			this.Transactions.Add(transaction);
			return this;
		}
	}

	public class TransactionStatus
	{
		public string Key { get; set; }
		public string Invoice {get; set; }

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

		public TransactionStatus()
		{
			
		}

		/// <summary>
        /// Adds a custom parameter to the transactionbase. requires a parameter key and a parameter value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void AddCustomParameter(string key, string value)
        {
            this.CustomParameters.List.Add(new CustomParameter()
            {
                Name = key,
				Value = value
            });
        }

        /// <summary>
        /// Adds an additional parameter to the transactionbase. requires a parameter key and a parameter value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void AddAdditionalParameter(string key, string value)
        {
            this.AdditionalParameters.AdditionalParameter.Add(new AdditionalParameter()
            {
                Name = key,
                Value = value
            });
        }
	}
}
