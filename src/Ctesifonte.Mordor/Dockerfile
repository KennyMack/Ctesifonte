#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Ctesifonte.Mordor/Ctesifonte.Mordor.csproj", "Ctesifonte.Mordor/"]
RUN dotnet restore "Ctesifonte.Mordor/Ctesifonte.Mordor.csproj"
COPY . .
WORKDIR "/src/Ctesifonte.Mordor"
RUN dotnet build "Ctesifonte.Mordor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ctesifonte.Mordor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ctesifonte.Mordor.dll"]