FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY GitDockerAPI/GitDockerAPI.csproj GitDockerAPI/
RUN dotnet restore "GitDockerAPI/GitDockerAPI.csproj"
COPY . .
WORKDIR "/src/GitDockerAPI"
RUN dotnet build "GitDockerAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitDockerAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitDockerAPI.dll"]
