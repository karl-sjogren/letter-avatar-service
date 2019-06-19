using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LetterAvatars.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace LetterAvatars.Service.Controllers {
    [Route("avatars")]
    [ApiController]
    public class AvatarController : ControllerBase {
        private readonly IAvatarService _avatarService;
        private readonly ILogger<AvatarController> _log;

        public AvatarController(IAvatarService avatarService, ILogger<AvatarController> log) {
            _avatarService = avatarService;
            _log = log;
        }

        [HttpGet("{name}")]
        [ResponseCache(Duration = 31_536_000, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult> GetAvatar(string name, [FromQuery] Int32 size = 512, CancellationToken cancellationToken = default) {
            var formatExtension = GetAvatarFormat(name);

            name = Path.GetFileNameWithoutExtension(name);

            var buffer = await _avatarService.GenerateAvatar(name, formatExtension, 512, cancellationToken);

            return new FileContentResult(buffer, new MediaTypeHeaderValue(GetMimeType(formatExtension)));
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
