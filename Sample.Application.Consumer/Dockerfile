#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Sample.Application.Consumer/Sample.Application.Consumer.csproj", "Sample.Application.Consumer/"]
RUN dotnet restore "Sample.Application.Consumer/Sample.Application.Consumer.csproj"
COPY . .
WORKDIR "/src/Sample.Application.Consumer"
RUN dotnet build "Sample.Application.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.Application.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.Application.Consumer.dll"]