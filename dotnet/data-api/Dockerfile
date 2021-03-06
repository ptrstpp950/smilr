# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

LABEL version="6.1.0"
ARG basedir="dotnet/data-api"

# copy csproj and restore as distinct layers
COPY ${basedir}/*.sln .
COPY ${basedir}/src/Smilr.DotNet/*.csproj ./src/Smilr.DotNet/
RUN dotnet restore

# copy everything else and build app
COPY ${basedir}/src/Smilr.DotNet/. ./src/Smilr.DotNet/
WORKDIR /source/src/Smilr.DotNet
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["./Smilr.DotNet"]