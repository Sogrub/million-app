FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY MillionBackend/Million.Api/*.csproj Million.Api/
COPY MillionBackend/Million.Application/*.csproj Million.Application/
COPY MillionBackend/Million.Domain/*.csproj Million.Domain/
COPY MillionBackend/Million.Infrastructure/*.csproj Million.Infrastructure/

RUN dotnet restore Million.Api/Million.Api.csproj

COPY MillionBackend/ ./

WORKDIR /src/Million.Api
RUN ls -la   # 👈 Debug: para confirmar que Program.cs está aquí
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Million.Api.dll"]
