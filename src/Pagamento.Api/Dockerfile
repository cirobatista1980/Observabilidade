
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Pagamento.Api/Pagamento.Api.csproj", "src/Pagamento.Api/"]
RUN dotnet restore "src/Pagamento.Api/Pagamento.Api.csproj"
COPY . .
WORKDIR "/src/src/Pagamento.Api"
RUN dotnet build "Pagamento.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pagamento.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pagamento.Api.dll"]