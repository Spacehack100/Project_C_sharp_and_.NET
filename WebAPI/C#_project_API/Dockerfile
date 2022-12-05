FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build_env
WORKDIR /App
COPY *.csproj .
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App

EXPOSE 80

COPY --from=build_env /App/out .
ENTRYPOINT ["dotnet", "C#_project_API.dll"]