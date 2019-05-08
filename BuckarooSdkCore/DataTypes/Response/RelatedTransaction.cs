namespace BuckarooSdk.DataTypes.Response
{
	/// <summary>
	/// A previously performed transaction that is related to the transaction that has to be performed now.
	/// </summary>
    public class RelatedTransaction
    {
		/// <summary>
		/// The type of relation that the 
		/// </summary>
        public string RelationType { get; set; }
        /// <summary>
        /// The transaction key of the related transaction
        /// </summary>
        public string RelatedTransactionKey { get; set; }
    }
}