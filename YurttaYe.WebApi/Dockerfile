# src/YurttaYe.WebApi/Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["YurttaYe.WebApi/YurttaYe.WebApi.csproj", "YurttaYe.WebApi/"]
COPY ["YurttaYe.Application/YurttaYe.Application.csproj", "YurttaYe.Application/"]
COPY ["YurttaYe.Infrastructure/YurttaYe.Infrastructure.csproj", "YurttaYe.Infrastructure/"]
COPY ["YurttaYe.Domain/YurttaYe.Domain.csproj", "YurttaYe.Domain/"]
RUN dotnet restore "YurttaYe.WebApi/YurttaYe.WebApi.csproj"
COPY . .
WORKDIR "/src/YurttaYe.WebApi"
RUN dotnet build "YurttaYe.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YurttaYe.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YurttaYe.WebApi.dll"]