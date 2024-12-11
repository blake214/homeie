# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

# Copy csproj and restore dependencies
COPY HomeIEApi/*.csproj ./HomeIEApi/
WORKDIR /app/HomeIEApi
RUN dotnet restore

# Copy all source files and publish the app
WORKDIR /app
COPY HomeIEApi/ ./HomeIEApi/
RUN dotnet publish HomeIEApi/HomeIEApi.csproj -c Release -o /app/out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Install SQLite in the runtime image
RUN apt-get update && apt-get install -y sqlite3

WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out .

# Copy the database into the container
COPY HomeIEApi/Database/ ./Database

# Expose the application's port
EXPOSE 5185

# Start the application
ENTRYPOINT ["dotnet", "HomeIEApi.dll"]
