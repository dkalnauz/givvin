# Set the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Set the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=”production”

# Expose the desired port (replace 80 with your application's port if needed)
EXPOSE 5000

# Set the entry point
ENTRYPOINT ["dotnet", "Givvin.Volunteer.dll"]