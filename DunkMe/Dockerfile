#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 53902
EXPOSE 44368

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["DunkMe/DunkMe.csproj", "DunkMe/"]
RUN dotnet restore "DunkMe/DunkMe.csproj"
COPY . .
WORKDIR "/src/DunkMe"
RUN dotnet build "DunkMe.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DunkMe.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DunkMe.dll"]