FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["hello-world/hello-world.csproj", "hello-world/"]
RUN dotnet restore "hello-world/hello-world.csproj"
COPY . .
WORKDIR "/src/hello-world"
RUN dotnet build "hello-world.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hello-world.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hello-world.dll"]
