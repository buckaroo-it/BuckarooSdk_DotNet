namespace BuckarooSdk.DataTypes.Response.RefundInfo
{
	public class RefundInputField
	{
		public ParameterDescription FieldDefenition { get; set; }
		public string CurrentValue { get; set; }
		public bool CurrentValueNotCorrect { get; set; }
		public bool CurrentValueEditable { get;set; }
	}
}
