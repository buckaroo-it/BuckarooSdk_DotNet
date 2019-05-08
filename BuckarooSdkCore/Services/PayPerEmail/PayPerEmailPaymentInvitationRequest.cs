using System;
namespace BuckarooSdk.Services.PayPerEmail
{
	/// <summary>
	/// The PayperEmail Payment invitation is a request that has the purpos of sending a payment invitation
	/// to a customer. This can be performed by Buckaroo, or a payment link can be returned, in case the
	/// mail should be sent by your own system. The payment link is the key element of the PayperEmail and
	/// is the link to the Buckaroo Payment Engine.
	/// </summary>
	public class PayPerEmailPaymentInvitationRequest
	{
        /// <summary>
        /// The gender of the customer, used to properly address the customer in the mail. Possible values are:
        /// 
        /// 0 : Unknown 
        /// 1 : Male 
        /// 2 : Female
        /// 9 : Not applicable
        /// 
        /// To be sure that always one of these values are used, the corresponding class with gender constants
        /// can be used.
        /// </summary>
        public int CustomerGender { get; set; }

        /// <summary>
        /// The file name of a previously uploaded attachment.
        /// </summary>
        public string Attachment { get; set; }
        
        /// <summary>
        /// Defines if Buckaroo has to send the payperemail, or that you wish to get only the paylink returned.
        /// when true, the paylink is returned in the response, and Buckaroo will not send the email.
        /// </summary>
        public bool MerchantSendsEmail { get; set; }

        /// <summary>
        /// The date you wish to have the PayperEmail expired.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// A single or multiple payment methods which the consumer is offered as a choice on the payment page.
        /// If no payment methods are defined here, all active payment methods within the merchant account are shown.
        /// </summary>
        public string PaymentMethodsAllowed { get; set; }

        /// <summary>
        /// The email address of the customer where the email needs to be send to.
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// The first name of the customer.
        /// </summary>
        public string CustomerFirstName { get; set; }

        /// <summary>
        /// The last name of the customer.
        /// </summary>
        public string CustomerLastName { get; set; }
    }
}
