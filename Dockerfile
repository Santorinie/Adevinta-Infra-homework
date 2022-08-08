# Build
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Adevinta-hw/Adevinta-hw.csproj" --disable-parallel
RUN dotnet publish "./Adevinta-hw/Adevinta-hw.csproj" -c release -o /app --no-restore

# Serve
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "Adevinta-hw.dll"]
