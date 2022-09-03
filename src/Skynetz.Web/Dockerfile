FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Skynetz.Web/Skynetz.Web.csproj", "src/Skynetz.Web/"]
COPY ["src/Skynetz.Application/Skynetz.Application.csproj", "src/Skynetz.Application/"]
COPY ["src/Skynetz.Infra/Skynetz.Infra.csproj", "src/Skynetz.Infra/"]
COPY ["src/Skynetz.Domain/Skynetz.Domain.csproj", "src/Skynetz.Domain/"]
RUN dotnet restore "src/Skynetz.Web/Skynetz.Web.csproj"
COPY . .
WORKDIR "/src/src/Skynetz.Web"
RUN dotnet build "Skynetz.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Skynetz.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Skynetz.Web.dll"]
