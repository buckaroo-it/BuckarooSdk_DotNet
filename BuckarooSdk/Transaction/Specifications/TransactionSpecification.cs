using BuckarooSdk.Base;
using BuckarooSdk.DataTypes.RequestBases;

namespace BuckarooSdk.Transaction.Specifications
{
	public class TransactionSpecification
	{
		internal AuthenticatedRequest Request { get; set; }
		internal TransactionSpecificationBase TransactionSpecificationBase { get; set; }

		public TransactionSpecification(AuthenticatedRequest request)
		{
			this.Request = request;
		}

		public ConfiguredTransactionSpecification SpecificServiceSpecification(string serviceName, int? serviceVersion = null)
		{
			this.Request.Request.Endpoint += ($"{Constants.Settings.GatewaySettings.TransactionRequestEndPoint}" +
											$"{Constants.Settings.GatewaySettings.SpecificationEndpoint}" +
											$"{serviceName}?serviceVersion={serviceVersion}");

			return new ConfiguredTransactionSpecification(this);
		}

		public ConfiguredTransactionSpecification MultipleServiceSpecifications(
			TransactionSpecificationBase transactionSpecificationBase)
		{
			this.TransactionSpecificationBase = transactionSpecificationBase;
			this.Request.Request.Endpoint += Constants.Settings.GatewaySettings.TransactionRequestEndPoint + 
				Constants.Settings.GatewaySettings.SpecificationsEndpoint;
			return new ConfiguredTransactionSpecification(this);
		}
	}
}
