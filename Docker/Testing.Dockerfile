FROM mcr.microsoft.com/dotnet/core/sdk:latest As Build

WORKDIR /src

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

RUN ls -alR
COPY . .

RUN dotnet publish /src/ShoutOut.Tests/ShoutOut.Tests.csproj -c Release -o output

WORKDIR /src/output

ENTRYPOINT [ "dotnet","test","ShoutOut.Tests.dll" ]
# RUN dotnet test /src/ShoutOut.Tests/ShoutOut.Tests.csproj






