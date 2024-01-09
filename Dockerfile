FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY . .

RUN dotnet restore "./marthaLibrary.API/marthaLibrary.API.csproj" 
RUN dotnet publish "./marthaLibrary.API/marthaLibrary.API.csproj"  -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0 
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT [ "dotnet",  "marthaLibrary.API.dll"]
