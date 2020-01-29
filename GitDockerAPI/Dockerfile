FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY GitDockerAPI.csproj .
RUN dotnet restore "GitDockerAPI.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "GitDockerAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitDockerAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitDockerAPI.dll"]
