FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ZuydSpeelt/ZuydSpeelt.csproj", "ZuydSpeelt/"]
RUN dotnet restore "ZuydSpeelt/ZuydSpeelt.csproj"
COPY . .
WORKDIR "/src/ZuydSpeelt"

# RUN dotnet tool install dotnet-ef 
# RUN dotnet-ef database update

RUN dotnet build "ZuydSpeelt.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZuydSpeelt.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZuydSpeelt.dll"]