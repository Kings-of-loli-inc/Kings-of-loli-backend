FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
EXPOSE 5000

COPY . .
CMD [ "dotnet", "watch", "run", "--urls=http://+:5000", "--project", "./api.csproj" ]