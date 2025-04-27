# Use official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy the csproj and restore as distinct layers
COPY ExpenseTracker.Web/*.csproj ExpenseTracker.Web/
RUN dotnet restore ExpenseTracker.Web/ExpenseTracker.Web.csproj

# Copy everything else and build
COPY . .
WORKDIR /src/ExpenseTracker.Web
RUN dotnet build ExpenseTracker.Web.csproj -c Release -o /app/build
RUN dotnet publish ExpenseTracker.Web.csproj -c Release -o /app/publish /p:UseAppHost=false

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ExpenseTracker.Web.dll"]
