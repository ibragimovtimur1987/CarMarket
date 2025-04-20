FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/WebApi/WebApi.csproj", "src/WebApi/"]
COPY ["src/Infrastructure/Infrastructure.EntityFramework/Infrastructure.EntityFramework.csproj", "src/Infrastructure/Infrastructure.EntityFramework/"]
COPY ["src/Domain/Domain.Entities/Domain.Entities.csproj", "src/Domain/Domain.Entities/"]
COPY ["src/Infrastructure/Infrastructure.Repositories.Implementations/Infrastructure.Repositories.Implementations.csproj", "src/Infrastructure/Infrastructure.Repositories.Implementations/"]
COPY ["src/Services/Services.Repositories.Abstractions/Services.Repositories.Abstractions.csproj", "src/Services/Services.Repositories.Abstractions/"]
COPY ["src/Services/Services.Contracts/Services.Contracts.csproj", "src/Services/Services.Contracts/"]
COPY ["src/Services/Services.Abstractions/Services.Abstractions.csproj", "src/Services/Services.Abstractions/"]
COPY ["src/Services/Services.Implementations/Services.Implementations.csproj", "src/Services/Services.Implementations/"]
RUN dotnet restore "src/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi"
RUN dotnet build "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
