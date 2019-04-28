FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "LetterAvatarService.dll"]