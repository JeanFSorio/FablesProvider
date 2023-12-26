FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the API project file
COPY ["FablesProvider.Api/FablesProvider.Api.csproj", "FablesProvider.Api/"]
# Copy the Core project file
COPY ["FablesProvider.Core/FablesProvider.Core.csproj", "FablesProvider.Core/"]

# Restore dependencies
RUN dotnet restore "./FablesProvider.Api/FablesProvider.Api.csproj"

# Copy the entire solution
COPY . .

WORKDIR "/src/FablesProvider.Api"
# Build the API project
RUN dotnet build "./FablesProvider.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# Publish the API project
RUN dotnet publish "./FablesProvider.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
# Copy the published output from the build stage
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FablesProvider.Api.dll"]
