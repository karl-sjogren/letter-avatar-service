FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy everything and build
COPY . ./
RUN dotnet publish src/LetterAvatars.Service/LetterAvatars.Service.csproj -f net9.0 -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

EXPOSE 8080

# Install some dependencies for cwebp
RUN apt-get update && apt-get install -y \
    libgl1-mesa-glx \
    libxi6 \
    libgconf-2-4

COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "LetterAvatars.Service.dll"]
