#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Allergy_Services/Allergy_Services.csproj", "Allergy_Services/"]
COPY ["Allergy_BusinessLogic/Allergy_BusinessLogic.csproj", "Allergy_BusinessLogic/"]
COPY ["Allergy_Entities/Allergy_DataEntities.csproj", "Allergy_Entities/"]
COPY ["Allergy_Models/Allergy_Models.csproj", "Allergy_Models/"]
RUN dotnet restore "Allergy_Services/Allergy_Services.csproj"
COPY . .
WORKDIR "/src/Allergy_Services"
RUN dotnet build "Allergy_Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Allergy_Services.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Allergy_Services.dll"]