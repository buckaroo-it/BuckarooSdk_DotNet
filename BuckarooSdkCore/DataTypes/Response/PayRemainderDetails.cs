namespace BuckarooSdk.DataTypes.Response
{
	/// <summary>
	/// Data corresponding to the payremainder details.
	/// </summary>
    public class PayRemainderDetails
    {
		/// <summary>
		/// the remaining amount set for the remainder
		/// </summary>
        public decimal RemainderAmount { get; set; }
		/// <summary>
		/// The currency of the payment remainder
		/// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// The grouptransaction of the payremainder
        /// </summary>
        public string GroupTransaction { get; set; }
    }
}