using LetterAvatars.AspNetCore.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace LetterAvatars.AspNetCore.Extensions;

public static class ApplicationBuilderExtensions {
    public static IApplicationBuilder UseAvatars(this IApplicationBuilder builder) {
        return builder.UseMiddleware<AvatarMiddleware>();
    }
}
