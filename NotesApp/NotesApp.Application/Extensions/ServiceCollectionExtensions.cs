using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Application.AuthorizationHandlers;
using NotesApp.Application.Contracts.Services;
using NotesApp.Application.Services;
using SeedWork.Application.Utils.JWT.Abstract;
using SeedWork.Application.Utils.JWT.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            // AuthorizationHandlers
            services.AddSingleton<IAuthorizationHandler, AccountAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, NoteAuthorizationHandler>();
            // Utils
            services.AddSingleton<ITokenHelper, JWTHelper>();
            // App services
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<INoteAppService, NoteAppService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

    }
}
