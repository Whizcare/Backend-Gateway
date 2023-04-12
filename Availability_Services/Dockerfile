#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Availability_Services/Availability_Services.csproj", "Availability_Services/"]
COPY ["Availability_BusinessLogic/Availability_BusinessLogic.csproj", "Availability_BusinessLogic/"]
COPY ["Avaiability_Entities/Availability_DataEntities.csproj", "Avaiability_Entities/"]
COPY ["Availability_Models/Availability_Models.csproj", "Availability_Models/"]
RUN dotnet restore "Availability_Services/Availability_Services.csproj"
COPY . .
WORKDIR "/src/Availability_Services"
RUN dotnet build "Availability_Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Availability_Services.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Availability_Services.dll"]