namespace BuckarooSdk.DataTypes
{
	/// <summary>
	/// A transaction reference is used to give within a transaction to give a reference towards
	/// previously performed transaction.
	/// </summary>
    public class TransactionReference
    {
		/// <summary>
		/// The type of the original transaction
		/// </summary>
        public string Type { get; set; }
		/// <summary>
		/// The actual reference of the original transaction
		/// </summary>
        public string Reference { get; set; }
    }
}
