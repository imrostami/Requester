namespace Requester.Tests.Requests
{
	internal class TestAuthrozie : RequestEndpoint
	{
		public  override async Task<IEndpointResult> Handle(IEndpointResult previousResult)
		{
			var response = await Http.GetAsync(RequestPath);

			if (response.IsSuccessStatusCode)
				return TestSucceeded(response);

			return TestFailed(response);
		}
	}
}
