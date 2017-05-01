using BuckarooSdk.DataTypes.Response;
using BuckarooSdk.DataTypes;
using BuckarooSdk.DataTypes.RequestBases;

namespace BuckarooSdk.Data
{
	public class ConfiguredServiceDataRequest
	{
		internal Data BaseData { get; set; }

		internal ConfiguredServiceDataRequest(Data data)
		{
			this.BaseData = data;
		}

		/// <summary>
		/// Execute the request, a post to the Buckaroo Payment Engine is prepared and send.
		/// </summary>
		/// <returns>General DataResponse object is returned</returns>
		public RequestResponse Execute()
		{
			var response = Connection.Connector.SendRequest<IRequestBase, RequestResponse>(this.BaseData.Request.Request, this.BaseData.DataRequestBase, HttpRequestType.Post).Result;

			// relocate logger from request to response
			response.BuckarooSdkLogger = this.BaseData.Request.Request.BuckarooSdkLogger;
			return response;
		}
	}
}
