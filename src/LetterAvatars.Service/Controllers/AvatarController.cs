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
                case ".png":
                    return "png";
                case ".webp":
                    return "webp";
                case ".svg":
                    return "svg";
            }

            var acceptHeaders = Request.Headers["Accept"];

            if(acceptHeaders.Any(header => header?.Contains("image/svg+xml", StringComparison.OrdinalIgnoreCase) == true))
                return "svg";

            if(acceptHeaders.Any(header => header?.Contains("image/webp", StringComparison.OrdinalIgnoreCase) == true))
                return "webp";
            
            return "png";
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
