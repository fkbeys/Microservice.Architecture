#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["microservices/payment/Microservice.PaymentService.Api/Microservice.PaymentService.Api.csproj", "microservices/payment/Microservice.PaymentService.Api/"]
COPY ["core/Microservice.Api/Microservice.Api.csproj", "core/Microservice.Api/"]
COPY ["core/Microservice.Api.AspNetCore.Authentication/Microservice.Api.AspNetCore.Authentication.csproj", "core/Microservice.Api.AspNetCore.Authentication/"]
COPY ["core/Microservice.Api.AspNetCore/Microservice.Api.AspNetCore.csproj", "core/Microservice.Api.AspNetCore/"]
COPY ["core/Microservice.Core/Microservice.Core.csproj", "core/Microservice.Core/"]
COPY ["core/Microservice.Api.AspNetCore.Authorization/Microservice.Api.AspNetCore.Authorization.csproj", "core/Microservice.Api.AspNetCore.Authorization/"]
COPY ["core/Microservice.Api.AspNetCore.Swagger/Microservice.Api.AspNetCore.Swagger.csproj", "core/Microservice.Api.AspNetCore.Swagger/"]
COPY ["microservices/payment/Microservice.PaymentService.Application/Microservice.PaymentService.Application.csproj", "microservices/payment/Microservice.PaymentService.Application/"]
COPY ["core/Microservice.Application.CQRS/Microservice.Application.CQRS.csproj", "core/Microservice.Application.CQRS/"]
COPY ["core/Microservice.Application/Microservice.Application.csproj", "core/Microservice.Application/"]
COPY ["core/Microservice.Application.Abstractions/Microservice.Application.Abstractions.csproj", "core/Microservice.Application.Abstractions/"]
COPY ["microservices/payment/Microservice.PaymentService.Application.Abstractions/Microservice.PaymentService.Application.Abstractions.csproj", "microservices/payment/Microservice.PaymentService.Application.Abstractions/"]
COPY ["microservices/payment/Microservice.PaymentService.Domain.Share/Microservice.PaymentService.Domain.Share.csproj", "microservices/payment/Microservice.PaymentService.Domain.Share/"]
COPY ["microservices/payment/Microservice.PaymentService.Domain/Microservice.PaymentService.Domain.csproj", "microservices/payment/Microservice.PaymentService.Domain/"]
COPY ["core/Microservice.Domain/Microservice.Domain.csproj", "core/Microservice.Domain/"]
COPY ["core/Microservice.Infrastructure.Abstractions/Microservice.Infrastructure.Abstractions.csproj", "core/Microservice.Infrastructure.Abstractions/"]
COPY ["microservices/payment/Microservice.PaymentService.Infrastructure/Microservice.PaymentService.Infrastructure.csproj", "microservices/payment/Microservice.PaymentService.Infrastructure/"]
COPY ["core/Microservice.Infrastructure.EntityFrameworkCore/Microservice.Infrastructure.EntityFrameworkCore.csproj", "core/Microservice.Infrastructure.EntityFrameworkCore/"]
RUN dotnet restore "microservices/payment/Microservice.PaymentService.Api/Microservice.PaymentService.Api.csproj"
COPY . .
WORKDIR "/src/microservices/payment/Microservice.PaymentService.Api"
RUN dotnet build "Microservice.PaymentService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.PaymentService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.PaymentService.Api.dll"]