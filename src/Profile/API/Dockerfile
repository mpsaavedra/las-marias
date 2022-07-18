ARG NET_IMAGE=6.0
FROM mcr.microsoft.com/dotnet/aspnet:${NET_IMAGE} AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:${NET_IMAGE} AS build
WORKDIR /src

# optimize build cache
COPY ["src/BuildingBlocks/src/Core/Core.csproj", "src/BuildingBlocks/src/Core/"]
COPY ["src/BuildingBlocks/src/Domain/Domain.csproj", "src/BuildingBlocks/src/Domain"]
COPY ["src/Conference/API/LasMarias.Conference.csproj", "src/Conference/API"]
COPY ["src/Conference/Domain/LasMarias.Conference.Domain.csproj", "src/Conference/Domain"]
COPY ["src/Conference/Shared/LasMarias.Conference.Shared.csproj", "src/Conference/Shared"]
COPY ["src/Hotel/API/LasMarias.Hotel.csproj", "src/Hotel/API"]
COPY ["src/Hotel/Domain/LasMarias.Hotel.Domain.csproj", "src/Hotel/Domain"]
COPY ["src/Hotel/Shared/LasMarias.Hotel.Shared.csproj", "src/Hotel/Shared"]
COPY ["src/Pools/API/LasMarias.Pools.csproj", "src/Pools/API"]
COPY ["src/Pools/Domain/LasMarias.Pools.Domain.csproj", "src/Pools/Domain"]
COPY ["src/Pools/Shared/LasMarias.Pools.Shared.csproj", "src/Pools/Shared"]
COPY ["src/PoS/API/LasMarias.PoS.csproj", "src/PoS/API"]
COPY ["src/PoS/Domain/LasMarias.PoS.Domain.csproj", "src/PoS/Domain"]
COPY ["src/PoS/Shared/LasMarias.PoS.Shared.csproj", "src/PoS/Shared"]
COPY ["src/Profile/API/LasMarias.Profile.csproj", "src/Profile/API"]
COPY ["src/Profile/Domain/LasMarias.Profile.Domain.csproj", "src/Profile/Domain"]
COPY ["src/Profile/Shared/LasMarias.Profile.Shared.csproj", "src/Profile/Shared"]
#COPY ["src/Profile/BusinessLogic/Benefit/Benefit.csproj", "src/Profile/BusinessLogic/Benefit]
COPY ["src/Restaurant/API/LasMarias.Restaurant.csproj", "src/Restaurant/API"]
COPY ["src/Restaurant/Domain/LasMarias.Restaurant.Domain.csproj", "src/Restaurant/Domain"]
COPY ["src/Restaurant/Shared/LasMarias.Restaurant.Shared.csproj", "src/Restaurant/Shared"]
COPY ["src/WareHouse/API/LasMarias.WareHouse.csproj", "src/WareHouse/API"]
COPY ["src/WareHouse/Domain/LasMarias.WareHouse.Domain.csproj", "src/WareHouse/Domain"]
COPY ["src/WareHouse/Shared/LasMarias.WareHouse.Shared.csproj", "src/WareHouse/Shared"]
COPY ["LasMarias.sln", "./"]
RUN dotnet restore "LasMarias.sln"

COPY . .
WORKDIR "/src/src/Profile/API"
# RUN dotnet build "LasMarias.Profile.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore "LasMarias.Profile.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LasMarias.Profile.API.dll"]
