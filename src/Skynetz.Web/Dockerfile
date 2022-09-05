FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app 
#
COPY *.sln .
COPY src/Skynetz.Web/*.csproj ./src/Skynetz.Web/
COPY src/Skynetz.Application/*.csproj ./src/Skynetz.Application/
COPY src/Skynetz.Domain/*.csproj ./src/Skynetz.Domain/
COPY src/Skynetz.Infra/*.csproj ./src/Skynetz.Infra/ 
COPY src/Skynetz.Test/*.csproj ./src/Skynetz.Test/ 
#
RUN dotnet restore 
#
COPY src/Skynetz.Web/. ./src/Skynetz.Web/
COPY src/Skynetz.Application/. ./src/Skynetz.Application/
COPY src/Skynetz.Domain/. ./src/Skynetz.Domain/ 
COPY src/Skynetz.Infra/. ./src/Skynetz.Infra/ 
#
WORKDIR /app/src/Skynetz.Web
RUN dotnet restore
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS runtime
WORKDIR /app 
#
COPY --from=build /app/src/Skynetz.Web/out ./
ENTRYPOINT ["dotnet", "Skynetz.Web.dll"]