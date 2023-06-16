FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["ZuydSpeelt/ZuydSpeelt.csproj", "ZuydSpeelt/"]
RUN dotnet restore "ZuydSpeelt/ZuydSpeelt.csproj"
COPY . .
WORKDIR "/src/ZuydSpeelt"

RUN dotnet build "ZuydSpeelt.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "ZuydSpeelt.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ARG ZUYDSPEELT_CONNECTIONSTRING
ENV ZUYDSPEELT_CONNECTIONSTRING=$ZUYDSPEELT_CONNECTIONSTRING

ARG ENVIRONMENT
ENV ENVIRONMENT=$ENVIRONMENT

COPY wait-for-it.sh ./
RUN chmod +x ./wait-for-it.sh

ENTRYPOINT ["./wait-for-it.sh", "db:5432", "--", "dotnet", "ZuydSpeelt.dll"]