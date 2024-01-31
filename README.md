# dapr: Service Invocation

https://www.youtube.com/watch?v=NBDQ8vp0E_M&list=PLbFaOt0VQ7S9txKOwJQIb258Wq99dgISL&index=2

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

