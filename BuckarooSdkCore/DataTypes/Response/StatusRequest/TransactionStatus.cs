using System.Collections.Generic;


namespace BuckarooSdk.DataTypes.Response.StatusRequest
{
	public class TransactionStatus : IRequestResponse
	{
		public string Key { get; set; }
		public string Invoice { get; set; }
		public string ServiceCode { get; set; }
		public Status.Status Status { get; set; }
		public bool IsTest { get; set; }
		public string Order { get; set; }
		public string Currency { get; set; }
		public decimal AmountDebit { get; set; }
		public decimal AmountCredit { get; set; }
		public string TransactionType { get; set; }
		public List<Service> Services { get; set; }
		public List<CustomParameter> CustomParameters { get; set; }
		public TransactionStatusResponseAdditionalParameter AdditionalParameters { get; set; }
		public MutationType MutationType { get; set; }
		public List<RelatedTransaction> RelatedTransactions { get; set; }
		public bool IsCancelable { get; set; }
		public string IssuingCountry { get; set; }
		public bool StartRecurrent { get; set; }
		public bool Recurring { get; set; }
		public string CustomerName { get; set; }
		public string PayerHash { get; set; }
		public string PaymentKey { get; set; }
	}
}
