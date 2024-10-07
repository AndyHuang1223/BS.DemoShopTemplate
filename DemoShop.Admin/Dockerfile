FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DemoShop.Admin/DemoShop.Admin.csproj", "DemoShop.Admin/"]
COPY ["DemoShop.ApplicationCore/DemoShop.ApplicationCore.csproj", "DemoShop.ApplicationCore/"]
COPY ["DemoShop.Infrastructure/DemoShop.Infrastructure.csproj", "DemoShop.Infrastructure/"]
RUN dotnet restore "DemoShop.Admin/DemoShop.Admin.csproj"
COPY . .
WORKDIR "/src/DemoShop.Admin"
RUN dotnet build "DemoShop.Admin.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DemoShop.Admin.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoShop.Admin.dll"]
