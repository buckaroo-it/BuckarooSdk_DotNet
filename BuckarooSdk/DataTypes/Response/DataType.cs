namespace BuckarooSdk.DataTypes.Response
{
	/// <summary>
	/// Enum that is used for the typing of response parameters.
	/// </summary>
    public enum DataType
    {
		#region Datatypes
		/// <summary>
		/// String data type
		/// </summary>
		String,
		/// <summary>
		/// Integer data type
		/// </summary>
		Integer,
		/// <summary>
		/// Decimal data type
		/// </summary>
		Decimal,
		/// <summary>
		/// Date data type
		/// </summary>
		Date,
		/// <summary>
		/// Date time data type
		/// </summary>
		Datetime,
		/// <summary>
		/// Boolean data type
		/// </summary>
		Boolean,
		/// <summary>
		/// Cardnumber data type
		/// </summary>
		CardNumber,
		/// <summary>
		/// ExiryDate data type
		/// </summary>
        ExpiryDate,
		/// <summary>
		/// CardStart data type
		/// </summary>
        CardStartDate
		#endregion
	}
}