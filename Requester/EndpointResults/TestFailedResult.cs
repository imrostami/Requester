using System.Net.Http;

namespace Requester.EndpointResults
{
	public class TestFailedResult : IEndpointResult
	{
		public TestFailedResult(bool success, HttpResponseMessage response,string requestPath)
		{
			Success = success;
			Response = response;
			Path = requestPath;
		}

		public bool Success { get; }

		public HttpResponseMessage Response { get; }

		public string Path {  get; }
	}
}
