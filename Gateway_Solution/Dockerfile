#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Gateway_Solution/Gateway_Solution.csproj", "Gateway_Solution/"]
RUN dotnet restore "Gateway_Solution/Gateway_Solution.csproj"
COPY . .
WORKDIR "/src/Gateway_Solution"
RUN dotnet build "Gateway_Solution.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gateway_Solution.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway_Solution.dll"]