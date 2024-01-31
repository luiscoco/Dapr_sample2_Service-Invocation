# dapr: Service Invocation

https://www.youtube.com/watch?v=NBDQ8vp0E_M&list=PLbFaOt0VQ7S9txKOwJQIb258Wq99dgISL&index=2

## 1. Run VSCode and install dapr extension

We install the dapr extension

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/d1b8e3f4-caff-49d5-af71-ac9bd3606393)

We click on the dapr button in the left hand side panel to see the extension options

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/2b2abdb6-2861-425a-bb37-d374340e2522)

## 2. Create a .NET8 WebAPI 

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

We can open a new Terminal Window and list the running dapr apps

```
dapr list
```

![image](https://github.com/luiscoco/Dapr_sample2_Service-Invocation/assets/32194879/ca9bf2f6-9882-418c-b9f5-01d62fd9b7bd)




