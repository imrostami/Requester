using Requester;
using Requester.Tests.Requests;

var baseAddress = new Uri("https://jsonplaceholder.typicode.com");

var builder = new RequesterBuilder(baseAddress)
	.AddRequestEndpoint("/todos", new TestRequest1())
	.AddRequestEndpoint("/todos", new TestRequest1())
	.AddRequestEndpoint("/todos", new TestRequest1())
	.AddRequestEndpoint("/todosk", new TestRequest1())
	.AddRequestEndpoint("/todos", new TestRequest1())
	.AddRequestEndpoint("/todos", new TestRequest1())
	.AddRequestEndpoint("/todos", new TestRequest1());

var app = builder.Build();

await app.RunTests();

