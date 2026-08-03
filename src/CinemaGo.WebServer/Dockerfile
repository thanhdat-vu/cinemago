# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CinemaGo.WebServer/CinemaGo.WebServer.csproj", "src/CinemaGo.WebServer/"]
COPY ["src/CinemaGo.Infrastructure/CinemaGo.Infrastructure.csproj", "src/CinemaGo.Infrastructure/"]
COPY ["src/CinemaGo.Application/CinemaGo.Application.csproj", "src/CinemaGo.Application/"]
COPY ["src/CinemaGo.Domain/CinemaGo.Domain.csproj", "src/CinemaGo.Domain/"]
COPY ["src/CinemaGo.ServiceDefaults/CinemaGo.ServiceDefaults.csproj", "src/CinemaGo.ServiceDefaults/"]
RUN dotnet restore "./src/CinemaGo.WebServer/CinemaGo.WebServer.csproj"
COPY . .
WORKDIR "/src/src/CinemaGo.WebServer"
RUN dotnet build "./CinemaGo.WebServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CinemaGo.WebServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CinemaGo.WebServer.dll"]