FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY . .

RUN dotnet restore "./marthaLibrary.API/marthaLibrary.API.csproj" 
RUN dotnet publish "./marthaLibrary.API/marthaLibrary.API.csproj"  -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0 
WORKDIR /app
COPY --from=build /app ./

# Copy server.crt from the root directory to the /app directory in the image
COPY server.crt /app/server.crt
COPY server.key /app/server.key

# Configure Kestrel to use the copied certificate
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/server.crt
ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/app/server.key

CMD ASPNETCORE_URLS=http://*:$PORT dotnet  marthaLibrary.API.dll
