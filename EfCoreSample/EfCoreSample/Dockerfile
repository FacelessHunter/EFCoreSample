#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["EfCoreSample/EfCoreSample.csproj", "EfCoreSample/"]
COPY ["EfCoreSample.Persistance/EfCoreSample.Persistance.csproj", "EfCoreSample.Persistance/"]
COPY ["EfCoreSample.Doman/EfCoreSample.Doman.csproj", "EfCoreSample.Doman/"]
COPY ["EfCoreSample.Services/EfCoreSample.Services.csproj", "EfCoreSample.Services/"]
COPY ["EfCoreSample.Infrastructure/EfCoreSample.Infrastructure.csproj", "EfCoreSample.Infrastructure/"]
RUN dotnet restore "EfCoreSample/EfCoreSample.csproj"
COPY . .
WORKDIR "/src/EfCoreSample"
RUN dotnet build "EfCoreSample.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EfCoreSample.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EfCoreSample.dll"]
