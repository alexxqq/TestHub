FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY TestHub.sln .  
COPY TestHub/*.csproj TestHub/
COPY TestHub.Core/*.csproj TestHub.Core/
COPY TestHub.Data/*.csproj TestHub.Data/
COPY TestHub.Services/*.csproj TestHub.Services/
COPY TestHub.Tests/*.csproj TestHub.Tests/
COPY TestHubUnitTests/*.csproj TestHubUnitTests/

RUN dotnet restore TestHub.sln

COPY . ./

RUN dotnet publish TestHub.sln -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "TestHub.View.dll"]
