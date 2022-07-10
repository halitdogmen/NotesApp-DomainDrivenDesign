#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NotesApp.API/NotesApp.API.csproj", "NotesApp.API/"]
COPY ["NotesApp.Infrastructure/NotesApp.Infrastructure.csproj", "NotesApp.Infrastructure/"]
COPY ["NotesApp.Domain/NotesApp.Domain.csproj", "NotesApp.Domain/"]
COPY ["BuildingBlocks/SeedWork/SeedWork.Domain/SeedWork.Domain.csproj", "BuildingBlocks/SeedWork/SeedWork.Domain/"]
COPY ["BuildingBlocks/SeedWork/SeedWork.Infrastructure/SeedWork.Infrastructure.csproj", "BuildingBlocks/SeedWork/SeedWork.Infrastructure/"]
COPY ["NotesApp.Application/NotesApp.Application.csproj", "NotesApp.Application/"]
COPY ["NotesApp.Application.Contracts/NotesApp.Application.Contracts.csproj", "NotesApp.Application.Contracts/"]
COPY ["BuildingBlocks/SeedWork/SeedWork.Application/SeedWork.Application.csproj", "BuildingBlocks/SeedWork/SeedWork.Application/"]
COPY ["NotesApp.Infrastructure.Caching/NotesApp.Infrastructure.Caching.csproj", "NotesApp.Infrastructure.Caching/"]
RUN dotnet restore "NotesApp.API/NotesApp.API.csproj"
COPY . .
WORKDIR "/src/NotesApp.API"
RUN dotnet build "NotesApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotesApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotesApp.API.dll"]