FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Simons.Api/Simons.Api.csproj", "Simons.Api/"]
RUN dotnet restore "Simons.Api/Simons.Api.csproj"
COPY . .
WORKDIR "/src/Simons.Api"
RUN dotnet build "Simons.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Simons.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simons.Api.dll"]
