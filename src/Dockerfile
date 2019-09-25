FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY BookStore.Domain/*.csproj ./BookStore.Domain/
COPY BookStore.Infra/*.csproj ./BookStore.Infra/
COPY BookStore.Service/*.csproj ./BookStore.Service/
COPY BookStore.WebApp/*.csproj ./BookStore.WebApp/
RUN dotnet restore

# copy everything else and build app
COPY BookStore.Domain/. ./BookStore.Domain/
COPY BookStore.Infra/. ./BookStore.Infra/
COPY BookStore.Service/. ./BookStore.Service/
COPY BookStore.WebApp/. ./BookStore.WebApp/
WORKDIR /app/BookStore.WebApp
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/BookStore.WebApp/out ./
ENTRYPOINT ["dotnet", "BookStore.WebApp.dll"]