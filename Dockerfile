# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

EXPOSE 80

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ToDoWebApi/*.csproj ./ToDoWebApi/
COPY Data/*.csproj ./Data/
COPY Services/*.csproj ./Services/
RUN dotnet restore 

# copy everything else and build app
COPY /. ./
WORKDIR /app/
RUN dotnet publish -c release -o /app/build --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/build ./
ENTRYPOINT ["dotnet", "ToDoWebApi.dll"]