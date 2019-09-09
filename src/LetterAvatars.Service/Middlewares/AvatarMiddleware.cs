using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using LetterAvatars.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LetterAvatars.Service.Middlewares {
    public class AvatarMiddleware {
        private readonly RequestDelegate _next;
        private readonly PathString _endpoint;
        private readonly IAvatarService _avatarService;
        private readonly ILogger<AvatarMiddleware> _log;

        public AvatarMiddleware(PathString endpoint, RequestDelegate next, IAvatarService avatarService, ILogger<AvatarMiddleware> log) {
            _endpoint = endpoint;
            _next = next;
            _avatarService = avatarService;
            _log = log;
        }

        public async Task Invoke(HttpContext httpContext) {
            var request = httpContext.Request;
            if(!request.Path.StartsWithSegments(_endpoint, out var restOfPath)) {
                await _next(httpContext);
                return;
            }

            var name = restOfPath.Value;
            var formatExtension = GetAvatarFormat(name);

            name = Path.GetFileNameWithoutExtension(name);

            var buffer = await _avatarService.GenerateAvatar(name, formatExtension, 512, httpContext.RequestAborted);

            var response = httpContext.Response;
            response.Headers.Add("Content-Type", GetMimeType(formatExtension));
            response.Headers.Add("Cache-Control", "public,max-age=31536000");
            response.Headers.Add("Content-Length", buffer.Length.ToString(CultureInfo.InvariantCulture));
            await response.Body.WriteAsync(buffer, 0, buffer.Length);
        }

        private string GetAvatarFormat(string name) {
            var extension = Path.GetExtension(name).ToLowerInvariant();;

            switch(extension) {
                case ".svg":
                    return "svg";
                case ".webp":
                    return "webp";
                case ".png":
                    return "png";
            }

            // Browsers doesn't seem to advertise svg support in the Accept header (since all the major ones have
            // it) so we'll just fall back to it.

            return "svg";
        }

        private string GetMimeType(string formatExtension) {
            switch(formatExtension) {
                case "png":
                    return "image/png";
                case "webp":
                    return "image/webp";
                case "svg":
                    return "image/svg+xml";
                default:
                    throw new InvalidOperationException("Invalid AvatarFormat specified.");
            }
        }
    }
}