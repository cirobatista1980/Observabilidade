FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Estoque.Api/Estoque.Api.csproj", "src/Estoque.Api/"]
RUN dotnet restore "src/Estoque.Api/Estoque.Api.csproj"
COPY . .
WORKDIR "/src/src/Estoque.Api"
RUN dotnet build "Estoque.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Estoque.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Estoque.Api.dll"]