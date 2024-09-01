using Requester;


var baseAddress = @"https://jsonplaceholder.typicode.com/todos";
RequesterBuilder builder = new(new Uri(baseAddress));


class Request1 : IRequest
{
	public Task<bool> HandleRequest(RequestContext client)
	{
		throw new NotImplementedException();
	}
}

