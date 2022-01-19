FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AucService.csproj", "./"]
RUN dotnet restore "AucService.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "AucService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AucService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AucService.dll"]
CMD ["dotnet", "AucService.dll", "--server.urls", "http://+:$(PORT)"]
