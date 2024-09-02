using Requester;
using Requester.Tests.Requests;
using System.Reflection;



var baseAddress = new Uri("https://jsonplaceholder.typicode.com/");


var builder = new RequesterBuilder(baseAddress)
	.MapFromAssembly(typeof(Program).Assembly);



var app = builder.Build();

await app.RunTests();
Console.ReadKey();