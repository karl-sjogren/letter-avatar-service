using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using LetterAvatars.Generator;
using LetterAvatars.Service.Contracts;
using LetterAvatars.Service.Extensions;
using LetterAvatars.Service.Factories;
using LetterAvatars.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LetterAvatars.Service {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddResponseCompression(options => {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });

            var awsOptions = Configuration.GetAWSOptionsWithCredentials();
            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonS3>();

            services.AddSingleton<IFontProvider, DefaultFontProvider>();
            services.AddSingleton<IPaletteProvider, DefaultPaletteProvider>();
            services.AddScoped<IAvatarGenerator, SvgAvatarGenerator>();
            services.AddScoped<IAvatarGenerator, PngAvatarGenerator>();
            services.AddScoped<IAvatarGenerator, WebPAvatarGenerator>();
            services.AddScoped<IBlobCacheService>(CacheServiceFactory.CreateInstance);
            services.AddScoped<IStatisticsService>(StatisticsServiceFactory.CreateInstance);
            services.AddScoped<IAvatarService, AvatarService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseResponseCompression();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
