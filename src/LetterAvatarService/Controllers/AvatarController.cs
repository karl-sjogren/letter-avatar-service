using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LetterAvatarService.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace LetterAvatarService.Controllers {
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
        public async Task<ActionResult> GetAvatar(string name, CancellationToken cancellationToken) {
            var format = GetAvatarFormat();
            var buffer = await _avatarService.GenerateAvatar(name, format, 512, 275, cancellationToken);

            return new FileContentResult(buffer, new MediaTypeHeaderValue(GetMimeType(format)));
        }

        [HttpGet("thumb/{name}")]
        public async Task<ActionResult> GetAvatarThumb(string name, CancellationToken cancellationToken) {
            var format = GetAvatarFormat();
            var buffer = await _avatarService.GenerateAvatar(name, format, 64, 32, cancellationToken);

            return new FileContentResult(buffer, new MediaTypeHeaderValue(GetMimeType(format)));
        }

        [HttpGet("mini/{name}")]
        public async Task<ActionResult> GetAvatarMini(string name, CancellationToken cancellationToken) {
            var format = GetAvatarFormat();
            var buffer = await _avatarService.GenerateAvatar(name, format, 32, 16, cancellationToken);

            return new FileContentResult(buffer, new MediaTypeHeaderValue(GetMimeType(format)));
        }

        [HttpGet("svg/{name}")]
        public async Task<ActionResult> GetAvatarSvg(string name, CancellationToken cancellationToken) {
            var buffer = await _avatarService.GenerateAvatar(name, AvatarFormat.Svg, 512, 275, cancellationToken);

            return new FileContentResult(buffer, new MediaTypeHeaderValue(GetMimeType(AvatarFormat.Svg)));
        }

        private AvatarFormat GetAvatarFormat() {
            var acceptHeaders = Request.Headers["Accept"];
            if(acceptHeaders.Any(header => header?.Contains("image/webp", StringComparison.OrdinalIgnoreCase) == true))
                return AvatarFormat.WebP;
            
            return AvatarFormat.Png;
        }

        private string GetMimeType(AvatarFormat format) {
            switch(format) {
                case AvatarFormat.Png:
                    return "image/png";
                case AvatarFormat.WebP:
                    return "image/webp";
                case AvatarFormat.Svg:
                    return "image/svg+xml";
                default:
                    throw new InvalidOperationException("Invalid AvatarFormat specified.");
            }
        }
    }
}
