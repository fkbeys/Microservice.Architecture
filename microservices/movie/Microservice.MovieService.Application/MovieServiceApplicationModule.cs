﻿using Microservice.Core.Modularity;
using Microservice.MovieService.Application.MovieManagement;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.MovieService.Application;

public sealed class MovieServiceApplicationModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        base.Configure(services);

        services.AddTransient<IMovieApplicationService, MovieApplicationService>();
    }
}
