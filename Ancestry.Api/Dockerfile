#Pull Docker image 
FROM microsoft/dotnet:2.2-sdk AS build-env

WORKDIR /app

#Copy csproj and restore dependencies
#COPY *.csproj ./


#copy the rest of the files and publish
COPY . ./
RUN dotnet restore
RUN dotnet publish Ancestry.Api -c Release -o out

#Generate runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/Ancestry.Api/out .
ENTRYPOINT ["dotnet", "Ancestry.Api.dll"]
