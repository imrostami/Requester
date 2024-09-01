# Requester

A simple and efficient tool for testing your API endpoints without any hassle. Just create and add your request endpoints, then run the tests.


![image](https://github.com/user-attachments/assets/543d6922-f272-4031-a8c6-a2f6503498f0)

### Install
```ps
NuGet\Install-Package Devnotec.Requester -Version 1.0.0
```


## Let's get started
First, we create a class that inherits from the base class `RequestEndpoint` 

For example:

```cs
public class TestRequest1 : RequestEndpoint
{
	public override async Task<IEndpointResult> Handle(IEndpointResult previousResult)
	{
		var response = await Http.GetAsync(RequestPath);

		if(response.IsSuccessStatusCode)
			return TestSucceeded(response);
		return TestFailed(response);
	}
}
```

Each `RequestEndpoint` provides two functions for sending the final response: `TestSucceeded` and `TestFailed`. You send the response generated in the current test as input to these functions so that it remains available for subsequent tests. For example, if you want to retrieve a todo item by its ID, which was created from the response of the previous test, you can access it using the `previousResult` object from parameter


Finally, to set up the request pipeline, you need to add your tests in your console application and execute the `RunTests` function

```cs
var baseAddress = new Uri("https://jsonplaceholder.typicode.com");

var builder = new RequesterBuilder(baseAddress)
	.AddRequestEndpoint("/todos", new TestRequest1())
	.AddRequestEndpoint("/todosk", new TestRequest1());

var app = builder.Build();

await app.RunTests();

```
