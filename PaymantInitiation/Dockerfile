#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

LABEL "com.docker.compose.project"="saga-choreography"

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PaymantInitiation/PaymantInitiation.csproj", "PaymantInitiation/"]
RUN dotnet restore "PaymantInitiation/PaymantInitiation.csproj"
COPY . .
WORKDIR "/src/PaymantInitiation"
RUN dotnet build "PaymantInitiation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaymantInitiation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaymantInitiation.dll"]