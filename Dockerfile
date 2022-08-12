FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001



# Build
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./Adevinta-hw/Adevinta-hw.csproj" --disable-parallel


FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS migration
WORKDIR /src
COPY . .
RUN dotnet restore "./MigrationHelper/MigrationHelper.csproj"
COPY . .
WORKDIR "/src/MigrationHelper"
RUN dotnet build "MigrationHelper.csproj" -c Release -o /app/migration

WORKDIR "/src/Adevinta-hw"
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update

FROM build AS publish
RUN dotnet publish "./Adevinta-hw/Adevinta-hw.csproj" -c release -o /app/publish --no-restore


FROM base AS final
WORKDIR /migration
COPY --from=migration /app/migration .

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Adevinta-hw.dll"]

