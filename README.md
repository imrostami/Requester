# Requester

A simple and efficient tool for testing your API endpoints without any hassle. Just create and add your request endpoints, then run the tests.


![image](https://github.com/user-attachments/assets/543d6922-f272-4031-a8c6-a2f6503498f0)


## Let's get started
First, we create a class that inherits from the base class `RequestEndpoint` 

For example:

```cs
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

```

Each `RequestEndpoint` provides two functions for sending the final response: `TestSucceeded` and `TestFailed`. You send the response generated in the current test as input to these functions so that it remains available for subsequent tests. For example, if you want to retrieve a todo item by its ID, which was created from the response of the previous test, you can access it using the `previousResult` object from parameter

It also has functions to send requests to specified endpoints such as
`GetAsync`
`PostAsync` 
and..
is
But note that entering the functions does not require entering the request address


Finally, to set up the request pipeline, you need to add your tests in your console application with `MapFromAssembly` and execute the `RunTests` function

```cs
var baseAddress = new Uri("https://jsonplaceholder.typicode.com");

var builder = new RequesterBuilder(baseAddress)
	.MapFromAssembly(typeof(Program).Assembly);


var app = builder.Build();

await app.RunTests();

```



