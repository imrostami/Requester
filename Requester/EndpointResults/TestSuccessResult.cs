using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Requester.EndpointResults
{
	public class TestSuccessResult : IEndpointResult
	{
		public TestSuccessResult(bool success, HttpResponseMessage response,string requestPath)
		{
			Success = success;
			Response = response;
			Path = requestPath;
		}

		public bool Success { get; }

		public HttpResponseMessage Response { get; }

		public string Path { get; }
	}
}
