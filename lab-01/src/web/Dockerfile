FROM microsoft/aspnetcore-build:1.0
WORKDIR /source

# copy csproj and restore as distinct layers
COPY ./* ./
RUN dotnet restore
RUN dotnet publish
