using BuckarooSdk.Services.CreditManagement.DataRequest;
using BuckarooSdk.Services.EMandate;
using BuckarooSdk.Services.Ideal.DataRequest;
using BuckarooSdk.Services.IdealQr.DataRequest;
using BuckarooSdk.Services.Klarna;

namespace BuckarooSdk.Data
{
	public class ConfiguredDataRequest
	{
		internal Data BaseDataRequest { get; private set; }

		/// <summary>
		/// ConfiguredDataRequest primary constructor.
		/// </summary>
		/// <param name="data"></param>
		public ConfiguredDataRequest(Data data)
		{
			this.BaseDataRequest = data;
		}

		#region "Services"

		public KlarnaRequestObject Klarna()
		{
			return new KlarnaRequestObject(this);
		}

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

		public EMandateRequestObject EMandate()
		{
			return new EMandateRequestObject(this);
		}

		#endregion
	}
}
