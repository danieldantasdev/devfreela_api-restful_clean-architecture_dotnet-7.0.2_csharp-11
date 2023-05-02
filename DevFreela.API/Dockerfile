FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DevFreela.API/DevFreela.API.csproj", "DevFreela.API/"]
RUN dotnet restore "DevFreela.API/DevFreela.API.csproj"
COPY . .
WORKDIR "/src/DevFreela.API"
RUN dotnet build "DevFreela.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevFreela.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevFreela.API.dll"]
