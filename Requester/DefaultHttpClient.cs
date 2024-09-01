using System.Net.Http;

namespace Requester
{
	internal static class DefaultHttpClient
	{
        internal static HttpClient Shared { get; set; }
    }
}
