using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Requester
{
	public class RequestApplication
	{
		List<RequestEndpoint> _requestEndpoints;
		HttpClient _http;

		public RequestApplication(HttpClient httpClient,List<RequestEndpoint> requestEndpoints)
        {
            _requestEndpoints = requestEndpoints;
			_http = httpClient;
        }

		public async Task RunTests()
		{
			IEndpointResult endpointResult = null;

			for (int i = 0; i < _requestEndpoints.Count; i++)
			{
				if (i <= 0)
				{
					endpointResult = await _requestEndpoints[i].Handle(null);
				}
				endpointResult = await _requestEndpoints[i].Handle(endpointResult);


				if (!endpointResult.Success)
				{
					Report.CreateCheckbox(false, $"{endpointResult.Path} endpoint test failed (Status Code : {(int)endpointResult.Response.StatusCode}  {endpointResult.Response.StatusCode})");
					await endpointResult.Response.LogAsync();
					await endpointResult.Response.RequestMessage.LogAsync();
                    break;
				}	

				if (endpointResult.Success)
					Report.CreateCheckbox(true, $"{endpointResult.Path} Endpoint test was successful");


				
			}
		}



    }
}
