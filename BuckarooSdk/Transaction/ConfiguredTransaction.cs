using BuckarooSdk.Services.CreditCards.AmericanExpress.TransactionRequest;
using BuckarooSdk.Services.CreditCards.Maestro;
using BuckarooSdk.Services.CreditCards.MasterCard;
using BuckarooSdk.Services.CreditCards.Visa;
using BuckarooSdk.Services.EMandate;
using BuckarooSdk.Services.Ideal.TransactionRequest;
using BuckarooSdk.Services.IdealProcessing.TransactionRequest;
using BuckarooSdk.Services.KbcPaymentButton;
using BuckarooSdk.Services.P24.TransactionRequest;
using BuckarooSdk.Services.Payconiq.TransactionRequest;
using BuckarooSdk.Services.PayPal;
using BuckarooSdk.Services.PayPerEmail;
using BuckarooSdk.Services.SimpleSepaDirectDebit;
using BuckarooSdk.Services.Transfer.TransactionRequest;

namespace BuckarooSdk.Transaction
{
	/// <summary>
	/// The configuredTransaction is a transaction where the basic fields are set.
	/// </summary>
	public class ConfiguredTransaction
	{
		internal TransactionRequest BaseTransaction { get; private set; }

		/// <summary>
		/// ConfiguredTransaction primary constructor.
		/// </summary>
		/// <param name="transaction"></param>
		public ConfiguredTransaction(TransactionRequest transaction)
		{
			this.BaseTransaction = transaction;
		}

		#region "Services"

		/// <summary>
		/// The instanciation of the specific Ideal Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public IdealTransaction Ideal()
		{
			return new IdealTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Ideal Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public IdealProcessingTransaction IdealProcessing()
		{
			return new IdealProcessingTransaction(this);
		}

		/// <summary>
		/// The instantiation of the specific Paypermail service transaction.
		/// </summary>
		/// <returns></returns>
		public PayPerEmailTransaction PayPerEmail()
		{
			return new PayPerEmailTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Transfer Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public TransferTransaction Transfer()
		{
			return new TransferTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific PayPal Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public PayPalTransaction PayPal()
		{
			return new PayPalTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Mastercard Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public MasterCardTransaction Mastercard()
		{
			return new MasterCardTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Visa Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public VisaTransaction Visa()
		{
			return new VisaTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Maestro Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public MaestroTransaction Maestro()
		{
			return new MaestroTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Simple SEPA Direct debit Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public SimpleSepaDirectDebitTransaction SimpleSepaDirectDebit()
		{
			return new SimpleSepaDirectDebitTransaction(this);
		}

		public PayconiqTransaction Payconiq()
		{
			return new PayconiqTransaction(this);
		}


		/// <summary>
		/// The instanciation of the specific American Express Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public AmericanExpressTransaction AmericanExpress()
		{
			return new AmericanExpressTransaction(this);
		}

		#endregion

		public P24Transaction P24()
		{
			return new P24Transaction(this);
		}

		public KbcPaymentButtonRequestObject KbcPaymentButton()
		{
			return new KbcPaymentButtonRequestObject(this);
		}
	}
}
