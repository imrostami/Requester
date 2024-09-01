using System;
using System.Collections.Generic;
using System.Net.Http;


namespace Requester
{
	public class RequesterBuilder
	{
		private List<RequestEndpoint> _endpoints;
		private Uri baseAddress = null;
        HttpClient httpClient;
        public RequesterBuilder(Uri requestBaseAddress)
        {
            _endpoints = new List<RequestEndpoint>();
            baseAddress = requestBaseAddress;
            
            httpClient = new HttpClient() 
            {
                BaseAddress = baseAddress
            };
        }

        public RequesterBuilder AddRequestEndpoint(string requestPath,RequestEndpoint endpoint)
        {
            endpoint.RequestPath = requestPath;
            endpoint.EndpointBaseAddress = baseAddress;
            _endpoints.Add(endpoint);
            return this;
        }

        public RequestApplication Build()
        {
            return new RequestApplication(httpClient, _endpoints);
        }

	}
}
