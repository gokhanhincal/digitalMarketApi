FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["../DigitalMarket.WebApi/DigitalMarket.WebApi.csproj", "DigitalMarket.WebApi/"]
COPY ["../DigitalMarket.Core/DigitalMarket.Core.csproj", "DigitalMarket.Core/"]
COPY ["../DigitalMarket.Data/DigitalMarket.Data.csproj", "DigitalMarket.Data/"]
RUN dotnet restore "DigitalMarket.WebApi/DigitalMarket.WebApi.csproj"
COPY . .
WORKDIR "/src/DigitalMarket.WebApi"
RUN dotnet build "DigitalMarket.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DigitalMarket.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalMarket.WebApi.dll", "--environment = Development"]
