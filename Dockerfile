# ==========================================
# STAGE 1: Build & Publish the Application
# ==========================================

# Use the heavy .NET 10 SDK image to compile and build the code
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build


# Set the working directory inside the container for the build stage
WORKDIR /src

# Copy only the project file first to leverage Docker's layer caching
COPY ["VideoGameCharacterAPI.csproj", "."]

# Restore the required NuGet packages based on the project file
RUN dotnet restore "VideoGameCharacterAPI.csproj"

# Copy all remaining source code files from your host machine into the container
COPY . .

# Compile and publish the app in Release mode to the "/app/publish" folder, skipping re-restore
RUN dotnet publish "VideoGameCharacterAPI.csproj" -c Release -o /app/publish --no-restore

# ==========================================
# STAGE 2: Create the Final Production Image
# ==========================================

# Switch to the lightweight .NET 10 ASP.NET runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

# Set the working directory where the application will run from
WORKDIR /app

# Document that the container intends to listen on port 8080
EXPOSE 8080

# Configure the .NET runtime environment variable to use port 8080 for HTTP requests
ENV ASPNETCORE_HTTP_PORTS=8080

# Copy ONLY the optimized, compiled application binaries from the build stage
COPY --from=build /app/publish .

# Define the command that executes when the container starts up
ENTRYPOINT ["dotnet", "VideoGameCharacterAPI.dll"]
