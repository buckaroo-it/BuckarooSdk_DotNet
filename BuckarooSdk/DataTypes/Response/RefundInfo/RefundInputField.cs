using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
