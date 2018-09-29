FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 51687
EXPOSE 44336

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["IdentityMVC.csproj", "IdentityMVC/"]
RUN dotnet restore "IdentityMVC/IdentityMVC.csproj"
COPY . "IdentityMVC/"
Run ls
WORKDIR "/src/IdentityMVC"
RUN dotnet build "IdentityMVC.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IdentityMVC.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IdentityMVC.dll"]