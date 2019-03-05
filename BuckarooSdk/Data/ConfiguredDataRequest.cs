using BuckarooSdk.Services.Ideal.DataRequest;
using BuckarooSdk.Services.CreditManagement.DataRequest;
using BuckarooSdk.Services.Emandates.DataRequest;
using BuckarooSdk.Services.IdealQr.DataRequest;

namespace BuckarooSdk.Data
{
	public class ConfiguredDataRequest
	{
		internal Data BaseDataRequest { get; private set;}

		/// <summary>
		/// ConfiguredDataRequest primary constructor.
		/// </summary>
		/// <param name="data"></param>
		public ConfiguredDataRequest(Data data)
		{
			this.BaseDataRequest = data;
		}

		#region "Services"

		/// <summary>
		/// The instanciation of the specific Ideal Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public IdealDataRequest Ideal()
		{
			return new IdealDataRequest(this);
		}

		public IdealQrDataRequest IdealQr()
		{
			return new IdealQrDataRequest(this);
		}


		public CreditManagementDataRequest CreditManagement()
		{
			return new CreditManagementDataRequest(this);
		}

		/// <summary>
		/// The instanciation of the specific Ideal Service transaction.
		/// </summary>
		/// <returns> An ideal</returns>
		public EmandatesDataRequest EMandate()
		{
			return new EmandatesDataRequest(this);
		}

		#endregion
	}
}
