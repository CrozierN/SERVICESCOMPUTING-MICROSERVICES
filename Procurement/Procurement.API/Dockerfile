#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Procurement/Procurement.API/Procurement.API.csproj", "Procurement/Procurement.API/"]
RUN dotnet restore "Procurement/Procurement.API/Procurement.API.csproj"
COPY . .
WORKDIR "/src/Procurement/Procurement.API"
RUN dotnet build "Procurement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Procurement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Procurement.API.dll"]