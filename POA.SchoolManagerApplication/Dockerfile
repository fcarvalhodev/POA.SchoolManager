#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["POA.SchoolManagerApplication/POA.SchoolManagerApplication.csproj", "POA.SchoolManagerApplication/"]
RUN dotnet restore "POA.SchoolManagerApplication/POA.SchoolManagerApplication.csproj"
COPY . .
WORKDIR "/src/POA.SchoolManagerApplication"
RUN dotnet build "POA.SchoolManagerApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POA.SchoolManagerApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POA.SchoolManagerApplication.dll"]