namespace BuckarooSdk.Services.P24.TransactionRequest
{
	/// <summary>
	/// The Pay action is used to perform a single P24 payment. Important note: a P24 payment can only be done in Polish zloty. 
	/// Therefore, make sure to provide value "PLN" as the currency in the request.
	/// </summary>
	public class P24PayRequest
	{
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