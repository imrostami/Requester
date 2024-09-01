using Requester.EndpointResults;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Requester
{
	public abstract class RequestEndpoint
	{
        internal Uri EndpointBaseAddress { get; set; }

        public HttpClient Http
		{
			get
			{
				if(DefaultHttpClient.Shared == null)
				{
					DefaultHttpClient.Shared = new HttpClient()
					{
						BaseAddress = EndpointBaseAddress
					};
					return DefaultHttpClient.Shared;
				}
				return DefaultHttpClient.Shared;
			}
		}
		public abstract Task<IEndpointResult> Handle(IEndpointResult previousResult);

        public string RequestPath { get; set; }


		public IEndpointResult TestSucceeded(HttpResponseMessage response)
		{
			return new TestSuccessResult(true, response,RequestPath);
		}

		public IEndpointResult TestFailed(HttpResponseMessage response) 
		{
			return new TestFailedResult(false, response,RequestPath);
		}

	}
}
