using System.IO.Abstractions;
using Amazon.S3;
using LetterAvatars.AspNetCore.Extensions;
using LetterAvatars.Service.Extensions;
using Microsoft.AspNetCore.ResponseCompression;

namespace LetterAvatars.Service;

public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services) {
        services
            .AddControllers();

        services.AddHttpLogging(_ => { });

        services.AddSingleton<IFileSystem, FileSystem>();

        services.AddResponseCompression(options => {
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
            options.EnableForHttps = true;
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(["image/svg+xml"]);
        });

        var awsOptions = Configuration.GetAWSOptionsWithCredentials();
        services.AddDefaultAWSOptions(awsOptions);
        services.AddAWSService<IAmazonS3>();

        services
            .AddAvatarService(Configuration)
            .AddAvatarFactories()
            .AddAvatarFont()
            .AddAvatarPalette()
            .AddAvatarGenerators();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        app.UseHttpLogging();

        if(env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        } else {
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseResponseCompression();

        app.UseAvatars();

        app.UseRouting();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }
}
