using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;


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

        internal RequesterBuilder AddRequestEndpoint(string requestPath,RequestEndpoint endpoint)
        {
            endpoint.RequestPath = requestPath;
            endpoint.EndpointBaseAddress = baseAddress;
            _endpoints.Add(endpoint);
            return this;
        }

        public RequesterBuilder MapFromAssembly(Assembly assembly)
        {
            var endpointTypes = assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(RequestEndpoint)) &&
                !x.IsAbstract);

            foreach (var type in endpointTypes) 
            {
                var endpointAttribute = type.GetCustomAttribute<EndpointAttribute>();
                if(endpointAttribute != null)
                {
                    var endpointInstance = (RequestEndpoint)Activator.CreateInstance(type);
                    endpointInstance.EndpointBaseAddress = baseAddress;
                    endpointInstance.RequestPath = endpointAttribute.Route;


                    AddRequestEndpoint(endpointAttribute.Route, endpointInstance);
                }
            }

            return this;
        }

        public RequestApplication Build()
        {
            return new RequestApplication(httpClient, _endpoints);
        }

	}
}
