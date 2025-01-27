# Base image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 5433 

# Environment variables for database connection
ENV DB_HOST=host.docker.internal
ENV DB_PORT=5433
ENV DB_USER=postgres
ENV DB_PASS=postgres
ENV DB_NAME=EmployeeScheduleDb

# Environment variables for ASP.NET Core
#ENV ASPNETCORE_URLS=http://+:8080;https://+:8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Install Node.js (20.x) and npm
RUN apt-get update && \
    apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_20.x | bash - && \
    apt-get install -y nodejs

# Copy the server project file
COPY ["EmployeeScheduleManagementWebApp.Server/EmployeeScheduleManagementWebApp.Server.csproj", "./"]

# Restore dependencies
RUN dotnet restore "EmployeeScheduleManagementWebApp.Server.csproj"

# Copy the entire solution
COPY . .

# Set the working directory to the server project
WORKDIR "/src/EmployeeScheduleManagementWebApp.Server"

# Build the application
RUN dotnet build "EmployeeScheduleManagementWebApp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EmployeeScheduleManagementWebApp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Entry point for the application
ENTRYPOINT ["dotnet", "EmployeeScheduleManagementWebApp.Server.dll"]
