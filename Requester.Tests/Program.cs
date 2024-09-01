using Requester;
using Requester.Tests.Requests;



var baseAddress = new Uri("https://localhost:7011/");


var builder = new RequesterBuilder(baseAddress)
	.AddRequestEndpoint("/api/users/login", new TestLogin())
	.AddRequestEndpoint("api/identity/validateAuth", new TestAuthrozie());



var app = builder.Build();

await app.RunTests();
Console.ReadKey();