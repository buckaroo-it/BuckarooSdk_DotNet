using BuckarooSdk.Services.Afterpay;
using BuckarooSdk.Services.AfterpayAcceptgiro;
using BuckarooSdk.Services.AfterpayDigiaccept;
using BuckarooSdk.Services.BuckarooWallet;
using BuckarooSdk.Services.BuckarooVoucher;
using BuckarooSdk.Services.Capayable;
using BuckarooSdk.Services.CreditCards;
using BuckarooSdk.Services.CreditCards.BanContact;
using BuckarooSdk.Services.CustomGiftcard;
using BuckarooSdk.Services.EMandate;
using BuckarooSdk.Services.EPS;
using BuckarooSdk.Services.Giropay;
using BuckarooSdk.Services.Ideal.TransactionRequest;
using BuckarooSdk.Services.IdealProcessing.TransactionRequest;
using BuckarooSdk.Services.INGHomePay;
using BuckarooSdk.Services.Ippies;
using BuckarooSdk.Services.KbcPaymentButton;
using BuckarooSdk.Services.Klarna;
using BuckarooSdk.Services.Notification;
using BuckarooSdk.Services.OnlineGiro;
using BuckarooSdk.Services.OnlineGiroLite;
using BuckarooSdk.Services.P24.TransactionRequest;
using BuckarooSdk.Services.Payconiq.TransactionRequest;
using BuckarooSdk.Services.PayPal;
using BuckarooSdk.Services.PayPerEmail;
using BuckarooSdk.Services.PaysafeCard;
using BuckarooSdk.Services.SimpleSepaDirectDebit;
using BuckarooSdk.Services.Sofort;
using BuckarooSdk.Services.Transfer.TransactionRequest;
using BuckarooSdk.Transaction.General;
using AmericanExpressTransaction = BuckarooSdk.Services.CreditCards.AmericanExpress.Request.AmericanExpressTransaction;
using BuckarooSdkCore.Services.ApplePay.TransactionRequest;

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

		#region CreditCards
		/// <summary>
		/// The instanciation of the specific Dankort Service transaction.
		/// </summary>
		/// <returns> An Dankort</returns>
		public CreditCardTransaction Dankort()
		{
			return new CreditCardTransaction(this, Constants.Services.ServiceNames.Dankort);
		}

		/// <summary>
		/// The instanciation of the specific Visa Service transaction.
		/// </summary>
		/// <returns> A Visa</returns>
		public CreditCardTransaction Visa()
		{
			return new CreditCardTransaction(this, Constants.Services.ServiceNames.Visa);
		}

		/// <summary>
		/// The instanciation of the specific MasterCard Service transaction.
		/// </summary>
		/// <returns>A MasterCard</returns>
		public CreditCardTransaction MasterCard()
		{
			return new CreditCardTransaction(this, Constants.Services.ServiceNames.MasterCard);
		}

		/// <summary>
		/// The instanciation of the specific CarteBleueVisa Service transaction.
		/// </summary>
		/// <returns>A CarteBleueVisa</returns>
		public CreditCardTransaction CarteBleueVisa()
		{
			return new CreditCardTransaction(this, Constants.Services.ServiceNames.CarteBleueVisa);
		}


		/// <summary>
		/// The instanciation of the specific VisaElectron Service transaction.
		/// </summary>
		/// <returns>A VisaElectron</returns>
		public CreditCardTransaction VisaElectron()
		{
			return new CreditCardTransaction(this, Constants.Services.ServiceNames.VisaElectron);
		}

		/// <summary>
		/// The instanciation of the specific VPay Service transaction.
		/// </summary>
		/// <returns>A VPay</returns>
		public CreditCardTransaction VPay()
		{
			return new CreditCardTransaction(this, Constants.Services.ServiceNames.VPay);
		}

		/// <summary>
		/// The instanciation of the specific Maestro Service transaction.
		/// </summary>
		/// <returns>A Maestro</returns>
		public CreditCardTransaction Maestro()
		{
			return new CreditCardTransaction(this, Constants.Services.ServiceNames.Maestro);
		}

		/// <summary>
		/// The instanciation of the specific American Express Service transaction.
		/// </summary>
		/// <returns>An AmericanExpress</returns>
		public AmericanExpressTransaction AmericanExpress()
		{
			return new AmericanExpressTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Nexi Service transaction.
		/// </summary>
		/// <returns>A Nexi</returns>
		public CreditCardTransaction Nexi()
		{
			return new CreditCardTransaction(this, Constants.Services.ServiceNames.Nexi);
		}

		/// <summary>
		/// The instanciation of the specific Carte Bancaire Service transaction.
		/// </summary>
		/// <returns>A CarteBancaire</returns>
		public CreditCardTransaction CarteBancaire()
		{
			return new CreditCardTransaction(this, Constants.Services.ServiceNames.CarteBancaire);
		}

		/// <summary>
		/// The instanciation of the specific Bancontact Service transaction.
		/// </summary>
		/// <returns>A Bancontact</returns>
		public BancontactTransaction Bancontact()
		{
			return new BancontactTransaction(this);
		}

		#endregion

		#region iDeal
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

		#endregion

		#region AfterPay
		/// <summary>
		/// The instanciation of the specific AfterpayAcceptgiro Service transaction.
		/// </summary>

		public AfterpayAcceptgiroRequestObject AfterpayAcceptgiro()
		{
			return new AfterpayAcceptgiroRequestObject(this);
		}
		/// <returns> An INGHomePay</returns>
		public INGHomePayRequestObject INGHomePay()
		{
			return new INGHomePayRequestObject(this);
		}

		/// <summary>
		/// The instanciation of the specific AfterpayDigiaccept Service transaction.
		/// </summary>
		public AfterpayDigiacceptRequestObject AfterpayDigiaccept()
		{
			return new AfterpayDigiacceptRequestObject(this);
		}

		/// <summary>
		/// The instanciation of the specific Afterpay Service transaction.
		/// </summary>
		public AfterpayRequestObject Afterpay()
		{
			return new AfterpayRequestObject(this);
		}
		#endregion

		/// <summary>
		/// The instantiation of the specific CustomGiftcard service transaction.
		/// </summary>
		public CustomGiftcardRequestObject CustomGiftcard()
		{
			return new CustomGiftcardRequestObject(this, Constants.Services.ServiceNames.CustomGiftcard);
		}

		/// The instantiation of the specific CustomGiftcard2 service transaction.
		/// <returns></returns>
		public CustomGiftcardRequestObject CustomGiftcard2()
		{
			return new CustomGiftcardRequestObject(this, Constants.Services.ServiceNames.CustomGiftcard2);
		}

		/// The instantiation of the specific CustomGiftcard3 service transaction.
		/// <returns></returns>
		public CustomGiftcardRequestObject CustomGiftcard3()
		{
			return new CustomGiftcardRequestObject(this, Constants.Services.ServiceNames.CustomGiftcard3);
		}
    
    /// The instantiation of the specific Ippies service transaction.
		public IppiesRequestObject Ippies()
		{
			return new IppiesRequestObject(this);
		}


		/// <summary>
		/// The instantiation of the specific BuckarooWallet service transaction.
		/// </summary>
		public BuckarooWalletRequestObject BuckarooWallet()
		{
			return new BuckarooWalletRequestObject(this);
		}
    
    /// <summary>
		/// The instantiation of the specific BuckarooVoucher service transaction.
		/// </summary>
		public BuckarooVoucherRequestObject BuckarooVoucher()
		{
			return new BuckarooVoucherRequestObject(this);
		}
      
		/// <summary>
		/// The instantiation of the specific Notification service transaction.
		/// </summary>
		public NotificationRequestObject Notification()
		{
			return new NotificationRequestObject(this);
		}

		/// <summary>
		/// The instantiation of the specific OnlineGiro service transaction.
		/// </summary>
		public CapayableRequestObject Capayable()
		{
			return new CapayableRequestObject(this);
		}

		/// <summary>
		/// The instantiation of the specific OnlineGiro service transaction.
		/// </summary>
		public OnlineGiroRequestObject OnlineGiro()
		{
			return new OnlineGiroRequestObject(this);
		}

		/// <summary>
		/// The instantiation of the specific OnlineGiroLite service transaction.
		/// </summary>
		public OnlineGiroLiteRequestObject OnlineGiroLite()
		{
			return new OnlineGiroLiteRequestObject(this);
		}

		/// <summary>
		/// The instantiation of the specific Paypermail service transaction.
		/// </summary>
		public PayPerEmailTransaction PayPerEmail()
		{
			return new PayPerEmailTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Transfer Service transaction.
		/// </summary>
		public TransferTransaction Transfer()
		{
			return new TransferTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific PayPal Service transaction.
		/// </summary>
		public PayPalTransaction PayPal()
		{
			return new PayPalTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific EMandate Service transaction.
		/// </summary>
		public EMandateRequestObject EMandate()
		{
			return new EMandateRequestObject(this);
		}

		/// <summary>
		/// The instanciation of the specific Simple SEPA Direct debit Service transaction.
		/// </summary>
		public SimpleSepaDirectDebitTransaction SimpleSepaDirectDebit()
		{
			return new SimpleSepaDirectDebitTransaction(this);
		}

		public PayconiqTransaction Payconiq()
		{
			return new PayconiqTransaction(this);
		}

		public P24Transaction P24()
		{
			return new P24Transaction(this);
		}

		public KlarnaRequestObject Klarna()
		{
			return new KlarnaRequestObject(this);
		}

		public KbcPaymentButtonRequestObject KbcPaymentButton()
		{
			return new KbcPaymentButtonRequestObject(this);
		}

		public EPSRequestObject EPS()
		{
			return new EPSRequestObject(this);
		}

		/// <summary>
		/// The instanciation of the specific PaysafeCard Service transaction.
		/// </summary>
		/// <returns> An PaysafeCard</returns>
		public PaysafeCardRequestObject PaysafeCard()
		{
			return new PaysafeCardRequestObject(this);
		}

		/// <summary>
		/// The instanciation of the specific Sofort Service transaction.
		/// </summary>
		/// <returns> An Sofort</returns>
		public SofortTransaction Sofort()
		{
			return new SofortTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Sofort Service transaction.
		/// </summary>
		/// <returns> A Giropay transaction</returns>
		public GiropayTransaction Giropay()
		{
			return new GiropayTransaction(this);
		}

		/// <summary>
		/// The instanciation of the specific Sofort Service transaction.
		/// </summary>
		/// <returns> A Giropay transaction</returns>
		public ApplePayTransaction ApplePay()
		{
			return new ApplePayTransaction(this);
		}

		/// <summary>
		/// The instantiation of a general transaction without a service.
		/// </summary>
		/// <returns> A general transaction without any service selected</returns>
		public GeneralTransaction NoServiceSelected()
		{
			return new GeneralTransaction(this);
		}
	}
}
