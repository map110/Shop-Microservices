FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/services/Discounts/Discounts.Api/Discounts.Api.csproj", "src/services/Discounts/Discounts.Api/"]
RUN dotnet restore "src/services/Discounts/Discounts.Api/Discounts.Api.csproj"
COPY . .
WORKDIR "/src/src/services/Discounts/Discounts.Api"
RUN dotnet build "Discounts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discounts.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discounts.Api.dll"]
