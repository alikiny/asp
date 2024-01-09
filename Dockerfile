FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution file
COPY *.sln .

# Copy project files for NuGet restore
COPY WebDemo.API/WebDemo.API.csproj WebDemo.API/
COPY WebDemo.Core/WebDemo.Core.csproj WebDemo.Core/
COPY WebDemo.Business/WebDemo.Business.csproj WebDemo.Business/
COPY WebDemo.Controller/WebDemo.Controller.csproj WebDemo.Controller/

# Restore NuGet packages
RUN dotnet restore

# Copy the rest of the source code
COPY WebDemo.API/ WebDemo.API/
COPY WebDemo.Core/ WebDemo.Core/
COPY WebDemo.Business/ WebDemo.Business/
COPY WebDemo.Controller/ WebDemo.Controller/

# Build and publish the API project
WORKDIR /app/WebDemo.API
RUN dotnet publish -c Release -o /publish

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "WebDemo.API.dll"]  # Replace with the actual DLL name
