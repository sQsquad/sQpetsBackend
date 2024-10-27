FROM mcr.microsoft.com/dotnet/sdk:8.0 AS Build-env
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
ENV DeafultConnection = "Server=sqpets-db-2456.g8x.gcp-southamerica-east1.cockroachlabs.cloud;Port=26257;Database=DBSQPETS;Username=sqsquad;Password=fbjsKFBZXbqFl52EaoNVyg;"
COPY --from=build-env /app/out .

EXPOSE 8080
EXPOSE 443
ENTRYPOINT ["dotnet", "sQpets-Backend.dll"]