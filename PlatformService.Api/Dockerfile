FROM mcr.microsoft.com/dotnet/sdk as build

WORKDIR /app

COPY *.csproj .

COPY . .

RUN dotnet public -c Release -o out