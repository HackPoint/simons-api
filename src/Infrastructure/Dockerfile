FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
RUN dotnet restore "src/Infrastructure/Infrastructure.csproj"
COPY . .
WORKDIR "/src/src/Infrastructure"
RUN dotnet build "Infrastructure.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Infrastructure.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Infrastructure.dll"]
