# Use official .NET image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ExpenseTracker.Web/ExpenseTracker.Web.csproj ExpenseTracker.Web/
RUN dotnet restore ExpenseTracker.Web/ExpenseTracker.Web.csproj
COPY . .
WORKDIR /src/ExpenseTracker.Web
RUN dotnet build ExpenseTracker.Web.csproj -c Release -o /app/build
RUN dotnet publish ExpenseTracker.Web.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ExpenseTracker.Web.dll"]
