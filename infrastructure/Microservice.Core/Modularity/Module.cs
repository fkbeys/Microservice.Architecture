﻿using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Core.Modularity;

public abstract class Module : IModule
{
    public virtual void Configure(IServiceCollection services)
    {
    }

    public virtual void Initialize(IServiceProvider serviceProvider)
    {
    }

    public virtual void Shutdown(IServiceProvider serviceProvider)
    {
    }
}