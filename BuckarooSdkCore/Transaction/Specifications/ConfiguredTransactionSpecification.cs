using System;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.DataTypes.Response;
using BuckarooSdk.DataTypes.Response.Specificiations;

namespace BuckarooSdk.Transaction.Specifications
{
	public class ConfiguredTransactionSpecification
	{
		internal TransactionSpecification TransactionSpecification { get; set; }

		internal ConfiguredTransactionSpecification(TransactionSpecification transactionSpecification)
		{
			this.TransactionSpecification = transactionSpecification;
		}

		public RequestResponse GetSingleTransactionSpecification()
		{
			if (this.TransactionSpecification.Request.Request != null)
			{
				throw new Exception("This function is a GET method and should therefore not contain a body.");
			}
			return Connection.Connector.SendRequest<IRequestBase, RequestResponse>
				(this.TransactionSpecification.Request.Request, this.TransactionSpecification.TransactionSpecificationBase, HttpRequestType.Get).Result;
		}

		public SpecificationsRequestResponse GetMultipleSpecificiations()
		{
			if (this.TransactionSpecification.Request.Request == null)
			{
				throw new Exception("This function is a POST method and should therefore contain a message body");
			}
			return Connection.Connector.SendRequest<IRequestBase, SpecificationsRequestResponse>
				(this.TransactionSpecification.Request.Request, this.TransactionSpecification.TransactionSpecificationBase, HttpRequestType.Post).Result;
		}
	}
}
