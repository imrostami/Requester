
namespace Requester.Tests.Requests;

[Endpoint("/todos")]
internal class JsonPlaseholderTest : RequestEndpoint
{
	public override async Task<IEndpointResult> Handle(IEndpointResult previousResult)
	{
		var todos = await GetAsync();
		if (todos.IsSuccessStatusCode)
			return TestSucceeded(todos);

		return TestFailed(todos);
	}
}
