# Get started with Dapr’s Service Invocation building block

https://docs.dapr.io/getting-started/quickstarts/serviceinvocation-quickstart/

**Dapr (Distributed Application Runtime)** is a portable, event-driven runtime that makes it easy for developers to build resilient, microservice stateless and stateful applications that run on the cloud and edge and embraces the diversity of languages and developer frameworks.

Below, I'll guide you through the process of setting up a basic Dapr application with two services: a **client service** that invokes another service, and a **server service** that responds to the client's request

This example assumes you have Dapr installed and running on your machine

If you haven't installed Dapr yet, please refer to the official Dapr documentation for installation instructions

## 1. Prerequisites
.NET SDK (preferably .NET 5 or later)
Dapr CLI installed
Visual Studio Code or another C# IDE (optional but recommended for a better coding experience)
Step 1: Create the Server Service
Create a new ASP.NET Core Web API project for the server. You can do this from the command line:

bash
Copy code
dotnet new webapi -n DaprServer
cd DaprServer
Modify the default controller to create a simple API endpoint. Open Controllers/WeatherForecastController.cs or create a new controller, then adjust it as follows:

csharp
Copy code
using Microsoft.AspNetCore.Mvc;

namespace DaprServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            return $"Hello, {name}!";
        }
    }
}
Run the server with Dapr. Ensure Dapr is initialized, then run the following command in the terminal from the project directory:

bash
Copy code
dapr run --app-id serverapp --app-port 5000 -- dotnet run
This command runs the server application with Dapr, using serverapp as the application ID and 5000 as the port.

Step 2: Create the Client Service
Create another ASP.NET Core Web API project for the client in a different directory:

bash
Copy code
dotnet new webapi -n DaprClient
cd DaprClient
Add Dapr.AspNetCore NuGet package to the project to simplify Dapr integration:

bash
Copy code
dotnet add package Dapr.AspNetCore
Modify the default controller or create a new one to invoke the server service. Here’s how you can modify the WeatherForecastController.cs or any controller you prefer:

csharp
Copy code
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DaprClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvokeController : ControllerBase
    {
        public InvokeController()
        {
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<string>> Get(string name)
        {
            var daprClient = new DaprClientBuilder().Build();
            var invokeResponse = await daprClient.InvokeMethodAsync<string>(
                "serverapp", // Target app id
                "hello/"+name, // Method name
                HttpInvocationOptions.UsingGet());

            return invokeResponse;
        }
    }
}
Run the client with Dapr using a different terminal window or tab, ensuring to specify a different Dapr app ID and not specifying an app-port since this client doesn't listen on a specific port:

bash
Copy code
dapr run --app-id clientapp -- dotnet run
Step 3: Test Service Invocation
With both applications running, you can test the service invocation by accessing the client's endpoint, which in turn calls the server's endpoint. Use a tool like curl or Postman to make a GET request to the client service:

bash
Copy code
curl http://localhost:<client-port>/invoke/<name>
Replace <client-port> with the port the client app is running on (typically 5000 or 5001 by default for HTTP), and <name> with any name you wish to use in the greeting.

The client service will invoke the server service through Dapr, and you should see a response like "Hello, <name>!".

This simple example demonstrates how to use Dapr for service-to-service invocation in a microservices architecture with C#. For more complex scenarios, including state management, pub/sub messaging, and bindings, refer to the Dapr documentation.
