using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Requester
{
	public interface IHttpRequests
	{

		Task<HttpResponseMessage> DeleteAsync();


		Task<HttpResponseMessage> GetAsync();
		Task<HttpResponseMessage> GetAsync(HttpCompletionOption completionOption);


		 Task<byte[]> GetByteArrayAsync();
		 Task<Stream> GetStreamAsync();

		 Task<string> GetStringAsync();

		 Task<HttpResponseMessage> PostAsync(HttpContent content);

		 Task<HttpResponseMessage> PutAsync(HttpContent content);
		Task<HttpResponseMessage> SendJsonBodyAsync<T>(T body, HttpMethod method);
		Task<HttpResponseMessage> PostJsonAsync<T>(T body);
	}
}
