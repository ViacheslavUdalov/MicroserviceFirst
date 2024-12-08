FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

# copy all .csproj files and restore as distinct layers. Use of the same COPY comand
# for every dockerfile in the profect to take advantage of docker caching

COPY MicroserviceFirst.sln MicroserviceFirst.sln 
COPY MicroserviceFirst/MicroserviceFirst.csproj MicroserviceFirst/MicroserviceFirst.csproj
COPY SearchService/SearchService.csproj SearchService/SearchService.csproj
COPY GatewayService/GatewayService.csproj GatewayService/GatewayService.csproj
COPY Contracts/Contracts.csproj Contracts/Contracts.csproj
COPY IdentityService/IdentityService.csproj IdentityService/IdentityService.csproj

# Restore package deps
RUN dotnet restore MicroserviceFirst.sln

# Copy the app folders over
COPY GatewayService GatewayService
COPY Contracts Contracts

WORKDIR /app/GatewayService
RUN dotnet publish -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "GatewayService.dll"]