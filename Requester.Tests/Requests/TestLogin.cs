using ServiceHost.ApiTests.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Requester.Tests.Requests
{
	[Endpoint("/api/users/login")]
	internal class TestLogin : RequestEndpoint
	{
		public async override Task<IEndpointResult> Handle(IEndpointResult previousResult)
		{
			
			var loginRequest = new LoginRequestModel("me@gmail.com", "Pass@1");
			var response = await PostJsonAsync(loginRequest);

			if (response.IsSuccessStatusCode)
			{
				var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
				Headers.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);
				return TestSucceeded(response);
			}

			return TestFailed(response);
		}
	}
}
