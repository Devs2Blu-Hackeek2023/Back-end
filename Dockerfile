# Use the official ASP.NET Core runtime image as a base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

# Define como diretório de trabalho a pasta /app
WORKDIR /app

# Expõe a porta 80 dentro do container
EXPOSE 5273

# Use the official ASP.NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Define a origem dos arquivos a serem utilizados em seguida
WORKDIR /src

# Copia os arquivos do projeto e restaura as dependências
COPY ["Back-End/Back-End.csproj", "Back-End/"]

# Restaura as dependências do projeto.
RUN dotnet restore "Back-End/Back-End.csproj"

# Copia todos os arquivos e pastas do diretório de origem
COPY . .

# Define novamente o diretório de trabalho atual como "/src/Back-End"
WORKDIR "/src/Back-End"

# Compila o projeto e define o diretório de saída como "/app/build"
RUN dotnet build "Back-End.csproj" -c Release -o /app/build

# Publica o aplicativo
FROM build AS publish

# Publica o aplicativo e define o diretório de saída como "/app/publish"
RUN dotnet publish "Back-End.csproj" -c Release -o /app/publish

# Use a base image e copie o aplicativo publicado
FROM base AS final

# Define o diretório de trabalho atual como "/app"
WORKDIR /app

# Copia os arquivos publicados da etapa "publish" para o diretório de trabalho atual da etapa "final"
COPY --from=publish /app/publish .

# Define o comando de entrada para o contêiner
ENTRYPOINT ["dotnet", "Back-End.dll"]