FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Sunday_Test_API/Sunday_Test_API.csproj", "Sunday_Test_API/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Utils/Utils.csproj", "Utils/"]
RUN dotnet restore "Sunday_Test_API/Sunday_Test_API.csproj"
COPY . .
WORKDIR "/src/Sunday_Test_API"
RUN dotnet build "Sunday_Test_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sunday_Test_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sunday_Test_API.dll"]
