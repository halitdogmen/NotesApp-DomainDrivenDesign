using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Domain.Repositories;
using NotesApp.Infrastructure.Caching.Abstract;
using NotesApp.Infrastructure.Caching.Concrete;
using NotesApp.Infrastructure.Caching.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Infrastructure.Caching.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureCachingLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Decorate<IAccountRepository, AccountCachedRepository>();
            services.Decorate<INoteRepository, NoteCachedRepository>();
            services.AddTransient<ICacheService, MemoryCacheService>();
            services.AddMemoryCache();
            // hangfire
            services.AddHangfire((x) => {
                x.UseMemoryStorage();
            });
            services.AddHangfireServer();
        }
    }
}
