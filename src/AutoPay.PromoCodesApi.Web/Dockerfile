FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

FROM build AS test
WORKDIR /tests
COPY . .
RUN dotnet restore "tests/AutoPay.PromoCodesApi.Web/AutoPay.PromoCodesApi.Web.csproj"
RUN dotnet restore "tests/AutoPay.PromoCodesApi.Web/AutoPay.PromoCodesApi.Web.csproj"
RUN dotnet restore "tests/AutoPay.PromoCodesApi.Web/AutoPay.PromoCodesApi.Web.csproj"
RUN dotnet restore "tests/AutoPay.PromoCodesApi.Web/AutoPay.PromoCodesApi.Web.csproj"
ENTRYPOINT ["dotnet", "test", "--logger:trx"]

WORKDIR /src
COPY ["src/AutoPay.PromoCodesApi.Web/AutoPay.PromoCodesApi.Web.csproj", "src/AutoPay.PromoCodesApi.Web/"]
COPY ["src/AutoPay.PromoCodesApi.Core/AutoPay.PromoCodesApi.Core.csproj", "src/AutoPay.PromoCodesApi.Core/"]
COPY ["src/AutoPay.PromoCodesApi.UseCases/AutoPay.PromoCodesApi.UseCases.csproj", "src/AutoPay.PromoCodesApi.UseCases/"]
COPY ["src/AutoPay.PromoCodesApi.Infrastructure/AutoPay.PromoCodesApi.Infrastructure.csproj", "src/AutoPay.PromoCodesApi.Infrastructure/"]
COPY ["src/Migrations/AutoPay.PromoCodesApi.SqlServer/AutoPay.PromoCodesApi.SqlServer.csproj", "src/Migrations/AutoPay.PromoCodesApi.SqlServer/"]
COPY ["src/Migrations/AutoPay.PromoCodesApi.Sqlite/AutoPay.PromoCodesApi.Sqlite.csproj", "src/Migrations/AutoPay.PromoCodesApi.Sqlite/"]
RUN dotnet restore "src/AutoPay.PromoCodesApi.Web/AutoPay.PromoCodesApi.Web.csproj"
COPY . .
WORKDIR "/src/AutoPay.PromoCodesApi.Web"
RUN dotnet build "AutoPay.PromoCodesApi.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AutoPay.PromoCodesApi.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoPay.PromoCodesApi.Web.dll"]
