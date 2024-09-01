using System.Net.Http;

namespace Requester
{
	public interface IEndpointResult
	{
        bool Success { get; }
		HttpResponseMessage Response { get; }
        string Path { get; }



    }
}
