# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory
WORKDIR /src

# Copy the solution file and restore any dependencies
COPY IP_S3_NvS_ToyShopAPI.sln ./
COPY ./IP_S3_NvS_ToyShopAPI/IP_S3_NvS_ToyShopAPI.csproj ./IP_S3_NvS_ToyShopAPI/
COPY ./IP_Business/IP_Business.csproj ./IP_Business/
COPY ./IP_Contract_Busness_DataLayer/IP_Contract_Business_DataLayer.csproj ./IP_Contract_Busness_DataLayer/
COPY ./IP_Contract_ToyShopAPI_Business/IP_Contract_ToyShopAPI_Business.csproj ./IP_Contract_ToyShopAPI_Business/
COPY ./IP_DateLayer/IP_DateLayer.csproj ./IP_DateLayer/
COPY ./IP_Models/IP_Models.csproj ./IP_Models/
COPY ./IP_UnitTests/IP_UnitTests.csproj ./IP_UnitTests/

RUN dotnet restore ./IP_S3_NvS_ToyShopAPI/IP_S3_NvS_ToyShopAPI.csproj

# Copy the remaining application files
COPY . .

# Build the application
WORKDIR ./IP_S3_NvS_ToyShopAPI
RUN dotnet publish -c Release -o /app/publish

# Use the official .NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app/publish .

# Expose the port the application runs on
EXPOSE 80

# Define the entry point for the container
ENTRYPOINT ["dotnet", "IP_S3_NvS_ToyShopAPI.dll"]