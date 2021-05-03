FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /build/src

LABEL "net-fusion.template.layer"="Contains Restored NuGets"
LABEL "net-fusion.project.url"="https://github.com/grecosoft/NetFusion"

# --------------------------------------------------------------------------------------
# RESTORE [Stage 1]
# --------------------------------------------------------------------------------------
# - This section copies only the solution and projects files used to restore the needed 
#   NuGet packages.  The restored packages are placed in:  /root/.nuget/packages.
#
# - The reason for only copying the solution and project files is so the created layers
#   will be smaller (a restore does not require the source.)  When the next stage is
#   is executed (Build/Test/Publish) for the first time or all subsequent builds,
#   these layers will already exist, and if not changed, will not have to be built.
#
# - These layers would change, for example, if a new Nuget package was added to any
#   of the projects. 
#
# - Since the source of the microservice will change the most often, these layers will
#   be reused and will not have be recreated when the updated source is built. 
# --------------------------------------------------------------------------------------

# Copy microservice components:
COPY ./src/Components/Demo.App/*.csproj ./Components/Demo.App/
COPY ./src/Components/Demo.Domain/*.csproj ./Components/Demo.Domain/
COPY ./src/Components/Demo.Infra/*.csproj ./Components/Demo.Infra/

# Copy microservice hosts:
COPY ./src/Demo.Tests/*.csproj ./Demo.Tests/
COPY ./src/Demo.WebApi/*.csproj ./Demo.WebApi/

# Copy the solution file to restore all projects:
COPY ./src/Demo.sln ./
RUN dotnet restore 
RUN rm -rd /build/src

# # --------------------------------------------------------------------------------------
# # BUILD / TEST / PUBLISH [Stage 2]
# # --------------------------------------------------------------------------------------

# Copy all the source and build the microservice.
COPY ./src ./
RUN dotnet build ./Demo.sln

RUN dotnet test ./Demo.Tests/ --no-build
RUN dotnet publish ./Demo.WebApi/Demo.WebApi.csproj --output ../out --no-build

# --------------------------------------------------------------------------------------
# CREATE IMAGE FOR CONTAINER CREATION [State 3]
# - This state takes the published output from [State 2] and copies them in to a layer
#   belonging to a new Docker image based on the aspnet core base image.  
# - This base image is much smaller since it is a non SDK runtime for asp.net core.
# --------------------------------------------------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /microservice

COPY --from=build-env /build/out ./
ENTRYPOINT ["dotnet", "Demo.WebApi.dll"]
EXPOSE 80