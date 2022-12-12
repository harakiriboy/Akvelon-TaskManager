# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

WORKDIR /source

COPY *csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /app


# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal

WORKDIR /app
EXPOSE 80
COPY --from=build /app ./
ENTRYPOINT [ "dotnet","Akvelon-Task-Manager.dll" ]