#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Gateway.Enrollment.Management.WebAPI/Gateway.Enrollment.Management.WebAPI.csproj", "Gateway.Enrollment.Management.WebAPI/"]
RUN dotnet restore "Gateway.Enrollment.Management.WebAPI/Gateway.Enrollment.Management.WebAPI.csproj"
COPY . .
WORKDIR "/src/Gateway.Enrollment.Management.WebAPI"
RUN dotnet build "Gateway.Enrollment.Management.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gateway.Enrollment.Management.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.Enrollment.Management.WebAPI.dll"]