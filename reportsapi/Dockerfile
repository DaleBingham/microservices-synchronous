FROM microsoft/dotnet:sdk AS build-env
ENV ASPNETCORE_ENVIRONMENT Testing
WORKDIR /app/

# copy the project and restore as distinct layers in the image
COPY *.csproj ./
RUN dotnet restore

# copy the rest and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/dotnet:2.1-runtime
WORKDIR /app
COPY --from=build-env /app/out ./
ENV ASPNETCORE_ENVIRONMENT  Testing
ENV ASPNETCORE_URLS         http://*:8080
ENV peopleapi_baseurl       http://localhost:9004/api/people/
ENV clientapi_baseurl       http://localhost:9000/api/clients/
ENV salesapi_baseurl        http://localhost:9006/salesapi/api/sales/
ENV inventoryapi_baseurl    http://localhost:9002/api/inventory/

EXPOSE 8080
ENTRYPOINT ["dotnet", "reportsapi.dll"]