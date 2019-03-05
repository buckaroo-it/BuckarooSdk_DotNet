using BuckarooSdk.Services.CreditCards;
using BuckarooSdk.Services.CreditCards.AmericanExpress;
using BuckarooSdk.Services.CreditCards.BanContact;
using BuckarooSdk.Services.Giropay;
using BuckarooSdk.Services.Ideal.TransactionRequest;
using BuckarooSdk.Services.IdealProcessing.TransactionRequest;
using BuckarooSdk.Services.P24.TransactionRequest;
using BuckarooSdk.Services.Payconiq.TransactionRequest;
using BuckarooSdk.Services.PayPal;
using BuckarooSdk.Services.PayPerEmail;
using BuckarooSdk.Services.SimpleSepaDirectDebit;
using BuckarooSdk.Services.Sofort;
using BuckarooSdk.Services.Transfer.TransactionRequest;
using static BuckarooSdk.Constants.Services;

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
		/// The instanciation of the specific MasterCard Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction MasterCard()
		{
			return new CreditCardTransaction(this, ServiceNames.MasterCard);
		}

		/// <summary>
		/// The instanciation of the specific Visa Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction Visa()
		{
			return new CreditCardTransaction(this, ServiceNames.Visa);
		}

		/// <summary>
		/// The instanciation of the specific Giropay Service transaction.
		/// </summary>
		/// <returns>An Giropay</returns>
		public GiropayTransaction Giropay()
		{
			return new GiropayTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Visa Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction CarteBleueVisa()
		{
			return new CreditCardTransaction(this, ServiceNames.CarteBleueVisa);
		}

		/// <summary>
		/// The instanciation of the specific Visa Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction VisaElectron()
		public CreditCardTransaction MasterCard()
		{
			return new CreditCardTransaction(this, ServiceNames.MasterCard);
		}

		/// <summary>
		/// The instanciation of the specific Visa Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction Visa()
		{
			return new CreditCardTransaction(this, ServiceNames.Visa);
		}

		/// <summary>
		/// The instanciation of the specific Visa Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction CarteBleueVisa()
		{
			return new CreditCardTransaction(this, ServiceNames.CarteBleueVisa);
		}

		/// <summary>
		/// The instanciation of the specific Visa Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction VisaElectron()
		{
			return new CreditCardTransaction(this, ServiceNames.VisaElectron);
		}

		/// <summary>
		/// The instanciation of the specific Visa Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction VPay()
		{
			return new CreditCardTransaction(this, ServiceNames.VPay);
		}

		/// <summary>
		/// The instanciation of the specific Maestro Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction Maestro()
		{
			return new CreditCardTransaction(this, ServiceNames.Maestro);
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

		/// <summary>
		/// The instanciation of the specific MasterCard Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction Nexi()
		{
			return new CreditCardTransaction(this, ServiceNames.Nexi);
		}

		/// <summary>
		/// The instanciation of the specific MasterCard Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public CreditCardTransaction CarteBancaire()
		{
			return new CreditCardTransaction(this, ServiceNames.CarteBancaire);
		}

		/// <summary>
		/// The instanciation of the specific MasterCard Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public BancontactTransaction Bancontact()
		{
			return new BancontactTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Sofort Service transaction.
		/// </summary>
		/// <returns> An Sofort</returns>
		public SofortTransaction Sofort()
		{
			return new SofortTransaction(this);
		}
	}
}
