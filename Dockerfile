# Use the .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory inside the container
WORKDIR /app

# Copy the project files to the container
COPY *.csproj ./
RUN dotnet restore ./eHealth.Api.csproj

# Copy the rest of the application code to the container
COPY . ./

# Build the application
RUN dotnet publish ./eHealth.Api.csproj -c Release -o out

COPY ./eHealth.db ./out

# Create the final image using the .NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .


# Run the application
#ENTRYPOINT ["dotnet", "eHealth.Presentation.dll"]
ENTRYPOINT ["dotnet", "./eHealth.Api.dll", "--urls", "http://*:5071"]