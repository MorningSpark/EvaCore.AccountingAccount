# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiamos la solución y los proyectos
COPY EvaCore.AccountingAccount.sln ./
COPY src/EvaCore.AccountingAccount.Api/*.csproj ./src/EvaCore.AccountingAccount.Api/
COPY src/EvaCore.AccountingAccount.Application/*.csproj ./src/EvaCore.AccountingAccount.Application/
COPY src/EvaCore.AccountingAccount.Domain/*.csproj ./src/EvaCore.AccountingAccount.Domain/
COPY src/EvaCore.AccountingAccount.Infrastructure/*.csproj ./src/EvaCore.AccountingAccount.Infrastructure/

RUN dotnet restore "EvaCore.AccountingAccount.sln"

# Copiamos el resto del código fuente
COPY . .

# Publicamos el proyecto API
WORKDIR /app/src/EvaCore.AccountingAccount.Api
RUN dotnet publish -c Release -o /app/publish

# Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5003
ENV ASPNETCORE_URLS=https://+:5003
ENTRYPOINT ["dotnet", "EvaCore.AccountingAccount.Api.dll"]




