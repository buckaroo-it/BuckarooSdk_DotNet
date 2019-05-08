using BuckarooSdk.Transaction;
using BuckarooSdk.Transaction.Cancel;
using BuckarooSdk.Transaction.InvoiceInfo;
using BuckarooSdk.Transaction.RefundInfo;
using BuckarooSdk.Transaction.Specifications;
using BuckarooSdk.Transaction.Status;

namespace BuckarooSdk.Base
{
	/// <summary>
	/// An authenticatedRequest is a request where authentication properties are 
	/// defined and validated upon type.
	/// </summary>
    public class AuthenticatedRequest
    {
        internal Request Request { get; set; }

        internal AuthenticatedRequest(Request request)
        {
            this.Request = request;
        }

		/// <summary>
		/// States that the request that will be performed is a transaction request.
		/// </summary>
		/// <returns> A CancelTransaction</returns>
        public TransactionRequest TransactionRequest()
        {
            return new TransactionRequest(this);
        }

	    public CancelTransaction CancelTransactionRequest()
	    {
		    return new CancelTransaction(this);
	    }

	    public TransactionStatus TransactionStatusRequest()
	    {
		    return new TransactionStatus(this);
	    }

	    public TransactionSpecification TransactionSpecificationRequest()
	    {
		    return new TransactionSpecification(this);
	    }

	    public TransactionInvoiceInfo TransactionInvoiceInfoRequest()
	    {
		    return new TransactionInvoiceInfo(this);
	    }

	    public TransactionRefundInfo TransactionRefundInfoRequest()
	    {
		    return new TransactionRefundInfo(this);
	    }

		/// <summary>
		/// States that the request that will be performed is a data request.
		/// </summary>
		/// <returns> A Data object </returns>
        public Data.Data DataRequest()
        {
            return new Data.Data(this);
        }

	    public object Subscriptions()
	    {
		    throw new System.NotImplementedException();
	    }
    }
}
