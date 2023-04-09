#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Enrollment.Management.Students.Api/Enrollment.Management.Students.Api.csproj", "Enrollment.Management.Students.Api/"]
COPY ["Enrollment.Management.Students.Domain/Enrollment.Management.Students.Domain.csproj", "Enrollment.Management.Students.Domain/"]
COPY ["Enrollment.Management.Students.Infrastructure/Enrollment.Management.Students.Infrastructure.csproj", "Enrollment.Management.Students.Infrastructure/"]
RUN dotnet restore "Enrollment.Management.Students.Api/Enrollment.Management.Students.Api.csproj"
COPY . .
WORKDIR "/src/Enrollment.Management.Students.Api"
RUN dotnet build "Enrollment.Management.Students.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Enrollment.Management.Students.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Enrollment.Management.Students.Api.dll"]