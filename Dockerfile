# Build Using SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet restore "SampleApi/SampleApi.csproj" 
RUN dotnet build "SampleApi/SampleApi.csproj" -c Release -o /app/build --no-restore 
RUN dotnet publish "SampleApi/SampleApi.csproj" -c Release -o /app/publish --no-restore 

# Final aspnet runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime

# Use non root port.
EXPOSE 8080
EXPOSE 8443

# Copy application binaries
USER app
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SampleApi.dll"]