FROM mcr.microsoft.com/mssql/server:2019-latest

EXPOSE 1433

ENV ACCEPT_EULA "Y"

ENV SA_PASSWORD "1Secure*Password1"

