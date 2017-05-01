
namespace BuckarooSdk.Services.Ideal.TransactionRequest
{
    /// <summary>
    /// The ideal refund request class, where customer values of the request can be specified.
    /// </summary>
    public class IdealRefundRequest
    {
        /// <summary>
        /// The account name of the customer.
        /// </summary>
        public string CustomerAccountName { get; set; }
        /// <summary>
        /// The BIC (bank) code of the customer's account, where the refund is meant for.
        /// </summary>
        public string CustomerBic { get; set; }
        /// <summary>
        /// The IBAN of the customer's account, where the refund is meant for.
        /// </summary>
        public string CustomerIban { get; set; }

    }
}
