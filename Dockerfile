FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# Стадия сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем проект и решаем зависимости
COPY ["src/WebApi/", "WebApi/"]
COPY ["src/Domain/Domain.Entities/", "Domain/Domain.Entities/"]
COPY ["src/Infrastructure/Infrastructure.EntityFramework/", "Infrastructure/Infrastructure.EntityFramework/"]
COPY ["src/Infrastructure/Infrastructure.Repositories.Implementations/", "Infrastructure/Infrastructure.Repositories.Implementations/"]
COPY ["src/Services/Services.Repositories.Abstractions/", "Services/Services.Repositories.Abstractions/"]
COPY ["src/Services/Services.Contracts/", "Services/Services.Contracts/"]
COPY ["src/Services/Services.Abstractions/", "Services/Services.Abstractions/"]
COPY ["src/Services/Services.Implementations/", "Services/Services.Implementations/"]
RUN dotnet restore "WebApi/WebApi.csproj"
WORKDIR "/src/WebApi"

# Добавляем dotnet-ef в PATH
ENV PATH="$PATH:/usr/local/dotnet-tools"

# Публикуем проект
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Стадия финального образа
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

# Устанавливаем dotnet-ef здесь, в build (SDK есть)
RUN dotnet tool install dotnet-ef --version 8.0.0 --tool-path /usr/local/dotnet-tools

# Копируем публикацию из стадии build
COPY --from=build /app/publish .

CMD ["dotnet", "WebApi.dll"]
