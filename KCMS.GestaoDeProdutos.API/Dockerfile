#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KCMS.GestaoDeProdutos.API/KCMS.GestaoDeProdutos.API.csproj", "KCMS.GestaoDeProdutos.API/"]
RUN dotnet restore "KCMS.GestaoDeProdutos.API/KCMS.GestaoDeProdutos.API.csproj"
COPY . .
WORKDIR "/src/KCMS.GestaoDeProdutos.API"
RUN dotnet build "KCMS.GestaoDeProdutos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KCMS.GestaoDeProdutos.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KCMS.GestaoDeProdutos.API.dll"]