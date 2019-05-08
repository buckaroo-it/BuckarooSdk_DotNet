namespace BuckarooSdk.DataTypes.Response
{
	/// <summary>
	/// Enum within options for the mutationtype. The mutationtype specifies the financial impact.
	/// </summary>
    public enum MutationType
    {
		/// <summary>
		/// CancelTransaction mutation type not specified
		/// </summary>
        NotSet,
		/// <summary>
		/// CancelTransaction mutation type is collecting, which means that Buckaroo 
		/// collects the funds of the transaction
		/// </summary>
        Collecting,
		/// <summary>
		/// CancelTransaction mutation type is processing, which means that Buckaroo
		/// does not collect the funds. The funds will be collected and paid out
		/// by a third party
		/// </summary>
        Processing,
		/// <summary>
		/// CancelTransaction mutation type is informational, which means that this
		/// transactions has no financial consequenses directly. 
		/// </summary>
        Informational
    }
}