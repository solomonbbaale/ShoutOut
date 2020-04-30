FROM mcr.microsoft.com/dotnet/core/sdk:latest As Build
##setting working directory inside the container image
WORKDIR /src

##copying and restoring dependencies
COPY ./ShoutOut.Core/ShoutOut.Core.csproj ./ShoutOut.Core/
RUN dotnet restore ShoutOut.Core/ShoutOut.Core.csproj

COPY ./ShoutOut.Infrastructure/ShoutOut.Infrastructure.csproj ./ShoutOut.Infrastructure/
RUN dotnet restore ShoutOut.Infrastructure/ShoutOut.Infrastructure.csproj

COPY ./ShoutOut.ApplicationLayer/ShoutOut.ApplicationLayer.csproj  ./ShoutOut.ApplicationLayer/ 
RUN dotnet restore ShoutOut.ApplicationLayer/ShoutOut.ApplicationLayer.csproj

COPY ./ShoutOutApi/ShoutOutApi.csproj  ./ShoutOutApi/ShoutOutApi.csproj 
RUN dotnet restore ShoutOutApi/ShoutOutApi.csproj

COPY ./ShoutOut.Tests/ShoutOut.Tests.csproj ./ShoutOut.Tests/ShoutOut.Tests.csproj 
RUN dotnet restore ShoutOut.Tests/ShoutOut.Tests.csproj

##list all the file in the filesystem layer
RUN ls -alR

##copy whole solution into the container
COPY . .

RUN dotnet publish /src/ShoutOut.Tests/ShoutOut.Tests.csproj -c Release -o output

WORKDIR /src/output/

ENV TEAMCITY_PROJECT_NAME=fake

ENTRYPOINT [ "dotnet","test","ShoutOut.Tests.dll" ]
# RUN dotnet test /src/ShoutOut.Tests/ShoutOut.Tests.csproj







