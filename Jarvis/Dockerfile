FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /app
COPY ./ ./
RUN dotnet restore 
RUN dotnet publish -c Release -o published


FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS runner
WORKDIR /app
COPY --from=build /app/published .
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "Jarvis.dll"]
