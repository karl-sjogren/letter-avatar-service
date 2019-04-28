using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetterAvatarService.Contracts;
using LetterAvatarService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LetterAvatarService {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers()
                .AddNewtonsoftJson();
            
            services.AddSingleton<IFontService, DefaultFontService>();
            services.AddSingleton<IPaletteService, DefaultPaletteService>();
            services.AddSingleton<IBlobCacheService, DefaultBlobCacheService>();
            //services.AddSingleton<IBlobCacheService, AzureBlobCacherService>();
            services.AddTransient<IAvatarService, AvatarService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
