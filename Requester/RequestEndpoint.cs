using Newtonsoft.Json;
using Requester.EndpointResults;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Requester
{
	public abstract class RequestEndpoint : IHttpRequests
	{
        internal Uri EndpointBaseAddress { get; set; }


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

		public async Task<HttpResponseMessage> DeleteAsync()
		{
			return await Http.DeleteAsync(new Uri(EndpointBaseAddress, RequestPath));	
		}

		public async Task<HttpResponseMessage> GetAsync()
		{
			return await Http.GetAsync(new Uri(EndpointBaseAddress, RequestPath));
		}

		public async Task<HttpResponseMessage> GetAsync(HttpCompletionOption completionOption)
		{
			return await Http.GetAsync(new Uri(EndpointBaseAddress, RequestPath),completionOption);
		}

		public async Task<byte[]> GetByteArrayAsync()
		{
			return await Http.GetByteArrayAsync(new Uri(EndpointBaseAddress, RequestPath));
		}

		public async Task<Stream> GetStreamAsync()
		{
			return await Http.GetStreamAsync(new Uri(EndpointBaseAddress, RequestPath));
		}

		public async Task<string> GetStringAsync()
		{
			return await Http.GetStringAsync(new Uri(EndpointBaseAddress, RequestPath));
		}

		public async Task<HttpResponseMessage> PostAsync(HttpContent content)
		{
			return await Http.PostAsync(new Uri(EndpointBaseAddress, RequestPath),content);
		}

		public async Task<HttpResponseMessage> PutAsync(HttpContent content)
		{
			return await Http.PutAsync(new Uri(EndpointBaseAddress, RequestPath),content);
		}

		public async Task<HttpResponseMessage> SendJsonBodyAsync<T>(T body,HttpMethod httpMethod)
		{
			var jsonBody = JsonConvert.SerializeObject(body);
			var request = new HttpRequestMessage()
			{
				RequestUri = new Uri(EndpointBaseAddress, RequestPath),
				Method = httpMethod,
				Content = new StringContent(jsonBody)
				{
					Headers =
					{
						ContentType = new MediaTypeHeaderValue("application/json")
					}
				}
			};


			return await Http.SendAsync(request);

		}

		public async Task<HttpResponseMessage> PostJsonAsync<T>(T body)
		{
			var json = JsonConvert.SerializeObject(body);
			var requestContent = new StringContent(json);


			return await Http.PostAsync(new Uri(EndpointBaseAddress, RequestPath),requestContent);
		}

		internal HttpClient Http
		{
			get
			{
				if (DefaultHttpClient.Shared == null)
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

		public HttpRequestHeaders Headers
		{
			get
			{
				return Http.DefaultRequestHeaders;
			}
		}



	}
}
