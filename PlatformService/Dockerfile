#1 define the base image you want to use
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env

#2 copy the application files into the container
#COPY . /app
WORKDIR /app

#3 copy the csproj to get to know the dependencies
COPY *csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT [ "dotnet", "PlatformService.dll" ]