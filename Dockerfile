﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OpenShiftDemoApp/OpenShiftDemoApp.csproj", "OpenShiftDemoApp/"]
RUN dotnet restore "OpenShiftDemoApp/OpenShiftDemoApp.csproj"
COPY . .
WORKDIR "/src/OpenShiftDemoApp"
RUN dotnet build "OpenShiftDemoApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OpenShiftDemoApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_HTTP_PORTS 80
ENV ASPNETCORE_HTTPS_PORTS 443
ENTRYPOINT ["dotnet", "OpenShiftDemoApp.dll"]
