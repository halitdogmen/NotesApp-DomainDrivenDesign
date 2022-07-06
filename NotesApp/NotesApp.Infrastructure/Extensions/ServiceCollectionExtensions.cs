using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Domain.Repositories;
using NotesApp.Infrastructure.Database;
using NotesApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DatabaseContext>((options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("AppConn"));
                options.EnableSensitiveDataLogging();
            }, poolSize: 20);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
        }
    }
}
