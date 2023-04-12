#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Patient_Services/Patient_Services.csproj", "Patient_Services/"]
COPY ["Patient_Logic/Patient_Logic.csproj", "Patient_Logic/"]
COPY ["Patient_Entities/Patient_DataEntities.csproj", "Patient_Entities/"]
COPY ["Patient_Models/Patient_Models.csproj", "Patient_Models/"]
RUN dotnet restore "Patient_Services/Patient_Services.csproj"
COPY . .
WORKDIR "/src/Patient_Services"
RUN dotnet build "Patient_Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Patient_Services.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Patient_Services.dll"]