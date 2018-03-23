namespace BuckarooSdk.DataTypes.RequestBases
{
	public class DataRequestBase
	{
		public string Currency { get; set; }
		/// <summary>
		/// The debit amount of the transaction.
		/// </summary>
		public decimal? AmountDebit { get; set; }
		/// <summary>
		/// the credit amount of the transaction.
		/// </summary>
		public decimal? AmountCredit { get; set; }
		/// <summary>
		/// The invoicenumber of the invoice the transaction belongs to.
		/// </summary>
		public string Invoice { get; set; }
		/// <summary>
		/// The ordernumber of the order the transaction belongs to.
		/// </summary>
		public string Order { get; set; }
		/// <summary>
		/// The description that belongs to the transaction.
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// The Ip Address of the client, that is sending the request. Needs to be instantiated.
		/// </summary>
		public IpAddress ClientIp { get; set; }
		/// <summary>
		/// The return url, is the url that the user needs to be redirected to.
		/// </summary>
		public string ReturnUrl { get; set; }
		/// <summary>
		/// The return url cancel, is a specific url that the user needs to be redirected to in 
		/// case the user cancels the transaction.
		/// </summary>
		public string ReturnUrlCancel { get; set; }
		/// <summary>
		/// The return url error, is a specific url that the user needs to be redirected to in 
		/// case the an error occurs during the processing of the request.
		/// </summary>
		public string ReturnUrlError { get; set; }
		/// <summary>
		/// The return url reject, is a specific url that the user needs to be redirected to in 
		/// case the transaction is rejected by Buckaroo.
		/// </summary>
		public string ReturnUrlReject { get; set; }
		/// <summary>
		/// Contains the original transaction key in case there was a previous payment, that is 
		/// linked to this payment. e.g. in case of a refund.
		/// </summary>
		public string OriginalTransactionKey { get; set; }
		/// <summary>
		/// Defines if a transaction should initiate a recurrent transaction. Some services support 
		/// recurring payments (You can identify these by determining if they support the action 
		/// PayRecurrent). Before being able to do a recurrent payment, a normal payment needs to be 
		/// made with this field set to true (the default value for this field is false).
		/// </summary>
		public bool StartRecurrent { get; set; }
		/// <summary>
		/// Defines a value that states wheter the request should be aborted, or that the user should
		/// be redirected in case the request is incomplete.
		/// </summary>
		public ContinueOnIncomplete ContinueOnIncomplete { get; set; }
		/// <summary>
		/// If no primary service is provided and ContinueOnIncomplete is set, this list of comma 
		/// separated servicescodes can be used to limit the number of services from which the customer 
		/// may choose once he is redirected to the payment form. Only services which are entered in 
		/// this field are selectable. This field is optional and when empty or missing, the customer 
		/// may choose any of the available services
		/// </summary>
		public string ServicesSelectableByClient { get; set; }
		/// <summary>
		/// If no primary service is provided and ContinueOnIncomplete is set, this list of comma 
		/// separated servicescodes can be used to limit the number of services from which the customer 
		/// may choose once he is redirected to the payment form. Services which are entered in this field 
		/// are not selectable. This field is optional.
		/// </summary>
		public string ServicesExcludedForClient { get; set; }
		/// <summary>
		/// When provided, this push URL overrides all the push URLs as configured in the payment plaza 
		/// under websites for the associated website key.
		/// </summary>
		public string PushUrl { get; set; }
		/// <summary>
		/// When provided, this push URL overrides the push URL for failed transactions as configured 
		/// in the payment plaza under websites for the associated website key.
		/// </summary>
		public string PushUrlFailure { get; set; }
		/// <summary>
		/// This tag can be used to tell the Payment Engine what the user agent of the client’s 
		/// webbrowser is. This can be used for statistical purposes but also to perform anti-fraud checks 
		/// on transactions.
		/// </summary>
		public string ClientUserAgent { get; set; }
		/// <summary>
		/// Contains the reference to a previously performed transaction. It has a type, as well as the
		/// actual reference
		/// </summary>
		public TransactionReference OriginalTransactionReference { get; set; }
	}
}
