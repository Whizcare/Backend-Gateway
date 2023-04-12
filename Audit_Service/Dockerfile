#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Audit_Service/Audit_Service.csproj", "Audit_Service/"]
COPY ["Audit_BusinessLogic/Audit_BusinessLogic.csproj", "Audit_BusinessLogic/"]
COPY ["Audit_Models/Audit_Models.csproj", "Audit_Models/"]
COPY ["Audit_DataEntites/Audit_DataEntites.csproj", "Audit_DataEntites/"]
RUN dotnet restore "Audit_Service/Audit_Service.csproj"
COPY . .
WORKDIR "/src/Audit_Service"
RUN dotnet build "Audit_Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Audit_Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Audit_Service.dll"]