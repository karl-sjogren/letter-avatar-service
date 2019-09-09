using LetterAvatars.Service.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace LetterAvatars.Service.Extensions {
    public static class ApplicationBuilderExtensions {
        public static IApplicationBuilder UseAvatars(this IApplicationBuilder builder, string endpoint) {
            return builder.UseMiddleware<AvatarMiddleware>(new PathString(endpoint));
        }
    }
}