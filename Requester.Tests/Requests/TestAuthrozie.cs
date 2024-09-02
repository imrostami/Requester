namespace Requester.Tests.Requests
{
	[Endpoint("api/identity/validateAuth")]
	internal class TestAuthrozie : RequestEndpoint
	{
		public  override async Task<IEndpointResult> Handle(IEndpointResult previousResult)
		{
			var response = await GetAsync();

			if (response.IsSuccessStatusCode)
				return TestSucceeded(response);

			return TestFailed(response);
		}
	}
}
