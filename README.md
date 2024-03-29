# dapr: Service Invocation

The source code is available in this github repo: https://github.com/luiscoco/Dapr_sample2_Service-Invocation

This example is explained in these two youtube videos:

https://www.youtube.com/watch?v=NBDQ8vp0E_M&list=PLbFaOt0VQ7S9txKOwJQIb258Wq99dgISL&index=2

https://www.youtube.com/watch?v=JpDOUhM5e1w&list=PLbFaOt0VQ7S9txKOwJQIb258Wq99dgISL&index=3

## 1. Run VSCode and install dapr extension

We install the dapr extension

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/d1b8e3f4-caff-49d5-af71-ac9bd3606393)

We click on the dapr button in the left hand side panel to see the extension options

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/2b2abdb6-2861-425a-bb37-d374340e2522)

## 2. Create a .NET8 WebAPI (backend)

We open a Terminal Window and run this command:

```
dotnet new webapi -o backend --no-https
```

We can verify the projec folders structure

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/79dbc9b8-655c-41ee-9e55-54c07200711b)

We run the WebAPI

```
cd backend
dotnet run
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/579744ca-5174-46be-a8db-cf754022cb71)

We access to the application endpoint

http://localhost:5144/swagger/index.html

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/ef83292b-6c80-4eaf-a5c8-c18d9d57669d)

We can also run the application with dapr

```
dapr run --app-id DaprServerServiceInvocation --app-port 5144 --dapr-http-port 3500 dotnet run
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/035b1ad2-a471-446e-8405-c83c225f314e)
A
We can open a new Terminal Window and list the running dapr apps

```
dapr list
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/ca9bf2f6-9882-418c-b9f5-01d62fd9b7bd)

We can also run the dapr dashboard

```
dapr dashboard
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/964996fd-6c11-41f9-b5db-2ce80cdbf45b)

We access the dapr dashboard

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/7f5a9d38-a145-4473-876e-f261e480023e)

We click on the running application name and we can see the two tabs: summary and actors

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/0cac9635-ab6c-415e-b014-9367917aea6a)

We click on the **dapr button**, in the left hand side menu, and we right-click on the application name and select the menu option "**Invoke (GET) Application Method**"

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/7e17df85-b8d1-48dd-a5ba-b10fe783ed25)

We type the method name to invoke in the textbox

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/c459772f-08d0-4898-80e9-dbf355efdb5e)

We obtain the output in the terminal window

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/772fec0d-b676-43fa-93f2-da3a3281bf02)

We open a new Terminal Window and run the following command to Invoke a Rest Method with dapr

```
Invoke-RestMethod -Uri 'http://localhost:3500/v1.0/invoke/DaprServerServiceInvocation/method/weatherforecast'
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/0b0002a6-5a6d-40f1-b327-d46a4131034b)

## 3. Create Blazor app (frontend)

We run this command to create the frontend blazor app

```
dotnet new blazorserver -o frontend --no-https
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/ec9f7c66-9e09-418f-9a8d-9158a43de11b)

We load the dependency "**Dapr.AspNetCore**"

We navigate to Nuget URL: https://www.nuget.org/p

We search for the dependency 

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/0a655172-e54f-4554-8c2c-484d70f98d12)

We copy the installation command

```
dotnet add package Dapr.AspNetCore --version 1.12.0
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/97e9bb54-7cfb-4429-a9b8-94eb66c933f8)

We navigate into the frontend folder and load the dependency

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/32a7da60-3a75-4065-8733-e8fff473fc0e)

In the **launchSettings.json** we confirm the http port is different to the port used by the backend application

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/f515a557-a432-42c3-a5dc-4c936d58e4bc)

We now modify the frontend middleware 

**program.cs**

```csharp
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using frontend.Data;
using Dapr.Client;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// JsonSerializer options
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDaprClient(builder =>
{
    builder.UseJsonSerializationOptions(options);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
```

We also modify the **Imports.razor** file we add a new library **@using Dapr.Client**

```razor 
@using System.Net.Http
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.JSInterop
@using frontend
@using frontend.Shared
@using Dapr.Client
```

We modify the Pages/Fetchdata.razor file to invoke the backend service

```razor
@page "/fetchdata"
@using frontend.Data
@inject DaprClient Dapr

<PageTitle>Weather forecast</PageTitle>

<h1>Weather forecast</h1>

<p>This component demonstrates fetching data from a service.</p>

@if (forecasts == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table">
        <thead>
            <tr>
                <th>Date</th>
                <th>Temp. (C)</th>
                <th>Temp. (F)</th>
                <th>Summary</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var forecast in forecasts)
            {
                <tr>
                    <td>@forecast.Date.ToShortDateString()</td>
                    <td>@forecast.TemperatureC</td>
                    <td>@forecast.TemperatureF</td>
                    <td>@forecast.Summary</td>
                </tr>
            }
        </tbody>
    </table>
}

@code {
    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Dapr.InvokeMethodAsync<WeatherForecast[]>(HttpMethod.Get,"backend","weatherforecast");
    }
}
```

We **build the frontend** application

```
cd frontend
dotnet build
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/f7bbec04-b550-4fc7-a78b-12c91cddb0e9)

We open two Terminal Windows, in one of them we run with dapr the frontend and in the other Terminal Window we run the backend application

```
cd backend
dapr run --app-id backend --app-port 5144 dotnet run
```

```
cd frontend
dapr run --app-id frontend --app-port 5168 dotnet run
```


We open another Terminal Window and we verify both dapr applications are running

```
dapr list
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/237fcafa-0202-46c3-b56b-6c2e63da1a3d)

We can also run the dapr dashboard to see both applications details

```
dapr dashboard -p 0
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/ee9ed17b-2059-49fa-b3b1-b533d531229f)

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/22fe8906-e0f2-4980-ad54-76e3e43e0e93)

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/5bd9be73-368c-47c2-9eff-65376fb1d940)

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/3bd52911-66e6-493a-b9fe-c9d9a31aac2f)

We can access to the backend with the dapr button in VSCode to invoke the weatherforecast method

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/25ec349f-585a-4eb2-9ee6-05378ad82bb4)

We can access to the frontend application and check the backend service call

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/48998715-a090-486e-81ad-8fcd7717da0e)

We can also access to the backend application

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/dc7878d3-9720-4b4d-9233-9dcbb07b44da)
