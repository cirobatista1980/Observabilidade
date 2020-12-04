FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Venda.Api/Venda.Api.csproj", "src/Venda.Api/"]
RUN dotnet restore "src/Venda.Api/Venda.Api.csproj"
COPY . .
WORKDIR "/src/src/Venda.Api"
RUN dotnet build "Venda.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Venda.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Venda.Api.dll"]