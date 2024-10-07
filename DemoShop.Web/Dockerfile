FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DemoShop.Web/DemoShop.Web.csproj", "DemoShop.Web/"]
COPY ["DemoShop.ApplicationCore/DemoShop.ApplicationCore.csproj", "DemoShop.ApplicationCore/"]
COPY ["DemoShop.Infrastructure/DemoShop.Infrastructure.csproj", "DemoShop.Infrastructure/"]
RUN dotnet restore "DemoShop.Web/DemoShop.Web.csproj"
COPY . .
WORKDIR "/src/DemoShop.Web"
RUN dotnet build "DemoShop.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DemoShop.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoShop.Web.dll"]
