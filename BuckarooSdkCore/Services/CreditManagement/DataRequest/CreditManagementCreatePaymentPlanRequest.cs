using System;

namespace BuckarooSdk.Services.CreditManagement.DataRequest
{
	public class CreditManagementCreatePaymentPlanRequest
	{
		/// <summary>
		/// Required = true
		/// 
		/// </summary>
		public string IncludedInvoiceKey { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string DossierNumber { get; set; }
		/// <summary>
		/// Required = true
		/// 
		/// </summary>
		public int InstallmentCount { get;set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal InstallmentAmount { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal InitialAmount { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime StartDate { get; set; }
		/// <summary>
		/// Required = true
		/// 
		/// </summary>
		public string Interval { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal PaymentPlanCostAmount { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal PaymentPlanCostAmountVat { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string RecipientEmail { get; set; }
	}
}
