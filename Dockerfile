# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy ONLY the .csproj file first
COPY ExpenseTracker.Web/ExpenseTracker.Web.csproj ExpenseTracker.Web/

# Restore dependencies
RUN dotnet restore ExpenseTracker.Web/ExpenseTracker.Web.csproj

# Copy everything
COPY . .

# Set working directory
WORKDIR /src/ExpenseTracker.Web

# Build
RUN dotnet build ExpenseTracker.Web.csproj -c Release -o /app/build

# Publish
RUN dotnet publish ExpenseTracker.Web.csproj -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Run the app
ENTRYPOINT ["dotnet", "ExpenseTracker.Web.dll"]
