using System.IO.Abstractions;
using System.Globalization;
using LetterAvatars.AspNetCore.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LetterAvatars.AspNetCore.Options;

namespace LetterAvatars.AspNetCore.Middlewares;

public class AvatarMiddleware : IMiddleware {
    private readonly IAvatarService _avatarService;
    private readonly IFileSystem _fileSystem;
    private readonly IOptions<AvatarMiddlewareOptions> _options;
    private readonly ILogger<AvatarMiddleware> _log;

    public AvatarMiddleware(IAvatarService avatarService, IFileSystem fileSystem, IOptions<AvatarMiddlewareOptions> options, ILogger<AvatarMiddleware> log) {
        _avatarService = avatarService;
        _fileSystem = fileSystem;
        _options = options;
        _log = log;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        var request = context.Request;
        if(!request.Path.StartsWithSegments(_options.Value.Path, out var restOfPath)) {
            await next(context);
            return;
        }

        var name = restOfPath.Value;
        if(string.IsNullOrWhiteSpace(name)) {
            context.Response.StatusCode = 400;
            return;
        }

        var formatExtension = GetAvatarFormat(name);

        name = _fileSystem.Path.GetFileNameWithoutExtension(name);

        var buffer = await _avatarService.GenerateAvatarAsync(name, formatExtension, 512, context.RequestAborted);
        if(buffer is null) {
            context.Response.StatusCode = 500;
            return;
        }

        var response = context.Response;
        response.Headers.Append("Content-Type", GetMimeType(formatExtension));
        response.Headers.Append("Cache-Control", "public,max-age=31536000");
        response.Headers.Append("Content-Length", buffer.Length.ToString(CultureInfo.InvariantCulture));
        await response.Body.WriteAsync(buffer);
    }

    private string GetAvatarFormat(string name) {
        var extension = _fileSystem.Path.GetExtension(name).ToLowerInvariant();

        return extension switch {
            ".svg" => "svg",
            ".webp" => "webp",
            ".png" => "png",
            // Browsers doesn't seem to advertise svg support in the Accept header (since all the major ones have
            // it) so we'll just fall back to it.
            _ => "svg",
        };
    }

    private string GetMimeType(string formatExtension) => formatExtension switch {
        "png" => "image/png",
        "webp" => "image/webp",
        "svg" => "image/svg+xml",
        _ => throw new InvalidOperationException("Invalid AvatarFormat specified."),
    };
}
