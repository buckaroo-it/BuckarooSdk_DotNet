using System.Threading.Tasks;
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
			var response = Connection.Connector.SendRequest<IRequestBase, RequestResponse>(this.BaseData.AuthenticatedRequest.Request, this.BaseData.DataRequestBase, HttpRequestType.Post).Result;

			// relocate logger from request to response
			response.BuckarooSdkLogger = this.BaseData.AuthenticatedRequest.Request.BuckarooSdkLogger;
			return response;
		}

		/// <summary>
		/// Asynchronously execute the request, a post to the Buckaroo Payment Engine is prepared and sent.
		/// </summary>
		/// <returns>General Dataresponse object is returned</returns>
		public async Task<RequestResponse> ExecuteAsync()
		{
			var response = await Connection.Connector.SendRequest<IRequestBase, RequestResponse>(this.BaseData.AuthenticatedRequest.Request, this.BaseData.DataRequestBase, HttpRequestType.Post)
				.ConfigureAwait(false);

			// relocate logger from request to response
			response.BuckarooSdkLogger = this.BaseData.AuthenticatedRequest.Request.BuckarooSdkLogger;

			return response;
		}
	}
}
