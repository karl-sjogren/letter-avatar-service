FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# Copy everything and build
COPY . ./
RUN dotnet publish -f netcoreapp3.0 -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app

# Install some dependencies for cwebp
RUN apt-get update && apt-get install -y \
    libgl1-mesa-glx \
    libxi6 \
    libgconf-2-4

COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "LetterAvatars.Service.dll"]
